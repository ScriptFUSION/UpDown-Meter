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
            this.nics = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.PictureBox();
            this.showDisabledAdapters = new System.Windows.Forms.CheckBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.apply = new System.Windows.Forms.Button();
            this.detectedSpeed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.customSpeed = new System.Windows.Forms.TextBox();
            this.copySpeed = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.header)).BeginInit();
            this.SuspendLayout();
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
            this.nics.Location = new System.Drawing.Point(12, 82);
            this.nics.MultiSelect = false;
            this.nics.Name = "nics";
            this.nics.Size = new System.Drawing.Size(617, 163);
            this.nics.TabIndex = 0;
            this.nics.UseCompatibleStateImageBehavior = false;
            this.nics.View = System.Windows.Forms.View.Details;
            this.nics.SelectedIndexChanged += new System.EventHandler(this.nics_SelectedIndexChanged);
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
            this.columnHeader3.Text = "Speed";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Down";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Up";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Network adapters";
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
            // showDisabledAdapters
            // 
            this.showDisabledAdapters.AutoSize = true;
            this.showDisabledAdapters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showDisabledAdapters.Location = new System.Drawing.Point(12, 251);
            this.showDisabledAdapters.Name = "showDisabledAdapters";
            this.showDisabledAdapters.Size = new System.Drawing.Size(136, 17);
            this.showDisabledAdapters.TabIndex = 3;
            this.showDisabledAdapters.Text = "Show disabled adapters";
            this.showDisabledAdapters.UseVisualStyleBackColor = true;
            this.showDisabledAdapters.CheckedChanged += new System.EventHandler(this.showDisabledAdapters_CheckedChanged);
            // 
            // ok
            // 
            this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ok.Location = new System.Drawing.Point(392, 358);
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
            this.cancel.Location = new System.Drawing.Point(473, 358);
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
            this.apply.Location = new System.Drawing.Point(554, 358);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(75, 23);
            this.apply.TabIndex = 7;
            this.apply.Text = "Apply";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // detectedSpeed
            // 
            this.detectedSpeed.Location = new System.Drawing.Point(12, 296);
            this.detectedSpeed.Name = "detectedSpeed";
            this.detectedSpeed.ReadOnly = true;
            this.detectedSpeed.Size = new System.Drawing.Size(106, 20);
            this.detectedSpeed.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Detected speed (bps)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Set connection speed";
            // 
            // customSpeed
            // 
            this.customSpeed.Location = new System.Drawing.Point(158, 296);
            this.customSpeed.Name = "customSpeed";
            this.customSpeed.Size = new System.Drawing.Size(108, 20);
            this.customSpeed.TabIndex = 11;
            // 
            // copySpeed
            // 
            this.copySpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.copySpeed.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.copySpeed.Location = new System.Drawing.Point(128, 296);
            this.copySpeed.Name = "copySpeed";
            this.copySpeed.Size = new System.Drawing.Size(20, 20);
            this.copySpeed.TabIndex = 12;
            this.copySpeed.Text = ">";
            this.copySpeed.Click += new System.EventHandler(this.copySpeed_Click);
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(641, 393);
            this.Controls.Add(this.copySpeed);
            this.Controls.Add(this.customSpeed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.detectedSpeed);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.showDisabledAdapters);
            this.Controls.Add(this.header);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nics);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpDown Meter - Options";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OptionsForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.header)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView nics;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox header;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.CheckBox showDisabledAdapters;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.TextBox detectedSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox customSpeed;
        private System.Windows.Forms.Button copySpeed;
    }
}

