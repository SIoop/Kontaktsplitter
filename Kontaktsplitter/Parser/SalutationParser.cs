﻿using System;
using System.Linq;
using System.Text.RegularExpressions;
using KellermanSoftware.NameParser;
using Kontaktsplitter.Model;

namespace Kontaktsplitter.Parser
{
    /// <summary>
    /// Die Salutation Parser Klasse enthält Logik um Anreden aufzusplitten und die Informationen in einem Kunden umzuwandeln
    /// </summary>
    public class SalutationParser
    {
        /// <summary>
        /// Wandelt einen Anreden string in einen Kunden um
        /// </summary>
        /// <param name="salutation">Die salutation, welche umgewandelt werden soll</param>
        /// <returns>Der neue Kunde</returns>
        public Kunde StartParser(string salutation)
        {
            DbAccess.ReloadTableContent();
            salutation = PreFormatSalutationString(salutation);
            return ManualCustomerAssignment(salutation);
        }


        private string PreFormatSalutationString(string salutation)
        {
            var resultString = salutation;

            // markierter Nachnamen finden durch " und mit - verbinden
            if (salutation.Contains("\""))
            {
                var startIndexLastName = salutation.IndexOf('\"');
                var lastName = salutation.Substring(startIndexLastName + 1).Replace('\"', ' ').TrimStart().TrimEnd();
                var lastNameArray = lastName.Split(' ');
                var formatedLastName = string.Join("-", lastNameArray);

                resultString = salutation.Remove(startIndexLastName) + formatedLastName;
            }

            return resultString;
        }

        /// <summary>
        /// Manuelle Überprüfung der einzelnen bestandteile einer Anrede
        /// </summary>
        /// <param name="salutation">Die salutation, welche umgewandelt werden soll</param>
        /// <returns>Der neue Kunde</returns>
        private Kunde ManualCustomerAssignment(string salutation)
        {
            var result = new Kunde();
            
            // Falls Nachname mit Freiherr beginnt
            if (salutation.Contains("Freiherr"))
            {
                result.Nachname = salutation.Substring(salutation.IndexOf("Freiherr", StringComparison.OrdinalIgnoreCase));

                // Müller dient hier nur als Platzhalter, da der Nachname bereits erkannt wurde, aber möglicherweiße der Vorname durch die Bibiliothek gefunden werden muss 
                salutation = salutation.Replace(result.Nachname, "Müller");
            }

           

            var salutationArray = salutation.Split(' ');
            if (salutation.Contains(","))
            {
                for (int i = 0; i < salutationArray.Length; i++)
                {
                    if (salutationArray[i].Contains(","))
                    {
                        result.Nachname = salutationArray[i].Replace(",", "");
                        result.Vorname = salutationArray[i + 1];
                        break;
                    }

                }
            }

            var allTitels = DbAccess.GetTitels();
            

            result.Geschlecht = FindGender(salutation);

            // Titel herausfinden
            foreach (var salutationPart in salutationArray)
            {
                // Mögliche Punkte entfernen
               var currentTitel = allTitels.Find(t => t.Kuerzel == salutationPart || t.Bezeichnung == salutationPart);
                if (currentTitel != null)
                {
                    result.Titel += currentTitel.Kuerzel + " ";
                    salutation = salutation.Replace(salutationPart, string.Empty);
                }
            }

            if (result.Titel != null)
            {
                result.Titel = result.Titel.TrimEnd();

            }

            var anrede = FindSalutation(salutation);

            if (anrede != null)
            {
                salutation = salutation.Replace(anrede.AnredeBrief, string.Empty);
                salutation = salutation.Replace(anrede.AnredeNormal, string.Empty);
            }

            NameParserLogic parser = new NameParserLogic();
            NameParts parts = parser.ParseName(salutation, NameOrder.AutoDetect);

            // Falls anrede nicht manuell gefunden werden konnte
            if (anrede == null)
            {
                if (parts.IsMale == true)
                {
                    anrede = new Anrede()
                    {
                        AnredeNormal = "Herrn",
                        AnredeBrief = "Sehr geehrter Herr",
                        InternalGeschlecht = Geschlecht.Männlich
                    };
                }
                else if (parts.IsMale == false)
                {
                    anrede = new Anrede()
                    {
                        AnredeNormal = "Frau",
                        AnredeBrief = "Sehr geehrte Frau",
                        InternalGeschlecht = Geschlecht.Weiblich
                    };
                }
                else
                {
                    anrede = new Anrede()
                    {
                        AnredeNormal = "",
                        AnredeBrief = "Sehr geehrte Damen und Herren",
                        InternalGeschlecht = Geschlecht.Ohne
                    };
                }

              
            }



            // Falls durch manuellen Vergleich Titel gefunden wurden diese verwednen. Sonst NameParser Bibiliothek
            var titel = result.Titel;
            if (string.IsNullOrWhiteSpace(titel))
            {
                titel = parts.Honorific;
            }

            if (titel != null)
            {
                anrede.AnredeNormal += " " + titel;
                anrede.AnredeBrief += " " + titel;
            }

            // Last Name bereits manuell gefunden
            var lastName = parts.LastName;
            if (!string.IsNullOrWhiteSpace(result.Nachname))
            {
                lastName = result.Nachname;
            }

            // Last Name bereits manuell gefunden
            var firstName = parts.FirstName;
            if (!string.IsNullOrWhiteSpace(result.Vorname))
            {
                firstName = result.Vorname;
            }

            return new Kunde()
            {
                Nachname = lastName,
                Titel = titel,
                Vorname = firstName,
                Geschlecht = anrede.InternalGeschlecht,
                Anrede = anrede.AnredeNormal,
                Briefanrede = anrede.AnredeBrief
            };
        }

        /// <summary>
        /// Überprüft, ob aus einem string auf die Anrede geschlossen werden kann
        /// </summary>
        /// <param name="salutation">Der Teil einer Anrede, welcher überprüft werden soll.</param>
        /// <returns>Die Anrede, falls nicht eindeutig erkannt Null</returns>
        private Anrede FindSalutation(string salutation)
        {
            var anreden = DbAccess.GetAnreden();
            foreach (var anrede in anreden)
            {
                if (salutation.Contains(anrede.AnredeNormal + " ") && !string.IsNullOrEmpty(anrede.AnredeNormal) || salutation.Contains(anrede.AnredeBrief + " ") && !string.IsNullOrEmpty(anrede.AnredeBrief))
                {
                    return anrede;
                }
            }
            return null;
        }




        /// <summary>
        /// Überprüft, ob aus einem string auf das InternalGeschlecht geschlossen werden kann
        /// </summary>
        /// <param name="salutationPart">Der Teil einer Anrede, welcher überprüft werden soll.</param>
        /// <returns>Das Gechlecht, falls nicht eindeutig erkannt Ohne</returns>
        private Geschlecht FindGender(string salutationPart)
        {
            // InternalGeschlecht bestimmen
            if (Regex.IsMatch(salutationPart, "(Frau\\.?\\s|Mrs\\.?\\s|Ms\\.?\\s|frau\\.?\\s)"))
            {
                return Geschlecht.Weiblich;
            }

            if (Regex.IsMatch(salutationPart, "(Herr\\.?\\s|Herrn\\.?\\s|Mr\\.?\\s|M\\.?\\s)"))
            {
                return Geschlecht.Männlich;
            }

            return Geschlecht.Ohne;
        }
    }
}