using System;
using System.Windows.Forms;
using Kontaktsplitter.Model;

namespace Kontaktsplitter
{
    /// <summary>
    /// Die AddTitelForm ermöglicht das Anlegen neue Titel
    /// </summary>
    public partial class AddTitelForm : Form
    {
        /// <summary>
        /// Der Konstruktor zur Initialisierung der Komponenten
        /// </summary>
        public AddTitelForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Speichert den neuen Titel in der DB
        /// </summary>
        /// <param name="sender">Das sender object</param>
        /// <param name="e">Die EventArgs e</param>
        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            // Falls keine Kundendaten eingegeben Fehler
            if (string.IsNullOrWhiteSpace(TitelTextBox.Text) || string.IsNullOrWhiteSpace(ShortTitelTextBox.Text))
            {
                MessageBox.Show(@"Bitte geben Sie zuerst einen vollständigen Titel ein.", @"Achtung", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            try
            {
                var titel = new Titel()
                {
                    Bezeichnung = TitelTextBox.Text,
                    Kuerzel = ShortTitelTextBox.Text
                };

                // neuer Titel in DB speichern
                DbAccess.SaveTitel(titel);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Es ist ein Fehler beim Speichern des Titels aufgetreten", @"Fehler",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nach erfolgreichem speichern kann das Fenster wieder geschlossen werden
            Close();
        }
    }
}
