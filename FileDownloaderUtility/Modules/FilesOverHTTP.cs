using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileDownloaderUtility.Modules
{
    /// <summary>
    /// Written by Nishant Rana
    /// Email : nishant.rana25@gmail.com
    ///
    /// This class is used to download file over HTTP
    /// </summary>
    public class FilesOverHTTP
    {
        private static FilesOverHTTP _filesOverHTTP = new FilesOverHTTP();
        private WebClient wc;

        public static FilesOverHTTP Instance
        {
            // Note: this is thread safe.
            get
            {
                return _filesOverHTTP;
            }
        }

        /// <summary>
        /// FilesOverHTTP class constructor
        /// Webclient class object has been initialized in this constructor
        /// </summary>
        private FilesOverHTTP()
        {
            wc = new WebClient();
        }

        /// <summary>
        /// This method is used to download file over HTTP
        /// </summary>
        /// <param name="uri">Enter file address location</param>
        public void DownloadFile(string uri, string filePath)
        {   
            ///Convert string uri to uri object
            Uri _uri = new Uri(uri);

            ///Get filename from uri string
            string FileName = uri.Substring(uri.LastIndexOf("/") + 1, (uri.Length - uri.LastIndexOf("/") - 1));
            
            ///Add event for download file completed so that dowload event will not block main thread
            wc.DownloadFileCompleted += wc_DownloadFileCompleted;
            wc.DownloadFileAsync(_uri, filePath + @"\" + FileName);
        }

        /// <summary>
        /// Event raised after download file completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //Check if webclient throw any error
            //If any error occurs than first condition will be true and show error in Message
            //Otherwise show successfully message 
            if (e.Error != null)
                MessageBox.Show(e.Error.Message, "Downloading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                MessageBox.Show("File Download Successfully","Successfull");
            }
        }
    }
}
