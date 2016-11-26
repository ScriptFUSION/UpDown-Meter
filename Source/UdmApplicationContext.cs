using System;
using System.Linq;
using System.Windows.Forms;

namespace ScriptFUSION.UpDown_Meter {
    internal class UdmApplicationContext : ApplicationContext {
        // It is paramount to hide the base property because the setter forces the form to be visible.
        public new Form MainForm { get; private set; }

        public UdmApplicationContext(Form mainForm) {
            MainForm = mainForm;

            mainForm.FormClosed += delegate { ExitThread(); };
        }
    }
}
