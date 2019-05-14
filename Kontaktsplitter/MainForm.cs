using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Kontaktsplitter.Model;
using Kontaktsplitter.Parser;

namespace Kontaktsplitter
{
    /// <summary>
    /// Das MainForm ist der Haupteinstiegspunkt der Anwendung. Von hier aus wird die Logik aufgerufen und die Nutzereingaben bearbeitet.
    /// </summary>
    public partial class MainForm : Form
    {
        private Kunde _currentCustomer = new Kunde();

        /// <summary>
        /// Der Konstruktor zur Initialisierung der Komponenten
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            ReloadComboboxContent();
        }

        /// <summary>
        /// Läd den Inhalt der Comboboxen neu
        /// </summary>
        private void ReloadComboboxContent()
        {
            // DbAccess.ReloadTableContent();
            var allSalutations = DbAccess.GetSalutation();
            var allTitels = DbAccess.GetTitels();


            SalutationComboBox.Items.Clear();

            // Anrede Kombobox aus Db laden
            foreach (var salutation in allSalutations)
            {
                SalutationComboBox.Items.Add(salutation.AnredeNormal);
            }

            // Titel Kombobox aus Db laden und Seperate Vollständige Lise für Auto-Complete
            var titels = allTitels.Select(titel => titel.Kuerzel).ToList();
            var autoCompleteCollection = new AutoCompleteStringCollection();

            autoCompleteCollection.AddRange(titels.ToArray());

            TitelComboBox.AutoCompleteCustomSource = autoCompleteCollection;

            TitelComboBox.Items.Clear();

            try
            {
                TitelComboBox.Items.AddRange(titels.Take(5).ToArray<object>());
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
            GenderComboBox.Items.AddRange(genderList.ToArray<object>());

        }

        /// <summary>
        ///  Startet das Konvertieren der Anrede in der SalutationParser Klasse und schreibt das Ergebnis in die entsprechenden Felder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnConvertSalutationButtonClick(object sender, EventArgs e)
        {
            _currentCustomer = new SalutationParser().StartParser(ContactEntryTextBox.Text);
            SalutationComboBox.Text = _currentCustomer.Anrede;
            LetterSalutationTextBox.Text = _currentCustomer.Briefanrede;
            TitelComboBox.Text = _currentCustomer.Titel;
            LastNameTextBox.Text = _currentCustomer.Nachname;
            FirstNameTextBox.Text = _currentCustomer.Vorname;
            GenderComboBox.SelectedItem = _currentCustomer.Geschlecht.ToString();
        }
        /// <summary>
        /// Speichert den Kunden in der DB
        /// </summary>
        /// <param name="sender">Das sender object</param>
        /// <param name="e">Die EventArgs e</param>
        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            DbAccess.SaveCustomer(_currentCustomer);
        }

        /// <summary>
        /// Öffnet das AddTitelForm
        /// </summary>
        /// <param name="sender">Das sender object</param>
        /// <param name="e">Die EventArgs e</param>
        private void OnAddTitelButtonClick(object sender, EventArgs e)
        {
            using (var titelForm = new AddTitelForm())
            {
                titelForm.ShowDialog(this);
            }
        }

        /// <summary>
        /// Schließt die Anwendung
        /// </summary>
        /// <param name="sender">Das sender object</param>
        /// <param name="e">Die EventArgs e</param>
        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Update Briefanrede beim verlassen der TextBox
        /// </summary>
        /// <param name="sender">Das sender object</param>
        /// <param name="e">Die EventArgs e</param>
        private void OnLetterSalutationTextBoxLeave(object sender, EventArgs e)
        {
            _currentCustomer.Briefanrede = LetterSalutationTextBox.Text;
        }

        /// <summary>
        /// Update Anrede beim verlassen der CoboBox
        /// </summary>
        /// <param name="sender">Das sender object</param>
        /// <param name="e">Die EventArgs e</param>
        private void OnSalutationComboBoxLeave(object sender, EventArgs e)
        {
            _currentCustomer.Anrede = SalutationComboBox.Text;
        }

        /// <summary>
        /// Update Titel beim verlassen der ComoBox
        /// </summary>
        /// <param name="sender">Das sender object</param>
        /// <param name="e">Die EventArgs e</param>
        private void OnTitelComboBoxLeave(object sender, EventArgs e)
        {
            _currentCustomer.Titel = TitelComboBox.Text;
        }

        /// <summary>
        /// Update Geschlecht beim verlassen der Comobox
        /// </summary>
        /// <param name="sender">Das sender object</param>
        /// <param name="e">Die EventArgs e</param>
        private void OnGenderComboBoxLeave(object sender, EventArgs e)
        {
            _currentCustomer.Geschlecht = GeschlechtHelper.GetGeschlecht(GenderComboBox.Text);
        }

        /// <summary>
        /// Update Vorname beim verlassen der TextBox
        /// </summary>
        /// <param name="sender">Das sender object</param>
        /// <param name="e">Die EventArgs e</param>
        private void OnFirstNameTextBoxLeave(object sender, EventArgs e)
        {
            _currentCustomer.Vorname = FirstNameTextBox.Text;
        }

        /// <summary>
        /// Update Nachname beim verlassen der TextBox
        /// </summary>
        /// <param name="sender">Das sender object</param>
        /// <param name="e">Die EventArgs e</param>
        private void OnLastNameTextBoxLeave(object sender, EventArgs e)
        {
            _currentCustomer.Nachname = LastNameTextBox.Text;
        }
    }
}
