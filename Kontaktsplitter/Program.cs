using System;
using System.Windows.Forms;

namespace Kontaktsplitter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
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
