using System;
using System.IO;
using System.Windows.Forms;

namespace Projet {

    /// <summary>
    /// This class creates a 'HelpWebBrowser' form.
    /// It displays 'Readme.html' file in a new window.
    /// </summary>
    public partial class HelpWebBrowser : Form {
        
        /// <summary>
        /// This is the main constructor.
        /// </summary>
        public HelpWebBrowser() {
            InitializeComponent();
        }

        /// <summary>
        /// This method is loaded right after the constructor.
        /// It load the file into the web browser.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        private void HelpWebBrowser_Load(object sender, EventArgs e) {
            this.webBrowser.Url = new Uri(String.Format("file:///{0}/Resources/Readme.html", Directory.GetCurrentDirectory()));
        }
    }
}
