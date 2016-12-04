using System;
using System.Windows.Forms;

namespace ScriptFUSION.UpDown_Meter {
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UdmApplication(new NetGraphForm()));
        }
    }
}
