namespace ScriptFUSION.UpDown_Meter.Controls {
    partial class NetGraph {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.pulse = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // pulse
            // 
            this.pulse.Interval = 40;
            this.pulse.Tick += new System.EventHandler(this.pulse_Tick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer pulse;
    }
}
