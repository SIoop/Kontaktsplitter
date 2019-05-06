using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Kontaktsplitter.Model;

namespace Kontaktsplitter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            ReloadComboboxContent();
        }

        private void ReloadComboboxContent()
        {
            List<Anrede> allSalutations;
            List<Titel> allTitels;
            using (var context = new DbAccess())
            {
                // TODO Table Content nicht jedes mal neu laden
                context.ReloadTableContent();

                allSalutations = context.Anreden.ToList();
                allTitels = context.Titel.ToList();
            }

            SalutationComboBox.Items.Clear();

            // Anrede Kombobox aus Db laden
            TitelComboBox.Items.Clear();
            foreach (var salutation in allSalutations)
            {
                SalutationComboBox.Items.Add(salutation.AnredeNormal);
            }

            // Titel Kombobox aus Db laden
            TitelComboBox.Items.Clear();
            foreach (var titel in allTitels)
            {
                TitelComboBox.Items.Add(titel.Kuerzel);
            }

            // Geschlechter Kombobox laden
            var genderList = new List<string>(new[] { "ohne", "weiblich", "männlich", "divers" });
            GenderComboBox.Items.Clear();
            foreach (var gender in genderList)
            {
                GenderComboBox.Items.Add(gender);
            }
        }

        private void OnConvertSalutationButtonClick(object sender, EventArgs e)
        {

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

            foreach (var salutation in allSalutations)
            {
                salutations.Add(salutation.AnredeNormal);
            }

            foreach (var titel in allTitels)
            {
                titels.Add(titel.Kuerzel);
            }

            var salutationEntry = ContactEntryTextBox.Text;
            var salutationEntryArray = salutationEntry.Split(' ');

            FindGender(salutationEntry);

            // Anrede nach verschiedenen bestandteilen bestimmen
            foreach (var salutationPart in salutationEntryArray)
            {
                if (salutations.Contains(salutationPart))
                {
                    SalutationComboBox.SelectedItem = salutationPart;
                }
            }

            // Titel herausfinden
            foreach (var salutationPart in salutationEntryArray)
            {
                // Mögliche Punkte entfernen
                var currentSal = salutationPart.TrimEnd(new[] { '.'});


                if (titels.Contains(currentSal))
                {
                    TitelComboBox.SelectedItem = currentSal;
                }
            }

            LastNameTextBox.Text = salutationEntryArray.Last();


        }

        private void FindGender(string salutationEntry)
        {
            // Geschlecht bestimmen
            if (Regex.IsMatch(salutationEntry, "(Frau\\.?\\s|Mrs\\.?\\s|Ms\\.?\\s|frau\\.?\\s)"))
            {
                GenderComboBox.SelectedItem = "weiblich";
            }
            else if (Regex.IsMatch(salutationEntry, "(Herr\\.?\\s|Herrn\\.?\\s|Mr\\.?\\s|M\\.?\\s)"))
            {
                GenderComboBox.SelectedItem = "männlich";
            }
            else
            {
                GenderComboBox.SelectedItem = "ohne";
            }
        }
    }
}
