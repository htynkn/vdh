namespace VideoDownloadHelper
{
    partial class UpdateWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateWindow));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.downNewVersion = new System.Windows.Forms.Button();
            this.noVersion = new System.Windows.Forms.Button();
            this.version = new System.Windows.Forms.Label();
            this.number = new System.Windows.Forms.Label();
            this.desiption = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.desiption);
            this.groupBox1.Controls.Add(this.version);
            this.groupBox1.Controls.Add(this.number);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 187);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "版本信息";
            // 
            // downNewVersion
            // 
            this.downNewVersion.Location = new System.Drawing.Point(39, 206);
            this.downNewVersion.Name = "downNewVersion";
            this.downNewVersion.Size = new System.Drawing.Size(75, 23);
            this.downNewVersion.TabIndex = 0;
            this.downNewVersion.Text = "下载新版本";
            this.downNewVersion.UseVisualStyleBackColor = true;
            this.downNewVersion.Click += new System.EventHandler(this.downNewVersion_Click);
            // 
            // noVersion
            // 
            this.noVersion.Location = new System.Drawing.Point(195, 206);
            this.noVersion.Name = "noVersion";
            this.noVersion.Size = new System.Drawing.Size(75, 23);
            this.noVersion.TabIndex = 1;
            this.noVersion.Text = "不升级";
            this.noVersion.UseVisualStyleBackColor = true;
            this.noVersion.Click += new System.EventHandler(this.noVersion_Click);
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Location = new System.Drawing.Point(6, 26);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(41, 12);
            this.version.TabIndex = 2;
            this.version.Text = "版本：";
            // 
            // number
            // 
            this.number.AutoSize = true;
            this.number.Location = new System.Drawing.Point(6, 48);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(53, 12);
            this.number.TabIndex = 3;
            this.number.Text = "内部号：";
            // 
            // desiption
            // 
            this.desiption.Location = new System.Drawing.Point(6, 67);
            this.desiption.Name = "desiption";
            this.desiption.ReadOnly = true;
            this.desiption.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.desiption.Size = new System.Drawing.Size(271, 114);
            this.desiption.TabIndex = 4;
            this.desiption.Text = "";
            // 
            // UpdateWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 241);
            this.Controls.Add(this.downNewVersion);
            this.Controls.Add(this.noVersion);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "版本升级";
            this.Load += new System.EventHandler(this.UpdateWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button downNewVersion;
        private System.Windows.Forms.Button noVersion;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.Label number;
        private System.Windows.Forms.RichTextBox desiption;
    }
}