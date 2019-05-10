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
            NameParserLogic parser = new NameParserLogic();
            NameParts parts = parser.ParseName(salutation,NameOrder.AutoDetect);
            var geschlecht = "ohne";
            if (parts.IsMale == true)
            {
                geschlecht = "männlich";
            }
            else if (parts.IsMale == false)
            {
                geschlecht = "weiblich";
            }
            

            return new Kunde()
            {
                Nachname = parts.LastName,
                Titel = parts.Honorific,
                Vorname = parts.FirstName,
                Geschlecht = geschlecht
            };

            //return ManualCustomerAssignment(salutation);
        }

        private Kunde ManualCustomerAssignment(string salutation)
        {
            var result = new Kunde();
            var salutations = new List<string>();
            var titels = new List<string>();

            List<Anrede> allSalutations;
            List<Titel> allTitels;

            DbAccess.ReloadTableContent();

            allSalutations = DbAccess.GetAnreden();
            allTitels = DbAccess.GetTitels();

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
                    result.Titel = currentSal;
                }
            }

            result.Nachname = salutationEntryArray.Last();

            return result;
        }


        private string FindGender(string salutation)
        {
            // Geschlecht bestimmen
            if (Regex.IsMatch(salutation, "(Frau\\.?\\s|Mrs\\.?\\s|Ms\\.?\\s|frau\\.?\\s)"))
            {
                return "weiblich";
            }
            else if (Regex.IsMatch(salutation, "(Herr\\.?\\s|Herrn\\.?\\s|Mr\\.?\\s|M\\.?\\s)"))
            {
                return "männlich";
            }
            else
            {
                return "ohne";
            }
        }
    }
}