using System;
using System.Linq;
using System.Windows.Forms;

namespace ScriptFUSION.UpDown_Meter {
    internal class UdmApplication : ApplicationContext {
        // It is paramount to hide the base property because the setter forces the form to be visible.
        public new Form MainForm { get; private set; }

        public UdmApplication(Form mainForm) {
            MainForm = mainForm;

            mainForm.FormClosed += delegate { ExitThread(); };
        }

        public static string ProductName
        {
            get { return Application.ProductName; }
        }

        public static string CanonicalProductVersion
        {
            get
            {
                return string.Join(".", Application.ProductVersion.Split('.').TakeWhile((s, i) => i < 3));
            }
        }
    }
}
