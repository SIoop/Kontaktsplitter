using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Kontaktsplitter.Model;

namespace Kontaktsplitter.Parser
{
    public class SalutationParser
    {
        public Kunde Parse(string salutation)
        {
            var result = new Kunde();
            var salutations = new List<string>();
            var titels = new List<string>();

            List<Anrede> allSalutations;
            List<Titel> allTitels;
            using (var context = new DbAccess())
            {
                context.ReloadTableContent();

                ////Get the existing calculations from the db
                //var initialCustomers = context.Kunden.ToList();

                //Kunde k1 = new Kunde("Frau", "Sehr geehrte Frau", "", "w", "Sandra", "Berger")
                //{
                //    Id = !initialCustomers.Any() ? 1 : initialCustomers.Max(x => x.Id) + 1,
                //};

                ////Add the new Calculation to the context
                //context.Kunden.Add(k1);

                //And save it to the db
                context.SaveChanges();

                //Get all the calculations again from the db (our new Calculation should be there)
                allSalutations = context.Anreden.ToList();
                allTitels = context.Titel.ToList();
            }

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