using System;
using System.Windows.Forms;

namespace NganHangPhanTan
{
    static class Program
    {
        public static fMain fMain;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            fMain = new fMain();
            Application.Run(fMain);
        }
    }
}
