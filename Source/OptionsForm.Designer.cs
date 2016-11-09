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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
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
            this.nics.Size = new System.Drawing.Size(617, 232);
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
            this.showDisabledAdapters.Location = new System.Drawing.Point(12, 320);
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
            this.ok.Location = new System.Drawing.Point(392, 339);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 5;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(473, 339);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(554, 339);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Apply";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 374);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

