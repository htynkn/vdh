namespace VideoDownloadHelper
{
    partial class ReadLicence
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadLicence));
            this.AgreeLicence = new System.Windows.Forms.Button();
            this.DisAgreeLicence = new System.Windows.Forms.Button();
            this.LicenceText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // AgreeLicence
            // 
            this.AgreeLicence.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AgreeLicence.Location = new System.Drawing.Point(85, 227);
            this.AgreeLicence.Name = "AgreeLicence";
            this.AgreeLicence.Size = new System.Drawing.Size(75, 23);
            this.AgreeLicence.TabIndex = 0;
            this.AgreeLicence.Text = "我同意";
            this.AgreeLicence.UseVisualStyleBackColor = true;
            this.AgreeLicence.Click += new System.EventHandler(this.AgreeLicence_Click);
            // 
            // DisAgreeLicence
            // 
            this.DisAgreeLicence.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DisAgreeLicence.Location = new System.Drawing.Point(214, 227);
            this.DisAgreeLicence.Name = "DisAgreeLicence";
            this.DisAgreeLicence.Size = new System.Drawing.Size(75, 23);
            this.DisAgreeLicence.TabIndex = 1;
            this.DisAgreeLicence.Text = "我拒绝";
            this.DisAgreeLicence.UseVisualStyleBackColor = true;
            // 
            // LicenceText
            // 
            this.LicenceText.Location = new System.Drawing.Point(13, 13);
            this.LicenceText.Name = "LicenceText";
            this.LicenceText.ReadOnly = true;
            this.LicenceText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.LicenceText.Size = new System.Drawing.Size(365, 208);
            this.LicenceText.TabIndex = 2;
            this.LicenceText.Text = "";
            // 
            // ReadLicence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 262);
            this.Controls.Add(this.LicenceText);
            this.Controls.Add(this.DisAgreeLicence);
            this.Controls.Add(this.AgreeLicence);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReadLicence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "使用必读";
            this.Load += new System.EventHandler(this.ReadLicence_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AgreeLicence;
        private System.Windows.Forms.Button DisAgreeLicence;
        private System.Windows.Forms.RichTextBox LicenceText;
    }
}