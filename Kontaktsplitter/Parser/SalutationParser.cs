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

        /// <summary>
        /// Formatiert die Anrede vor und entfernt " "
        /// </summary>
        /// <param name="salutation">Die Anrede</param>
        /// <returns>Die formatierte Anrede</returns>
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
            var resultCustomer = new Kunde();
            var salutationArray = salutation.Split(' ');


            salutation = ParseSpecialSalutation(salutation, resultCustomer, salutationArray);
            salutation = ParseTitel(salutation, salutationArray, resultCustomer);
            var anrede = FindSalutation(salutation);

            // Geschlecht per regex bestimmen
            if (resultCustomer.InternalGeschlecht == Geschlecht.Ohne)
            {
                resultCustomer.InternalGeschlecht = FindGender(salutation);
            }

            // Falls Anrede gefunden (z.B. Brief) diese aus string entfernen, damit die restliche Erkennung leichter ist.
            if (anrede != null)
            {
                salutation = salutation.Replace(anrede.AnredeBrief, string.Empty);
                salutation = salutation.Replace(anrede.AnredeNormal, string.Empty);
            }

            // Name durch Bibiliothek finden
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

            // Falls anrede weder manuell oder durch parser gefunden werden konnte.
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
            var titel = resultCustomer.Titel;
            if (string.IsNullOrWhiteSpace(titel) && parts != null)
            {
                titel = parts.Honorific;
            }

            // Anrede mit Titel verfollständigen
            if (titel != null)
            {
                anrede.AnredeNormal += " " + titel;
                anrede.AnredeNormal = anrede.AnredeNormal.TrimStart().TrimEnd();
                anrede.AnredeBrief += " " + titel;
                anrede.AnredeBrief = anrede.AnredeBrief.TrimStart().TrimEnd();
            }

            // Nachname nicht manuell gefunden
            var lastName = resultCustomer.Nachname;
            if (string.IsNullOrWhiteSpace(resultCustomer.Nachname) && parts != null)
            {
                lastName = parts.LastName;
            }

            // Vorname nicht manuell gefunden
            var firstName = resultCustomer.Vorname;
            if (string.IsNullOrWhiteSpace(resultCustomer.Vorname) && parts != null)
            {
                firstName = parts.FirstName;
            }

            // neuer Kunde erstellen und zurückgeben
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
        /// Findet besondere Anreden wie Freiher oder spanische Doppelnamen
        /// </summary>
        /// <param name="salutation">Die Anrede</param>
        /// <param name="customer">Der Kunde</param>
        /// <param name="salutationArray">Die Anrede als string[]</param>
        /// <returns>Die angepasste Anrede</returns>
        private static string ParseSpecialSalutation(string salutation, Kunde customer, string[] salutationArray)
        {
            // Falls Nachname mit Freiherr beginnt
            if (salutation.Contains("Freiherr"))
            {
                customer.Nachname = salutation.Substring(salutation.IndexOf("Freiherr", StringComparison.OrdinalIgnoreCase));

                // Müller dient hier nur als Platzhalter, da der Nachname bereits erkannt wurde, aber möglicherweiße der Vorname durch die Bibiliothek gefunden werden muss 
                salutation = salutation.Replace(customer.Nachname, "Müller");
            }


            if (salutation.Contains(",") || salutation.Contains(" y "))
            {
                for (int i = 0; i < salutationArray.Length; i++)
                {
                    if (salutationArray[i].Contains(","))
                    {
                        customer.Nachname = salutationArray[i].Replace(",", "");
                        customer.Vorname = salutationArray[i + 1];
                        break;
                    }

                    // Spanischer doppelname mit y erkennen
                    if (salutationArray[i] == "y" && i > 0 && salutationArray.Length >= i + 1)
                    {
                        customer.Nachname = salutationArray[i - 1] + " " + salutationArray[i] + " " +
                                          salutationArray[i + 1];

                        salutation = salutation.Replace(customer.Nachname, string.Empty);
                    }
                }
            }

            return salutation;
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