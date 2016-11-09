namespace ScriptFUSION.UpDown_Meter {
    partial class NetGraphForm {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.settings = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.netGraph = new ScriptFUSION.UpDown_Meter.NetGraph();
            this.SuspendLayout();
            // 
            // settings
            // 
            this.settings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.settings.Location = new System.Drawing.Point(495, 117);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(75, 23);
            this.settings.TabIndex = 0;
            this.settings.Text = "Settings";
            this.settings.UseVisualStyleBackColor = true;
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // close
            // 
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.close.Location = new System.Drawing.Point(495, 12);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 2;
            this.close.Text = "X";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // netGraph
            // 
            this.netGraph.Location = new System.Drawing.Point(12, 12);
            this.netGraph.MaximumSample = ((long)(0));
            this.netGraph.Name = "netGraph";
            this.netGraph.Size = new System.Drawing.Size(479, 121);
            this.netGraph.TabIndex = 1;
            this.netGraph.Text = "netGraph1";
            this.netGraph.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NetGraphForm_MouseDown);
            this.netGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NetGraphForm_MouseMove);
            // 
            // NetGraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 152);
            this.Controls.Add(this.close);
            this.Controls.Add(this.netGraph);
            this.Controls.Add(this.settings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NetGraphForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NetGraphForm";
            this.TopMost = true;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NetGraphForm_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NetGraphForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NetGraphForm_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button settings;
        private NetGraph netGraph;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Timer timer;
    }
}