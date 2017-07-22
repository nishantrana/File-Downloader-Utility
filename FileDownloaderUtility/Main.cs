using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileDownloaderUtility.Modules;

namespace FileDownloaderUtility
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Call About Form
            frmAbout _frmAbout = new frmAbout();
            _frmAbout.ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Call Setting Form
            frmSettings _frmSetting = new frmSettings();
            _frmSetting.ShowDialog();
        }

        private void btnHTTPDownload_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBoxHTTPUrl.Text) || String.IsNullOrWhiteSpace(txtBoxHTTPUrl.Text))
            {
                MessageBox.Show("Please enter valid HTTP URL","Alert",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            //This design is following Singleton Design Pattern
            try
            {
                FilesOverHTTP.Instance.DownloadFile(txtBoxHTTPUrl.Text.ToString(), Properties.Settings.Default.DownloadFileLocation);
                txtBoxHTTPUrl.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in InitializeFileDownload",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }        
    }
}
