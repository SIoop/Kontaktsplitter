using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Kontaktsplitter.Model;
using Kontaktsplitter.Parser;

namespace Kontaktsplitter
{
    public partial class MainForm : Form
    {
        private Kunde _currentCustomer = new Kunde();
        public MainForm()
        {
            InitializeComponent();

            ReloadComboboxContent();
        }

        private void ReloadComboboxContent()
        {
            DbAccess.ReloadTableContent();
            var allSalutations = DbAccess.GetAnreden();
            var allTitels = DbAccess.GetTitels();


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
                TitelComboBox.Items.AddRange(titels.Take(5).ToArray() as string[]);
            }
            catch (Exception)
            {
                // Falls Take 5 nicht möglich, bleibt die Liste der Titel leer
            }

            // Geschlechter Kombobox laden
            var genderList = new List<string>(new[]
            {
                Geschlecht.Ohne.ToString(), Geschlecht.Divers.ToString(),
                Geschlecht.Weiblich.ToString(), Geschlecht.Männlich.ToString()
            });
            GenderComboBox.Items.Clear();
            GenderComboBox.Items.AddRange(genderList.ToArray() as string[]);

        }

        private void OnConvertSalutationButtonClick(object sender, EventArgs e)
        {
            _currentCustomer = new SalutationParser().Parse(ContactEntryTextBox.Text);
            SalutationComboBox.Text = _currentCustomer.Anrede;
            LetterSalutationTextBox.Text = _currentCustomer.Briefanrede;
            TitelComboBox.Text = _currentCustomer.Titel;
            LastNameTextBox.Text = _currentCustomer.Nachname;
            FirstNameTextBox.Text = _currentCustomer.Vorname;
            GenderComboBox.SelectedItem = _currentCustomer.Geschlecht.ToString();
        }

        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            DbAccess.SaveCustomer(_currentCustomer);

            // TODO entfernen
            var Kunden = DbAccess.GetKunden();
        }

        private void OnAddTitelButtonClick(object sender, EventArgs e)
        {
            using (var titelForm = new AddTitelForm())
            {
                titelForm.ShowDialog(this);
            }
        }

        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
