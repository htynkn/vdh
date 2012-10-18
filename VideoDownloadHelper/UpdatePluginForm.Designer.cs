namespace VideoDownloadHelper
{
    partial class UpdatePluginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdatePluginForm));
            this.pluginBox = new System.Windows.Forms.GroupBox();
            this.update = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.updateWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // pluginBox
            // 
            this.pluginBox.Location = new System.Drawing.Point(13, 13);
            this.pluginBox.Name = "pluginBox";
            this.pluginBox.Size = new System.Drawing.Size(344, 172);
            this.pluginBox.TabIndex = 0;
            this.pluginBox.TabStop = false;
            this.pluginBox.Text = "插件升级";
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(62, 199);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 23);
            this.update.TabIndex = 1;
            this.update.Text = "升级";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(218, 199);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 2;
            this.exit.Text = "退出";
            this.exit.UseVisualStyleBackColor = true;
            // 
            // updateWorker
            // 
            this.updateWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updateWorker_DoWork);
            // 
            // UpdatePluginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 234);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.update);
            this.Controls.Add(this.pluginBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdatePluginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "插件升级";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox pluginBox;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button exit;
        private System.ComponentModel.BackgroundWorker updateWorker;
    }
}