using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Projet {
    [Serializable()]
    /// <summary>
    /// This class creates a 'MainWindow' form.
    /// It displays the contained movies of the library,
    /// and the user can add and remove them or create and delete libraries.
    /// </summary>
    public partial class MainWindow : Form {
        private bool modif = false;
        private int nbMovies = 0, nbRow = 0;
        private string savedFile, libraryName;
        private Movie currentMovie;
        private List<Tuple<PictureBox, Movie>> movieList = new List<Tuple<PictureBox, Movie>>();

        /// <summary>
        /// This is the main constructor.
        /// </summary>
        public MainWindow() {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor of a MainWindow.
        /// It takes a backup file and use it.
        /// </summary>
        /// <param name="savedFile">A backup of the wanted library.</param>
        public MainWindow(string savedFile) {
            this.savedFile = savedFile;
            InitializeComponent();
        }

        /// <summary>
        /// Constructor of a MainWindow.
        /// It takes a name and backup file and use them.
        /// </summary>
        /// <param name="libraryName">The name of the library.</param>
        /// <param name="savedFile">A backup of the wanted library.</param>
        public MainWindow(string libraryName, string savedFile) {
            this.libraryName = libraryName;
            this.savedFile = savedFile;
            InitializeComponent();
        }

        /// <summary>
        /// This method is loaded right after the constructor.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        private void Window_Load(object sender, EventArgs e) {
            loadFile();
        }

        /// <summary>
        /// This is the event handler of a click on the 'Modifier' button.
        /// When activated, it displays the 'Ajouter' and 'Supprimer' buttons.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        private void modifBtn_Click(object sender, EventArgs e) {
            if (!modif) {
                addBtn.Show();
                delBtn.Show();
                modif = true;
            } else {
                addBtn.Hide();
                delBtn.Hide();
                modif = false;
            }
        }

        /// <summary>
        /// This is the event handler when the text changes in the searchbar.
        /// When text is entered, the corresponding movies are showned.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        private void searchBox_TextChanged(object sender, EventArgs e) {
            TextBox objTextBox = (TextBox)sender;
            List<Tuple<PictureBox, Movie>> searchList = new List<Tuple<PictureBox, Movie>>();
            foreach (Tuple<PictureBox, Movie> tuple in movieList) {
                if (tuple.Item2.contains(objTextBox.Text)) {
                    searchList.Add(tuple);
                }
                updatePanel(searchList);
            }
        }

        /// <summary>
        /// This is the event handler of a click on the searchbar.
        /// When clicked, the text is selected and it's removed when typing.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        private void searchBox_Click(object sender, EventArgs e) {
            searchBox.SelectionStart = 0;
            searchBox.SelectionLength = searchBox.Text.Length;
        }

        /// <summary>
        /// This is the event handler of a click on the 'Aide' button.
        /// When activated, it opens the 'Readme.html' file in the default browser.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        private void helpBtn_Click(object sender, EventArgs e) {
            HelpWebBrowser helpBrowser = new HelpWebBrowser();
            helpBrowser.Show();
        }

        /// <summary>
        /// This is the event handler of a click on the 'Créer bibliothèque' button.
        /// When activated, it opens a 'DialogWindow' to create a new library.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        private void newBibBtn_Click(object sender, EventArgs e) {
            DialogWindow dW = new DialogWindow(this);
            this.Hide();
            dW.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// This is the event handler of a click on the 'Supprimer bibliothèque' button.
        /// When activated, it closes the current window and deletes the current library.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        private void delBibBtn_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Voulez-vous vraiment supprimer cette bibliothèque ?", "Suppression de la bibliothèque",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result.ToString().Equals("Yes")) {
                Close();
                foreach (Tuple<PictureBox, Movie> tuple in movieList) {
                    tuple.Item1.Image.Dispose();
                }
                string coverDir = "Resources\\Covers\\" + libraryName + "\\";
                if (Directory.Exists(coverDir)) {
                    Directory.Delete(coverDir, true);
                }

                File.Delete("Resources\\libraries\\" + libraryName + ".ibib");
                System.Diagnostics.Process.Start(Application.ExecutablePath);
            }
        }

        /// <summary>
        /// This is the event handler of a click on the 'Ajouter' button.
        /// When activated, it displays a 'MovieDisplayWindow' to create a new Movie.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        private void addBtn_Click(object sender, EventArgs e) {
            MovieDisplayWindow win = new MovieDisplayWindow(this);
            win.Show();
        }

        /// <summary>
        /// This is the event handler of a click on the 'Supprimer' button.
        /// When clicked, it opens a 'DeleteMovieWindow' to choose the movies to delete.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        private void delBtn_Click(object sender, EventArgs e) {
            DeleteMovieWindow delWin = new DeleteMovieWindow(this);
            delWin.Show();
        }

        /// <summary>
        /// This is the event handler of a click on the 'Réinitialiser' button.
        /// When activated, it removes all the movies from the library.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        private void reset_Click(object sender, EventArgs e) {
            foreach (Tuple<PictureBox, Movie> tuple in movieList) {
                tuple.Item1.Image.Dispose();
            }
            Directory.Delete("Resources\\Covers\\" + libraryName + "\\", true);
            Directory.CreateDirectory("Resources\\Covers\\" + libraryName + "\\");
            modif = false;
            nbMovies = 0;
            nbRow = 0;
            movieList = new List<Tuple<PictureBox, Movie>>();
            addBtn.Hide();
            delBtn.Hide();
            saveInFile();
            File.Delete(savedFile);
            System.IO.StreamWriter file = new StreamWriter(savedFile);
            file.WriteLine("Name " + libraryName);
            file.Close();
            moviesPanel.Visible = false;
            moviesPanel.Controls.Clear();
            moviesPanel.Visible = true;
        }

        /// <summary>
        /// Gets the movie list.
        /// </summary>
        /// <returns>The movie list.</returns>
        public List<Tuple<PictureBox, Movie>> getMovieList() {
            return movieList;
        }

        /// <summary>
        /// Sets the movie list.
        /// </summary>
        /// <param name="movieList">The movie list.</param>
        public void setMovieList(List<Tuple<PictureBox, Movie>> movieList) {
            this.movieList = movieList;
        }

        /// <summary>
        /// This method adds the mouse events on a PictureBox.
        /// If it's a left click, the chosen movie is displayed by a 'MovieDisplayWindow'.
        /// Else if it's a right click, the chosen movie is deleted.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        private void control_RightMouseClick(object sender, MouseEventArgs e) {
            if (sender.GetType().IsSubclassOf(typeof(Control))) {
                Control formControl = (Control)sender;
                currentMovie = movieList.ElementAt(getIndex(movieList, formControl.Name)).Item2;
            }
            if (e.Button == MouseButtons.Left) {
                MovieDisplayWindow win = new MovieDisplayWindow(this, currentMovie);
                win.Show();
            } else if (e.Button == MouseButtons.Right) {
                DeleteMovieWindow delWin = new DeleteMovieWindow(this);
                delWin.removeMovie(currentMovie.getTitle(), true);
                delWin.Close();
            }
        }

        /// <summary>
        /// Adds the cover to the movie and a mouse event handler to the linked movie.
        /// </summary>
        /// <param name="mov">The movie to add to the movie list.</param>
        public void addPicture(Movie mov) {
            PictureBox picBox = new PictureBox();
            picBox.Name = mov.getTitle();
            if (!File.Exists(mov.getCover())) {
                mov.setCover("Resources\\covers\\NoCover.png");
            }
            FileStream image = new FileStream(mov.getCover(), FileMode.Open, FileAccess.Read);
            picBox.Image = System.Drawing.Image.FromStream(image);
            image.Close();
            picBox.Width = 100;
            picBox.Height = 150;
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox.MouseClick += new MouseEventHandler(control_RightMouseClick);
            addAndSortMovie(new Tuple<PictureBox, Movie>(picBox, mov));
        }

        /// <summary>
        /// This method adds the movie to the list and its sorted by date.
        /// </summary>
        /// <param name="tuple">The tuple to add to the list.</param>
        private void addAndSortMovie(Tuple<PictureBox, Movie> tuple) {
            bool isInList = false;
            for(int index = 0; index < movieList.Count; index++) {
                if(isOlder(tuple.Item2.getDate(), movieList[index].Item2.getDate())) {
                    movieList.Insert(index, tuple);
                    isInList = true;
                    break;
                }
            }
            if(!isInList) {
                movieList.Add(tuple);
            }
            updatePanel(movieList);
        }

        /// <summary>
        /// This method returns if the movie to add is older than the tested movie.
        /// </summary>
        /// <param name="dateToAdd">The movie to add.</param>
        /// <param name="dateToTest">The tested movie from the list.</param>
        /// <returns>true if it's older, false otherwise.</returns>
        private bool isOlder(string dateToAdd, string dateToTest) {
            int date1 = 0, date2 = 0;
            Int32.TryParse(dateToAdd.Substring(6, 4) + dateToAdd.Substring(3, 2) + dateToAdd.Substring(0, 2), out date1);
            Int32.TryParse(dateToTest.Substring(6, 4) + dateToTest.Substring(3, 2) + dateToTest.Substring(0, 2), out date2);
            return (date1 <= date2);
        }

        /// <summary>
        /// Updates the 'moviesPanel' when needed.
        /// If a movie is added or removed, the movie list is updated then it's displayed.
        /// Else if it's a search, the movies which contains the text are displayed.
        /// </summary>
        /// <param name="listOfMovies">The list of movies to display.</param>
        public void updatePanel(List<Tuple<PictureBox, Movie>> listOfMovies) {
            nbMovies = 0;
            nbRow = 0;
            moviesPanel.Visible = false;
            moviesPanel.Controls.Clear();
            moviesPanel.Visible = true;
            foreach (Tuple<PictureBox, Movie> tuple in listOfMovies) {
                nbMovies++;
                if (nbMovies % 4 == 0) {
                    moviesPanel.RowCount = moviesPanel.RowCount++;
                    moviesPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
                    moviesPanel.Controls.Add(tuple.Item1, 3, nbRow);
                    nbRow++;
                } else if (nbMovies % 4 == 1) {
                    moviesPanel.Controls.Add(tuple.Item1, 0, nbRow);
                } else if (nbMovies % 4 == 2) {
                    moviesPanel.Controls.Add(tuple.Item1, 1, nbRow);
                } else {
                    moviesPanel.Controls.Add(tuple.Item1, 2, nbRow);
                }
            }
        }

        /// <summary>
        /// Returns the index of the movie with the given title in the list.
        /// </summary>
        /// <param name="list">The list of movies.</param>
        /// <param name="title">The title of the wanted movie.</param>
        /// <returns>The index of the wanted movie.</returns>
        public int getIndex(List<Tuple<PictureBox, Movie>> list, string title) {
            for (int i = 0; i < list.Count; i++) {
                if (list[i].Item2.getTitle().Equals(title)) {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Saves the movie list in the backup file.
        /// </summary>
        public void saveInFile() {
            try {
                int i = movieList.Count;
                Tuple<PictureBox, Movie>[] obj = new Tuple<PictureBox, Movie>[i];
                movieList.CopyTo(obj, 0);
                i = obj.Length;

                using (System.IO.StreamWriter file = new StreamWriter(savedFile))
                    foreach (Tuple<PictureBox, Movie> line in obj) {
                        line.Item2.writeToFile(file);
                    }

            } catch (Exception exp) {
                MessageBox.Show("" + exp);
            }
        }

        /// <summary>
        /// Load the backup file of the library.
        /// </summary>
        private void loadFile() {
            string line;
            bool isMovie = false;
            int nbItem = 0;
            Movie movie = new Movie();
            try {
                System.IO.StreamReader file = new StreamReader(savedFile);
                while ((line = file.ReadLine()) != null) {
                    if (!isMovie && line.Equals("BeginMovieInfos")) {
                        movie = new Movie();
                        isMovie = true;
                    } else if (isMovie && !line.Equals("EndMovieInfos")) {
                        movie.addItem(line, nbItem++);
                    } else if (line.Equals("EndMovieInfos")) {
                        addPicture(movie);
                        nbItem = 0;
                        isMovie = false;
                    }
                }
                file.Close();
            } catch (Exception exp) {
                MessageBox.Show("" + exp);
            }
        }

        /// <summary>
        /// Gets the library name.
        /// </summary>
        /// <returns>The library name.</returns>
        public string getLibraryName() {
            return libraryName;
        }

    }
}
