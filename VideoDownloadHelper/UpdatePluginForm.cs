using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RestSharp;

namespace VideoDownloadHelper
{
    public partial class UpdatePluginForm : Form
    {
        public UpdatePluginForm()
        {
            InitializeComponent();
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (update.Text.Equals("升级"))
            {
                if (!updateWorker.IsBusy)
                {
                    this.Text = "取消";
                    updateWorker.RunWorkerAsync();
                }
            }
            else
            {
                updateWorker.CancelAsync();
                this.Text = "升级";
            }
        }

        private void updateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            updateWorker.ReportProgress((int)UpdateProgress.Start, "");
            var client = new RestClient();
            client.BaseUrl = "https://api.github.com";
            var request = new RestRequest("repos/htynkn/vdh/downloads", Method.GET);
            IRestResponse res = client.Execute(request);
            String con = res.Content;
        }

        private enum UpdateProgress { Start = 1, Getting, Download, Complete };
    }
}
