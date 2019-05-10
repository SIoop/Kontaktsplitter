using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kontaktsplitter.Model;

namespace Kontaktsplitter
{
    public partial class AddTitelForm : Form
    {
        public AddTitelForm()
        {
            InitializeComponent();
        }

        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            try
            {
                var titel = new Titel()
                {
                    Bezeichnung = TitelTextBox.Text,
                    Kuerzel = ShortTitelTextBox.Text
                };

                DbAccess.SaveTitel(titel);
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Es ist ein Fehler beim Speichern des Titels aufgetreten", @"Fehler",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
            this.Close();


        }
    }
}
