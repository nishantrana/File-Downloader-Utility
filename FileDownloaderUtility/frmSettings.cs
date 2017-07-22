using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileDownloaderUtility
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            ///This is a form used to save application properties settings
            InitializeComponent();

            /*Set file path to the Text Box*/
            txtBoxFilePath.Text = Properties.Settings.Default.DownloadFileLocation;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            /*Creating a FolderBrowserDialog to select folder to store downloaded files*/
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            
            // Show the FolderBrowserDialog.
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtBoxFilePath.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            //Check if file path textbox is null or empty or whitespace
            if (String.IsNullOrEmpty(txtBoxFilePath.Text) || String.IsNullOrWhiteSpace(txtBoxFilePath.Text))
            {
                //Show notification message
                MessageBox.Show("Enter the file path.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //Save textbox value in properties settings
                Properties.Settings.Default.DownloadFileLocation = txtBoxFilePath.Text.ToString();
                Properties.Settings.Default.Save();
                MessageBox.Show("Path saved successfully", "Successfull");
            }
        }
    }
}
