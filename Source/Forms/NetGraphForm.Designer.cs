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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetGraphForm));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dlRaw = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ulRaw = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dlAvg = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ulAvg = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolbox = new System.Windows.Forms.FlowLayoutPanel();
            this.close = new ScriptFUSION.UpDown_Meter.Controls.BilgeButton();
            this.minimize = new ScriptFUSION.UpDown_Meter.Controls.BilgeButton();
            this.topmost = new ScriptFUSION.UpDown_Meter.Controls.BilgeButton();
            this.transparent = new ScriptFUSION.UpDown_Meter.Controls.BilgeButton();
            this.reset = new ScriptFUSION.UpDown_Meter.Controls.BilgeButton();
            this.settings = new ScriptFUSION.UpDown_Meter.Controls.BilgeButton();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.verticalLabel1 = new ScriptFUSION.UpDown_Meter.Controls.VerticalLabel();
            this.samplerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.netGraph = new ScriptFUSION.UpDown_Meter.Controls.NetGraph();
            this.statusStrip1.SuspendLayout();
            this.toolbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.samplerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel7,
            this.dlRaw,
            this.toolStripStatusLabel2,
            this.ulRaw,
            this.toolStripStatusLabel3,
            this.dlAvg,
            this.toolStripStatusLabel4,
            this.ulAvg});
            this.statusStrip1.Location = new System.Drawing.Point(1, 82);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(312, 20);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(39, 15);
            this.toolStripStatusLabel7.Spring = true;
            this.toolStripStatusLabel7.Text = "DL Raw";
            this.toolStripStatusLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dlRaw
            // 
            this.dlRaw.Name = "dlRaw";
            this.dlRaw.Size = new System.Drawing.Size(39, 15);
            this.dlRaw.Spring = true;
            this.dlRaw.Text = "0";
            this.dlRaw.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(34, 15);
            this.toolStripStatusLabel2.Text = "UL Raw";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ulRaw
            // 
            this.ulRaw.Name = "ulRaw";
            this.ulRaw.Size = new System.Drawing.Size(39, 15);
            this.ulRaw.Spring = true;
            this.ulRaw.Text = "0";
            this.ulRaw.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(32, 15);
            this.toolStripStatusLabel3.Text = "DL Avg";
            this.toolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dlAvg
            // 
            this.dlAvg.Name = "dlAvg";
            this.dlAvg.Size = new System.Drawing.Size(39, 15);
            this.dlAvg.Spring = true;
            this.dlAvg.Text = "0";
            this.dlAvg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(32, 15);
            this.toolStripStatusLabel4.Text = "UL Avg";
            this.toolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ulAvg
            // 
            this.ulAvg.Name = "ulAvg";
            this.ulAvg.Size = new System.Drawing.Size(39, 15);
            this.ulAvg.Spring = true;
            this.ulAvg.Text = "0";
            this.ulAvg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolbox
            // 
            this.toolbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolbox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolbox.Controls.Add(this.close);
            this.toolbox.Controls.Add(this.minimize);
            this.toolbox.Controls.Add(this.topmost);
            this.toolbox.Controls.Add(this.transparent);
            this.toolbox.Controls.Add(this.reset);
            this.toolbox.Controls.Add(this.settings);
            this.toolbox.Location = new System.Drawing.Point(315, 1);
            this.toolbox.Name = "toolbox";
            this.toolbox.Size = new System.Drawing.Size(15, 102);
            this.toolbox.TabIndex = 7;
            // 
            // close
            // 
            this.close.Image = global::ScriptFUSION.UpDown_Meter.Properties.Resources.exit;
            this.close.Location = new System.Drawing.Point(1, 2);
            this.close.Margin = new System.Windows.Forms.Padding(1, 2, 1, 0);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(13, 13);
            this.close.TabIndex = 0;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // minimize
            // 
            this.minimize.Image = global::ScriptFUSION.UpDown_Meter.Properties.Resources.minimize;
            this.minimize.Location = new System.Drawing.Point(1, 16);
            this.minimize.Margin = new System.Windows.Forms.Padding(1);
            this.minimize.Name = "minimize";
            this.minimize.Size = new System.Drawing.Size(13, 13);
            this.minimize.TabIndex = 1;
            this.minimize.Click += new System.EventHandler(this.minimize_Click);
            // 
            // topmost
            // 
            this.topmost.Image = global::ScriptFUSION.UpDown_Meter.Properties.Resources.topmost;
            this.topmost.Location = new System.Drawing.Point(1, 31);
            this.topmost.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.topmost.Name = "topmost";
            this.topmost.Size = new System.Drawing.Size(13, 13);
            this.topmost.TabIndex = 2;
            this.topmost.ToggleButton = true;
            this.topmost.Click += new System.EventHandler(this.topmost_Click);
            // 
            // transparent
            // 
            this.transparent.Image = global::ScriptFUSION.UpDown_Meter.Properties.Resources.transparent;
            this.transparent.Location = new System.Drawing.Point(1, 45);
            this.transparent.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.transparent.Name = "transparent";
            this.transparent.Size = new System.Drawing.Size(13, 13);
            this.transparent.TabIndex = 3;
            this.transparent.ToggleButton = true;
            this.transparent.Click += new System.EventHandler(this.transparent_Click);
            // 
            // reset
            // 
            this.reset.Image = global::ScriptFUSION.UpDown_Meter.Properties.Resources.refresh;
            this.reset.Location = new System.Drawing.Point(1, 59);
            this.reset.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(13, 12);
            this.reset.TabIndex = 4;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // settings
            // 
            this.settings.Image = global::ScriptFUSION.UpDown_Meter.Properties.Resources.settings;
            this.settings.Location = new System.Drawing.Point(1, 72);
            this.settings.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(13, 13);
            this.settings.TabIndex = 4;
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // trayIcon
            // 
            this.trayIcon.Visible = true;
            this.trayIcon.Click += new System.EventHandler(this.trayIcon_Click);
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_Click);
            // 
            // verticalLabel1
            // 
            this.verticalLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.verticalLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.samplerBindingSource, "MaximumSpeed", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "0 B/s"));
            this.verticalLabel1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.verticalLabel1.Location = new System.Drawing.Point(4, 9);
            this.verticalLabel1.Name = "verticalLabel1";
            this.verticalLabel1.Size = new System.Drawing.Size(12, 60);
            this.verticalLabel1.TabIndex = 5;
            this.verticalLabel1.Text = "NIC speed";
            this.verticalLabel1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // samplerBindingSource
            // 
            this.samplerBindingSource.DataSource = typeof(ScriptFUSION.UpDown_Meter.NetworkInterfaceSampler);
            // 
            // netGraph
            // 
            this.netGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.netGraph.Location = new System.Drawing.Point(18, 8);
            this.netGraph.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.netGraph.Name = "netGraph";
            this.netGraph.Size = new System.Drawing.Size(289, 67);
            this.netGraph.TabIndex = 1;
            this.netGraph.Text = "netGraph1";
            this.netGraph.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NetGraphForm_MouseDown);
            this.netGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NetGraphForm_MouseMove);
            // 
            // NetGraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 104);
            this.Controls.Add(this.toolbox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.verticalLabel1);
            this.Controls.Add(this.netGraph);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NetGraphForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NetGraphForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NetGraphForm_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NetGraphForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NetGraphForm_MouseMove);
            this.Resize += new System.EventHandler(this.NetGraphForm_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.samplerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.NetGraph netGraph;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.BindingSource samplerBindingSource;
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
        private System.Windows.Forms.FlowLayoutPanel toolbox;
        private Controls.BilgeButton close;
        private Controls.BilgeButton minimize;
        private Controls.BilgeButton topmost;
        private Controls.BilgeButton transparent;
        private Controls.BilgeButton settings;
        private Controls.BilgeButton reset;
        private System.Windows.Forms.NotifyIcon trayIcon;
    }
}