namespace VideoDownloadHelper
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GetVideoList = new System.Windows.Forms.Button();
            this.TargetUrl = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.ClearAll = new System.Windows.Forms.Button();
            this.SelectAll = new System.Windows.Forms.Button();
            this.VideoInfoList = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VideoTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DownSelectItem = new System.Windows.Forms.Button();
            this.ExitProgram = new System.Windows.Forms.Button();
            this.getlistWorker = new System.ComponentModel.BackgroundWorker();
            this.updateChecker = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.currentVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.OfficeSite = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GetVideoList);
            this.groupBox1.Controls.Add(this.TargetUrl);
            this.groupBox1.Location = new System.Drawing.Point(13, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "地址";
            // 
            // GetVideoList
            // 
            this.GetVideoList.Location = new System.Drawing.Point(257, 20);
            this.GetVideoList.Name = "GetVideoList";
            this.GetVideoList.Size = new System.Drawing.Size(58, 23);
            this.GetVideoList.TabIndex = 1;
            this.GetVideoList.Text = "确认";
            this.GetVideoList.UseVisualStyleBackColor = true;
            this.GetVideoList.Click += new System.EventHandler(this.GetVideoList_Click);
            // 
            // TargetUrl
            // 
            this.TargetUrl.Location = new System.Drawing.Point(15, 22);
            this.TargetUrl.Name = "TargetUrl";
            this.TargetUrl.Size = new System.Drawing.Size(236, 21);
            this.TargetUrl.TabIndex = 0;
            this.TargetUrl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TargetUrl_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MessageLabel);
            this.groupBox2.Controls.Add(this.ClearAll);
            this.groupBox2.Controls.Add(this.SelectAll);
            this.groupBox2.Controls.Add(this.VideoInfoList);
            this.groupBox2.Location = new System.Drawing.Point(14, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 261);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "视频列表";
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.BackColor = System.Drawing.Color.Transparent;
            this.MessageLabel.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MessageLabel.Location = new System.Drawing.Point(60, 118);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(199, 24);
            this.MessageLabel.TabIndex = 4;
            this.MessageLabel.Text = "获取中...请等待";
            this.MessageLabel.Visible = false;
            // 
            // ClearAll
            // 
            this.ClearAll.Location = new System.Drawing.Point(81, 232);
            this.ClearAll.Name = "ClearAll";
            this.ClearAll.Size = new System.Drawing.Size(66, 23);
            this.ClearAll.TabIndex = 2;
            this.ClearAll.Text = "全不选";
            this.ClearAll.UseVisualStyleBackColor = true;
            this.ClearAll.Click += new System.EventHandler(this.ClearAll_Click);
            // 
            // SelectAll
            // 
            this.SelectAll.Location = new System.Drawing.Point(9, 232);
            this.SelectAll.Name = "SelectAll";
            this.SelectAll.Size = new System.Drawing.Size(66, 23);
            this.SelectAll.TabIndex = 1;
            this.SelectAll.Text = "全选";
            this.SelectAll.UseVisualStyleBackColor = true;
            this.SelectAll.Click += new System.EventHandler(this.SelectAll_Click);
            // 
            // VideoInfoList
            // 
            this.VideoInfoList.CheckBoxes = true;
            this.VideoInfoList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.VideoTime});
            this.VideoInfoList.Location = new System.Drawing.Point(9, 20);
            this.VideoInfoList.Name = "VideoInfoList";
            this.VideoInfoList.Size = new System.Drawing.Size(305, 206);
            this.VideoInfoList.TabIndex = 5;
            this.VideoInfoList.UseCompatibleStateImageBehavior = false;
            this.VideoInfoList.View = System.Windows.Forms.View.Details;
            // 
            // Title
            // 
            this.Title.Text = "视频名称";
            this.Title.Width = 197;
            // 
            // VideoTime
            // 
            this.VideoTime.Text = "视频时长";
            this.VideoTime.Width = 104;
            // 
            // DownSelectItem
            // 
            this.DownSelectItem.Location = new System.Drawing.Point(36, 353);
            this.DownSelectItem.Name = "DownSelectItem";
            this.DownSelectItem.Size = new System.Drawing.Size(75, 23);
            this.DownSelectItem.TabIndex = 2;
            this.DownSelectItem.Text = "开始下载";
            this.DownSelectItem.UseVisualStyleBackColor = true;
            this.DownSelectItem.Click += new System.EventHandler(this.DownSelectItem_Click);
            // 
            // ExitProgram
            // 
            this.ExitProgram.Location = new System.Drawing.Point(241, 353);
            this.ExitProgram.Name = "ExitProgram";
            this.ExitProgram.Size = new System.Drawing.Size(75, 23);
            this.ExitProgram.TabIndex = 2;
            this.ExitProgram.Text = "退出程序";
            this.ExitProgram.UseVisualStyleBackColor = true;
            this.ExitProgram.Click += new System.EventHandler(this.ExitProgram_Click);
            // 
            // getlistWorker
            // 
            this.getlistWorker.WorkerReportsProgress = true;
            this.getlistWorker.WorkerSupportsCancellation = true;
            this.getlistWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.getlistWorker_DoWork);
            this.getlistWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.getlistWorker_ProgressChanged);
            this.getlistWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.getlistWorker_RunWorkerCompleted);
            // 
            // updateChecker
            // 
            this.updateChecker.WorkerReportsProgress = true;
            this.updateChecker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updateChecker_DoWork);
            this.updateChecker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.updateChecker_ProgressChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentVersion,
            this.OfficeSite});
            this.statusStrip1.Location = new System.Drawing.Point(0, 384);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(344, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // currentVersion
            // 
            this.currentVersion.IsLink = true;
            this.currentVersion.Name = "currentVersion";
            this.currentVersion.Size = new System.Drawing.Size(273, 17);
            this.currentVersion.Spring = true;
            this.currentVersion.Text = "当前版本：V";
            this.currentVersion.Click += new System.EventHandler(this.currentVersion_Click);
            // 
            // OfficeSite
            // 
            this.OfficeSite.IsLink = true;
            this.OfficeSite.Name = "OfficeSite";
            this.OfficeSite.Size = new System.Drawing.Size(56, 17);
            this.OfficeSite.Text = "官方网站";
            this.OfficeSite.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OfficeSite.Click += new System.EventHandler(this.OfficeSite_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 406);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ExitProgram);
            this.Controls.Add(this.DownSelectItem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "土豆优酷视频批量下载助手";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button GetVideoList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ClearAll;
        private System.Windows.Forms.Button SelectAll;
        private System.Windows.Forms.Button DownSelectItem;
        private System.Windows.Forms.Button ExitProgram;
        protected internal System.Windows.Forms.TextBox TargetUrl;
        private System.Windows.Forms.ListView VideoInfoList;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader VideoTime;
        private System.ComponentModel.BackgroundWorker getlistWorker;
        private System.ComponentModel.BackgroundWorker updateChecker;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel currentVersion;
        private System.Windows.Forms.ToolStripStatusLabel OfficeSite;
    }
}

