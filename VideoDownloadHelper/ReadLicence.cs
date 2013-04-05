using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace VideoDownloadHelper
{
    public partial class ReadLicence : Form
    {
        public ReadLicence()
        {
            InitializeComponent();
        }

        private void ReadLicence_Load(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("Licence.txt"))
            {
                LicenceText.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void AgreeLicence_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.isAgree = true;
            Properties.Settings.Default.Save();
        }
    }
}
