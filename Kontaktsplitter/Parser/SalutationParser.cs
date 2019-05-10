using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using KellermanSoftware.NameParser;
using Kontaktsplitter.Model;

namespace Kontaktsplitter.Parser
{
    public class SalutationParser
    {
        public Kunde Parse(string salutation)
        {
            var manualCheckedCustomer = ManualCustomerAssignment(salutation);

            // Falls geschlecht gefunden soll Frau/Herr entfernt werden, da 
            // sonst probleme mit der genutzen Bibiliothek auftreten können
            if (manualCheckedCustomer.Geschlecht == Geschlecht.Männlich)
            {
                salutation = Regex.Replace(salutation, "(Herr\\.?\\s|Herrn\\.?\\s|Mr\\.?\\s|M\\.?\\s)", "");
            }
            if (manualCheckedCustomer.Geschlecht == Geschlecht.Weiblich)
            {
                salutation = Regex.Replace(salutation, "(Frau\\.?\\s|Mrs\\.?\\s|Ms\\.?\\s|frau\\.?\\s)", "");
            }

            NameParserLogic parser = new NameParserLogic();
            NameParts parts = parser.ParseName(salutation,NameOrder.AutoDetect);
            Geschlecht geschlecht = manualCheckedCustomer.Geschlecht;
            var anrede = " ";
            var briefanrede = "Sehr geehrte Damen und Herren";

            //if(manualCheckedCustomer.Geschlecht)

            if (parts.IsMale == true)
            {
                geschlecht = Geschlecht.Männlich;
                anrede = "Herrn";
                briefanrede = "Sehr geehrter Herr";
            }
            else if (parts.IsMale == false)
            {
                geschlecht = Geschlecht.Weiblich;
                anrede = "Frau";
                briefanrede = "Sehr geehrte Frau";
            }


            // Falls durch manuellen Vergleich Titel gefunden wurden diese verwednen. Sonst NameParser Bibiliothek
            var titel = manualCheckedCustomer.Titel;
            if (string.IsNullOrWhiteSpace(titel))
            {
                titel = parts.Honorific;
            }

            if (titel != null)
            {
                anrede += " " + titel;
                briefanrede += " " + titel;
            }


            return new Kunde()
            {
                Nachname = parts.LastName,
                Titel = titel,
                Vorname = parts.FirstName,
                Geschlecht = geschlecht,
                Anrede = anrede,
                Briefanrede = briefanrede
            };

            
        }

        private Kunde ManualCustomerAssignment(string salutation)
        {
            var result = new Kunde();
            var salutations = new List<string>();
            var titels = new List<string>();

            DbAccess.ReloadTableContent();

            var allSalutations = DbAccess.GetAnreden();
            var allTitels = DbAccess.GetTitels();

            foreach (var sal in allSalutations)
            {
                salutations.Add(sal.AnredeNormal);
            }

            foreach (var titel in allTitels)
            {
                titels.Add(titel.Kuerzel);
            }

            var salutationEntryArray = salutation.Split(' ');

            result.Geschlecht = FindGender(salutation);

            // Anrede nach verschiedenen bestandteilen bestimmen
            foreach (var salutationPart in salutationEntryArray)
            {
                if (salutations.Contains(salutationPart))
                {
                    result.Anrede = salutationPart;
                }
            }

            // Titel herausfinden
            foreach (var salutationPart in salutationEntryArray)
            {
                // Mögliche Punkte entfernen
                var currentSal = salutationPart.TrimEnd('.');


                if (titels.Contains(currentSal))
                {
                    result.Titel += currentSal + " ";
                }
            }
            
            return result;
        }


        private Geschlecht FindGender(string salutation)
        {
            // Geschlecht bestimmen
            if (Regex.IsMatch(salutation, "(Frau\\.?\\s|Mrs\\.?\\s|Ms\\.?\\s|frau\\.?\\s)"))
            {
                return Geschlecht.Weiblich;
            }
            else if (Regex.IsMatch(salutation, "(Herr\\.?\\s|Herrn\\.?\\s|Mr\\.?\\s|M\\.?\\s)"))
            {
                return Geschlecht.Männlich;
            }
            else
            {
                return Geschlecht.Ohne;
            }
        }
    }
}