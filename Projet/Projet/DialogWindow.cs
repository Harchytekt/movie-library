using System;
using System.IO;
using System.Windows.Forms;

namespace Projet {
    /// <summary>
    /// This class creates a 'DialogWindow' form.
    /// It offers the user to choose a library name or enter a backup file name.
    /// </summary>
    public partial class DialogWindow : Form {
        private bool chooseName = true;
        private string[] fileList;
        private string selectedName = "Votre texte";
        private MainWindow window;

        /// <summary>
        /// This is the main constructor.
        /// </summary>
        public DialogWindow() {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor of a DialogWindow.
        /// </summary>
        /// <param name="window">the main window.</param>
        public DialogWindow(MainWindow window) {
            this.window = window;
            InitializeComponent();
        }

        /// <summary>
        /// Constructor of a DialogWindow
        /// </summary>
        /// <param name="fileList">The list of existing libraries.</param>
        public DialogWindow(string[] fileList) {
            chooseName = false;
            this.fileList = fileList;
            InitializeComponent();
        }

        /// <summary>
        /// This method offers the user to :
        /// - enter a name for a new library;
        /// - choose an existing library from the list.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        private void DialogWindow_Load(object sender, EventArgs e) {
            if (chooseName) {
                Text = "Choisissez un nom";
                label.Text = "Veuillez saisir un nom: ";
                fileNameBox.Visible = true;
                libraryBox.Visible = false;
            } else {
                Text = "Choisissez une bibliothèque";
                label.Text = "Veuillez choisir une bibliothèque:";
                fileNameBox.Visible = false;
                libraryBox.Visible = true;
                initComboBox();
            }
        }

        /// <summary>
        /// This is the event handler of a click on the 'OK' button.
        /// When activated, it :
        /// - creates a new library;
        /// - opens the chosen library.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        private void okBtn_Click(object sender, EventArgs e) {
            MainWindow mainWindow;
            string path = "Resources\\libraries\\" + selectedName + ".ibib";
            if (chooseName) {
                string coverDir = "Resources\\Covers\\" + selectedName + "\\";
                if (!Directory.Exists(coverDir)) {
                    Directory.CreateDirectory(coverDir);
                }

                if (File.Exists(selectedName)) {
                    MessageBox.Show("Ce fichier existe déjà !", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                } else {
                    System.IO.StreamWriter newFile = new StreamWriter(path);
                    newFile.Dispose();
                }
            }
            mainWindow = new MainWindow(selectedName, path);
            this.Hide();
            mainWindow.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Initializes the combobox containing the library list.
        /// </summary>
        private void initComboBox() {
            foreach (string file in fileList) {
                libraryBox.Items.Add(file.Substring(20, file.Length - 25));
            }
            libraryBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Saves the chosen library.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        private void libraryBox_SelectedIndexChanged(object sender, EventArgs e) {
            selectedName = libraryBox.SelectedItem.ToString();
        }

        /// <summary>
        /// Verifies if the given name for the backup file is good:
        /// it can't be empty, a space or containing a dot '.'.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        private void fileNameBox_TextChanged(object sender, EventArgs e) {
            TextBox objTextBox = (TextBox)sender;
            selectedName = objTextBox.Text;
            if (selectedName.Equals("") || selectedName.Equals(" ") || selectedName.Contains(".")) {
                MessageBox.Show("Le nom ne doit être une chaîne de charactères non vide et sans '.' !", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                objTextBox.Text = "Votre texte";
            }
        }

    }
}
