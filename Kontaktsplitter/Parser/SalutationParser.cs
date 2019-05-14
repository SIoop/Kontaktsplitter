using System;
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
            // DbAccess.ReloadTableContent();
            salutation = PreFormatSalutationString(salutation);
            return ParseSalutation(salutation);
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
        private Kunde ParseSalutation(string salutation)
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


            if (salutation.Contains(",") || salutation.Contains(" y "))
            {
                for (int i = 0; i < salutationArray.Length; i++)
                {
                    if (salutationArray[i].Contains(","))
                    {
                        result.Nachname = salutationArray[i].Replace(",", "");
                        result.Vorname = salutationArray[i + 1];
                        break;
                    }

                    // Spanischer doppelname mit y erkennen
                    if (salutationArray[i] == "y" && i > 0 && salutationArray.Length >= i + 1)
                    {
                        result.Nachname = salutationArray[i - 1] + " " + salutationArray[i] + " " +
                                          salutationArray[i + 1];

                        salutation = salutation.Replace(result.Nachname, string.Empty);
                    }
                }
            }



            salutation = ParseTitel(salutation, salutationArray, result);

            // Gschlecht per regex bestimmen
            if (result.InternalGeschlecht == Geschlecht.Ohne)
            {
                result.InternalGeschlecht = FindGender(salutation);
            }


            var anrede = FindSalutation(salutation);

            if (anrede != null)
            {
                salutation = salutation.Replace(anrede.AnredeBrief, string.Empty);
                salutation = salutation.Replace(anrede.AnredeNormal, string.Empty);
            }

            NameParts parts = null;
            if (!string.IsNullOrWhiteSpace(salutation))
            {
                NameParserLogic parser = new NameParserLogic();
                parts = parser.ParseName(salutation, NameOrder.AutoDetect);
            }



            // Falls anrede nicht manuell gefunden werden konnte
            if (anrede == null && parts != null)
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
            }

            // Falls anrede weder manuell oder durch parser nicht gefunden werden konnte.
            if (anrede == null)
            {
                anrede = new Anrede()
                {
                    AnredeNormal = "",
                    AnredeBrief = "Sehr geehrte Damen und Herren",
                    InternalGeschlecht = Geschlecht.Ohne
                };
            }

            // Falls durch manuellen Vergleich Titel gefunden wurden diese verwednen. Sonst NameParser Bibiliothek
            var titel = result.Titel;
            if (string.IsNullOrWhiteSpace(titel) && parts != null)
            {
                titel = parts.Honorific;
            }

            // Anrede mit Titel verfollständigen
            if (titel != null)
            {
                anrede.AnredeNormal += " " + titel;
                anrede.AnredeNormal = anrede.AnredeNormal.TrimStart();
                anrede.AnredeBrief += " " + titel;
                anrede.AnredeBrief = anrede.AnredeBrief.TrimStart();
            }

            // Nachname  manuell gefunden
            var lastName = result.Nachname;
            if (string.IsNullOrWhiteSpace(result.Nachname) && parts != null)
            {
                lastName = parts.LastName;
            }

            // Vorname manuell nicht gefunden
            var firstName = result.Vorname;
            if (string.IsNullOrWhiteSpace(result.Vorname) && parts != null)
            {
                firstName = parts.FirstName;
            }

            // neuer Kunde erstellen und zurückgeben, falls einer der Werte bisher null ist -> string.Empty
            return new Kunde()
            {
                Nachname = lastName,
                Titel = titel,
                Vorname = firstName,
                InternalGeschlecht = anrede.InternalGeschlecht,
                Anrede = anrede.AnredeNormal,
                Briefanrede = anrede.AnredeBrief
            };
        }

        /// <summary>
        /// Parst den Titel aus einem string[] mithife der DB
        /// </summary>
        /// <param name="salutation">Die gesamte salutation</param>
        /// <param name="salutationArray">Die in ein Array aufgeteilte salutation</param>
        /// <param name="currenCustomer">Der aktuelle Kunde </param>
        /// <returns>Die vollständige salutation, ohne die gefundenen Titel</returns>
        private static string ParseTitel(string salutation, string[] salutationArray, Kunde currenCustomer)
        {
            var allTitels = DbAccess.GetTitels();
            // Titel herausfinden
            foreach (var salutationPart in salutationArray)
            {
                // Mögliche Punkte entfernen
                var currentTitel = allTitels.Find(t => t.Kuerzel == salutationPart || t.Bezeichnung == salutationPart);
                if (currentTitel != null)
                {
                    currenCustomer.Titel += currentTitel.Kuerzel + " ";
                    salutation = salutation.Replace(salutationPart, string.Empty);
                }
            }

            if (currenCustomer.Titel != null)
            {
                currenCustomer.Titel = currenCustomer.Titel.TrimEnd();
            }

            return salutation;
        }

        /// <summary>
        /// Überprüft, ob aus einem string auf die Anrede geschlossen werden kann
        /// </summary>
        /// <param name="salutation">Der Teil einer Anrede, welcher überprüft werden soll.</param>
        /// <returns>Die Anrede, falls nicht eindeutig erkannt Null</returns>
        private Anrede FindSalutation(string salutation)
        {
            var anreden = DbAccess.GetSalutation();
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

            if (Regex.IsMatch(salutationPart, "(Herr\\.?\\s|Herrn\\.?\\s|Mr\\.?\\s|M\\.?\\s|herr\\n?\\.?\\s)"))
            {
                return Geschlecht.Männlich;
            }

            return Geschlecht.Ohne;
        }
    }
}