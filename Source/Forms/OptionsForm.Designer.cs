namespace ScriptFUSION.UpDown_Meter {
    partial class OptionsForm {
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
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.apply = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.footer = new System.Windows.Forms.Panel();
            this.header = new System.Windows.Forms.PictureBox();
            this.pager = new ScriptFUSION.UpDown_Meter.Controls.PanelStack();
            this.networkingPage = new ScriptFUSION.UpDown_Meter.Controls.DockedPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.nics = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.showDisabledAdapters = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.copySpeed = new System.Windows.Forms.Button();
            this.detectedSpeed = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.customSpeed = new System.Windows.Forms.TextBox();
            this.optionsPage = new ScriptFUSION.UpDown_Meter.Controls.DockedPanel();
            this.options = new ScriptFUSION.UpDown_Meter.Controls.BilgeButton();
            this.networking = new ScriptFUSION.UpDown_Meter.Controls.BilgeButton();
            this.footer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.header)).BeginInit();
            this.pager.SuspendLayout();
            this.networkingPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ok.Location = new System.Drawing.Point(393, 14);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 5;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancel.Location = new System.Drawing.Point(474, 14);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // apply
            // 
            this.apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.apply.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.apply.Location = new System.Drawing.Point(555, 14);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(75, 23);
            this.apply.TabIndex = 7;
            this.apply.Text = "Apply";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // title
            // 
            this.title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.title.BackColor = System.Drawing.Color.White;
            this.title.Font = new System.Drawing.Font("Arial", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(309, 7);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(328, 42);
            this.title.TabIndex = 14;
            this.title.Text = "networking";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // footer
            // 
            this.footer.Controls.Add(this.options);
            this.footer.Controls.Add(this.networking);
            this.footer.Controls.Add(this.ok);
            this.footer.Controls.Add(this.cancel);
            this.footer.Controls.Add(this.apply);
            this.footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer.Location = new System.Drawing.Point(0, 334);
            this.footer.Name = "footer";
            this.footer.Size = new System.Drawing.Size(641, 50);
            this.footer.TabIndex = 15;
            this.footer.Paint += new System.Windows.Forms.PaintEventHandler(this.footer_Paint);
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.White;
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Image = global::ScriptFUSION.UpDown_Meter.Properties.Resources.UDM_banner;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(641, 55);
            this.header.TabIndex = 2;
            this.header.TabStop = false;
            // 
            // pager
            // 
            this.pager.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pager.Controls.Add(this.networkingPage);
            this.pager.Controls.Add(this.optionsPage);
            this.pager.Location = new System.Drawing.Point(0, 61);
            this.pager.Name = "pager";
            this.pager.Panels = new ScriptFUSION.UpDown_Meter.Controls.DockedPanel[] {
        this.networkingPage,
        this.optionsPage};
            this.pager.SelectedPanel = this.networkingPage;
            this.pager.Size = new System.Drawing.Size(641, 267);
            this.pager.TabIndex = 16;
            this.pager.Text = "panelStack1";
            // 
            // networkingPage
            // 
            this.networkingPage.Controls.Add(this.label1);
            this.networkingPage.Controls.Add(this.nics);
            this.networkingPage.Controls.Add(this.showDisabledAdapters);
            this.networkingPage.Controls.Add(this.label2);
            this.networkingPage.Controls.Add(this.copySpeed);
            this.networkingPage.Controls.Add(this.detectedSpeed);
            this.networkingPage.Controls.Add(this.label3);
            this.networkingPage.Controls.Add(this.customSpeed);
            this.networkingPage.Location = new System.Drawing.Point(0, 0);
            this.networkingPage.Name = "networkingPage";
            this.networkingPage.Size = new System.Drawing.Size(641, 267);
            this.networkingPage.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Network adapters";
            // 
            // nics
            // 
            this.nics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.nics.FullRowSelect = true;
            this.nics.GridLines = true;
            this.nics.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.nics.HideSelection = false;
            this.nics.Location = new System.Drawing.Point(12, 24);
            this.nics.MultiSelect = false;
            this.nics.Name = "nics";
            this.nics.Size = new System.Drawing.Size(617, 163);
            this.nics.TabIndex = 13;
            this.nics.UseCompatibleStateImageBehavior = false;
            this.nics.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Speed (bit/s)";
            this.columnHeader3.Width = 77;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Down (B)";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Up (B)";
            // 
            // showDisabledAdapters
            // 
            this.showDisabledAdapters.AutoSize = true;
            this.showDisabledAdapters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showDisabledAdapters.Location = new System.Drawing.Point(12, 193);
            this.showDisabledAdapters.Name = "showDisabledAdapters";
            this.showDisabledAdapters.Size = new System.Drawing.Size(136, 17);
            this.showDisabledAdapters.TabIndex = 15;
            this.showDisabledAdapters.Text = "Show disabled adapters";
            this.showDisabledAdapters.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Reported speed (B/s)";
            // 
            // copySpeed
            // 
            this.copySpeed.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.copySpeed.Location = new System.Drawing.Point(309, 238);
            this.copySpeed.Name = "copySpeed";
            this.copySpeed.Size = new System.Drawing.Size(20, 20);
            this.copySpeed.TabIndex = 20;
            this.copySpeed.Text = ">";
            // 
            // detectedSpeed
            // 
            this.detectedSpeed.Location = new System.Drawing.Point(193, 238);
            this.detectedSpeed.Name = "detectedSpeed";
            this.detectedSpeed.ReadOnly = true;
            this.detectedSpeed.Size = new System.Drawing.Size(106, 20);
            this.detectedSpeed.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Actual speed (B/s)";
            // 
            // customSpeed
            // 
            this.customSpeed.Location = new System.Drawing.Point(339, 238);
            this.customSpeed.Name = "customSpeed";
            this.customSpeed.Size = new System.Drawing.Size(108, 20);
            this.customSpeed.TabIndex = 19;
            // 
            // optionsPage
            // 
            this.optionsPage.Location = new System.Drawing.Point(0, 0);
            this.optionsPage.Name = "optionsPage";
            this.optionsPage.Size = new System.Drawing.Size(641, 267);
            this.optionsPage.TabIndex = 1;
            // 
            // options
            // 
            this.options.FreezeOnSelect = true;
            this.options.Image = global::ScriptFUSION.UpDown_Meter.Properties.Resources.options;
            this.options.Location = new System.Drawing.Point(43, 14);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(24, 24);
            this.options.TabIndex = 9;
            this.options.Text = "more options";
            this.options.Click += new System.EventHandler(this.pagingButton_Click);
            // 
            // networking
            // 
            this.networking.FreezeOnSelect = true;
            this.networking.Frozen = true;
            this.networking.Image = global::ScriptFUSION.UpDown_Meter.Properties.Resources.network_adapter;
            this.networking.Location = new System.Drawing.Point(13, 14);
            this.networking.Name = "networking";
            this.networking.Selected = true;
            this.networking.Size = new System.Drawing.Size(24, 24);
            this.networking.TabIndex = 8;
            this.networking.Text = "networking";
            this.networking.Click += new System.EventHandler(this.pagingButton_Click);
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(641, 384);
            this.Controls.Add(this.pager);
            this.Controls.Add(this.title);
            this.Controls.Add(this.header);
            this.Controls.Add(this.footer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpDown Meter - Options";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OptionsForm_Paint);
            this.footer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.header)).EndInit();
            this.pager.ResumeLayout(false);
            this.networkingPage.ResumeLayout(false);
            this.networkingPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox header;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel footer;
        private Controls.PanelStack pager;
        private Controls.DockedPanel networkingPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView nics;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.CheckBox showDisabledAdapters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button copySpeed;
        private System.Windows.Forms.TextBox detectedSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox customSpeed;
        private Controls.DockedPanel optionsPage;
        private Controls.BilgeButton networking;
        private Controls.BilgeButton options;
    }
}

