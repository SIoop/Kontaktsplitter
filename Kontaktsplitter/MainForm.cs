using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Kontaktsplitter.Model;
using Kontaktsplitter.Parser;

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
            var kunde = new SalutationParser().Parse(ContactEntryTextBox.Text);
            SalutationComboBox.SelectedItem = kunde.Anrede;
            TitelComboBox.SelectedItem = kunde.Titel;
            LastNameTextBox.Text = kunde.Nachname;
            FirstNameTextBox.Text = kunde.Vorname;
            GenderComboBox.SelectedItem = kunde.Geschlecht;
        }
    }
}
