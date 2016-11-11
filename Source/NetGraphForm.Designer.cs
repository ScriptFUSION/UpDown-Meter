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
            this.minimize = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dlRaw = new System.Windows.Forms.ToolStripStatusLabel();
            this.ulRaw = new System.Windows.Forms.ToolStripStatusLabel();
            this.dlAvg = new System.Windows.Forms.ToolStripStatusLabel();
            this.ulAvg = new System.Windows.Forms.ToolStripStatusLabel();
            this.verticalLabel1 = new ScriptFUSION.UpDown_Meter.Controls.VerticalLabel();
            this.netGraphBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.netGraph = new ScriptFUSION.UpDown_Meter.NetGraph();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netGraphBindingSource)).BeginInit();
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
            // minimize
            // 
            this.minimize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.minimize.Location = new System.Drawing.Point(495, 41);
            this.minimize.Name = "minimize";
            this.minimize.Size = new System.Drawing.Size(75, 23);
            this.minimize.TabIndex = 3;
            this.minimize.Text = "_";
            this.minimize.UseVisualStyleBackColor = true;
            this.minimize.Click += new System.EventHandler(this.minimize_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel7,
            this.dlRaw,
            this.toolStripStatusLabel2,
            this.ulRaw,
            this.toolStripStatusLabel3,
            this.dlAvg,
            this.toolStripStatusLabel4,
            this.ulAvg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 152);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(582, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(46, 17);
            this.toolStripStatusLabel2.Text = "UL Raw";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(45, 17);
            this.toolStripStatusLabel3.Text = "DL Avg";
            this.toolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(45, 17);
            this.toolStripStatusLabel4.Text = "UL Avg";
            this.toolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabel7.Spring = true;
            this.toolStripStatusLabel7.Text = "DL Raw";
            this.toolStripStatusLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dlRaw
            // 
            this.dlRaw.Name = "dlRaw";
            this.dlRaw.Size = new System.Drawing.Size(80, 17);
            this.dlRaw.Spring = true;
            this.dlRaw.Text = "0";
            this.dlRaw.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ulRaw
            // 
            this.ulRaw.Name = "ulRaw";
            this.ulRaw.Size = new System.Drawing.Size(80, 17);
            this.ulRaw.Spring = true;
            this.ulRaw.Text = "0";
            this.ulRaw.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dlAvg
            // 
            this.dlAvg.Name = "dlAvg";
            this.dlAvg.Size = new System.Drawing.Size(80, 17);
            this.dlAvg.Spring = true;
            this.dlAvg.Text = "0";
            this.dlAvg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ulAvg
            // 
            this.ulAvg.Name = "ulAvg";
            this.ulAvg.Size = new System.Drawing.Size(80, 17);
            this.ulAvg.Spring = true;
            this.ulAvg.Text = "0";
            this.ulAvg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // verticalLabel1
            // 
            this.verticalLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.netGraphBindingSource, "MaximumSpeed", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "0 bps"));
            this.verticalLabel1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.verticalLabel1.Location = new System.Drawing.Point(12, 12);
            this.verticalLabel1.Name = "verticalLabel1";
            this.verticalLabel1.Size = new System.Drawing.Size(14, 128);
            this.verticalLabel1.TabIndex = 5;
            this.verticalLabel1.Text = "NIC speed";
            this.verticalLabel1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // netGraphBindingSource
            // 
            this.netGraphBindingSource.DataSource = typeof(ScriptFUSION.UpDown_Meter.NetGraph);
            // 
            // netGraph
            // 
            this.netGraph.Location = new System.Drawing.Point(32, 12);
            this.netGraph.MaximumSpeed = ((long)(0));
            this.netGraph.Name = "netGraph";
            this.netGraph.Size = new System.Drawing.Size(457, 128);
            this.netGraph.TabIndex = 1;
            this.netGraph.Text = "netGraph1";
            this.netGraph.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NetGraphForm_MouseDown);
            this.netGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NetGraphForm_MouseMove);
            // 
            // NetGraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 174);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.verticalLabel1);
            this.Controls.Add(this.minimize);
            this.Controls.Add(this.close);
            this.Controls.Add(this.netGraph);
            this.Controls.Add(this.settings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NetGraphForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NetGraphForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NetGraphForm_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NetGraphForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NetGraphForm_MouseMove);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netGraphBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button settings;
        private NetGraph netGraph;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button minimize;
        private System.Windows.Forms.BindingSource netGraphBindingSource;
        private Controls.VerticalLabel verticalLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel dlRaw;
        private System.Windows.Forms.ToolStripStatusLabel ulRaw;
        private System.Windows.Forms.ToolStripStatusLabel dlAvg;
        private System.Windows.Forms.ToolStripStatusLabel ulAvg;
    }
}