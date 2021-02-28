using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Projet {
    /// <summary>
    /// This class creates a 'DeleteMovieWindow' form.
    /// It displays a list with CheckBoxes and title of the movies.
    /// </summary>
    public partial class DeleteMovieWindow : Form {
        private List<Tuple<PictureBox, Movie>> movieList;
        private List<string> checkedList = new List<string>();
        private MainWindow window;

        /// <summary>
        /// The main constructor.
        /// </summary>
        public DeleteMovieWindow() {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor of a DeleteMovieWindow.
        /// </summary>
        /// <param name="window">The main window.</param>
        public DeleteMovieWindow(MainWindow window) {
            this.window = window;
            movieList = window.getMovieList();
            InitializeComponent();
        }

        /// <summary>
        /// This method is loaded right after the constructor.
        /// It displays title of all the movies in a list with CheckedBoxes.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        private void DeleteMovieWindow_Load(object sender, EventArgs e) {
            int nbRows = 1;
            if (choicePanel.RowCount < movieList.Count) {
                for (int i = choicePanel.RowCount; i < movieList.Count; i++) {
                    choicePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
                }
                choicePanel.RowCount = movieList.Count;
            }
            foreach (Tuple<PictureBox, Movie> tuple in movieList) {
                CheckBox checkBox = new CheckBox();
                checkBox.Click += new System.EventHandler(this.checkBox_Clicked);
                checkBox.Tag = tuple.Item2.getTitle();
                lbl = new Label();
                lbl.AutoSize = true;
                lbl.Text = tuple.Item2.getTitle();
                choicePanel.Controls.Add(checkBox, 0, nbRows);
                choicePanel.Controls.Add(lbl, 1, nbRows++);
            }
        }

        /// <summary>
        /// Verifies the checked boxes.
        /// The checkedList contains all the checked movies to delete.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        private void checkBox_Clicked(object sender, EventArgs e) {
            CheckBox checkedBox = (CheckBox)sender;
            if (!checkedList.Contains(checkedBox.Tag.ToString())) {
                checkedList.Add(checkedBox.Tag.ToString());
            } else {
                checkedList.RemoveAt(checkedList.FindIndex(text => text.Equals(checkedBox.Tag)));
            }
        }

        /// <summary>
        /// This is the event handler of a click on the 'OK' button.
        /// When activated, it launches the removeMovies method and update the moviesPanel.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        private void okBtn_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Voulez-vous vraiment supprimer ce(s) film(s) ?", "Suppression de films",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result.ToString().Equals("Yes")) {
                removeMovies();
                window.updatePanel(movieList);
                window.setMovieList(movieList);
                window.saveInFile();
            }
            this.Close();
        }

        /// <summary>
        /// This is the event handler of a click on the 'Annuler' button.
        /// When clicked, it closes the window and doesn't remove any movie.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        private void cancelBtn_Click(object sender, EventArgs e) {
            this.Close();
        }

        /// <summary>
        /// The method removes all the movies of the checkedList.
        /// </summary>
        private void removeMovies() {
            if (checkedList.Count != 0) {
                foreach (string title in checkedList) {
                    removeMovie(title, false);
                }
            }
        }

        /// <summary>
        /// Removes the given movie.
        /// If the boolean is true, the moviesPanel is updated.
        /// </summary>
        /// <param name="title">The title of the movie to remove.</param>
        /// <param name="isRClick"></param>
        public void removeMovie(string title, bool isRClick) {
            int index = window.getIndex(movieList, title);
            movieList.ElementAt(index).Item1.Image.Dispose();
            if (!movieList.ElementAt(index).Item2.getCover().Equals("Resources\\covers\\NoCover.png")) {
                File.Delete(movieList.ElementAt(index).Item2.getCover());
            }
            movieList.RemoveAt(index);
            if (isRClick) {
                window.updatePanel(movieList);
                window.setMovieList(movieList);
                window.saveInFile();
            }
        }

    }
}
