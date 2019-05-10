using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Kontaktsplitter.Model;
using Kontaktsplitter.Parser;

namespace Kontaktsplitter
{
    public partial class MainForm : Form
    {
        private Kunde currentCustomer = new Kunde();
        public MainForm()
        {
            InitializeComponent();

            ReloadComboboxContent();
        }

        private void ReloadComboboxContent()
        {
            List<Anrede> allSalutations;
            List<Titel> allTitels;

            DbAccess.ReloadTableContent();
            allSalutations = DbAccess.GetAnreden();
            allTitels = DbAccess.GetTitels();


            SalutationComboBox.Items.Clear();

            // Anrede Kombobox aus Db laden
            foreach (var salutation in allSalutations)
            {
                SalutationComboBox.Items.Add(salutation.AnredeNormal);


            }

            // Titel Kombobox aus Db laden
            var titels = allTitels.Select(titel => titel.Kuerzel).ToList();
            var autoCompleteCollection = new AutoCompleteStringCollection();

            autoCompleteCollection.AddRange(titels.ToArray());

            TitelComboBox.AutoCompleteCustomSource = autoCompleteCollection;

            TitelComboBox.Items.Clear();

            try
            {
                TitelComboBox.Items.AddRange(titels.Take(5).ToArray());
            }
            catch (Exception)
            {
                // Falls Take 5 nicht möglich, bleibt die Liste der Titel leer
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
            currentCustomer = new SalutationParser().Parse(ContactEntryTextBox.Text);
            SalutationComboBox.SelectedItem = currentCustomer.Anrede;
            TitelComboBox.SelectedItem = currentCustomer.Titel;
            LastNameTextBox.Text = currentCustomer.Nachname;
            FirstNameTextBox.Text = currentCustomer.Vorname;
            GenderComboBox.SelectedItem = currentCustomer.Geschlecht;
        }

        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            DbAccess.SaveCustomer(currentCustomer);

            var Kunden = DbAccess.GetKunden();
        }

        private void OnAddTitelButtonClick(object sender, EventArgs e)
        {
            using (var titelForm = new AddTitelForm())
            {
                titelForm.ShowDialog(this);
            }
        }
    }
}
