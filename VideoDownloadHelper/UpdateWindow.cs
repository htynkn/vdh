using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VideoDownloadHelper
{
	public partial class UpdateWindow: Form
	{
        private String[] updateInfo;

        public UpdateWindow(String[] updateInfo)
		{
            this.updateInfo = updateInfo;
			InitializeComponent();
		}

        private void UpdateWindow_Load(object sender, EventArgs e)
        {
            version.Text = version.Text + updateInfo[0];
            number.Text = number.Text + updateInfo[1];
            desiption.Text = updateInfo[2];
        }

        private void noVersion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void downNewVersion_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(updateInfo[3]);
        }
	}
}
