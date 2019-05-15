using System;
using System.Windows.Forms;

namespace Kontaktsplitter
{
    /// <summary>
    /// Die Program Klasse ist der Start der Anwendung.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The Einstiegspunkt der Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Starten der MainForm
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                var message = e.Message;
                if (e.InnerException != null)
                {
                    message += "\n" + e.InnerException.Message;
                }
                MessageBox.Show(message, @"Es ist ein Fehler aufgetreten.", MessageBoxButtons.OK);
            }

        }
    }
}
