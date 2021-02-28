using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Projet {
    [Serializable()]
    /// <summary>
    /// This class creates a 'MovieDisplayWindow' form.
    /// It displays the informations of the chosen movie
    /// like the title, the plot,...
    /// </summary>
    public partial class MovieDisplayWindow : Form {
        private bool isAddingMovie = false, modifMovie = false;
        private string title = "", director = "", gender = "", plot = "", coverPath = "";
        private string date = DateTime.Now.ToString("dd/MM/yyyy");
        private string cover = "Resources\\covers\\NoCover.png";
        private List<string> forbiddenChar = new List<string>() { "\\", "/", ":", "*", "?", "\"", "<", ">", "|" };
        private Movie movie;
        private MainWindow window;
        private List<Tuple<PictureBox, Movie>> movieList;

        /// <summary>
        /// This is the main constructor.
        /// </summary>
        public MovieDisplayWindow() {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor of a MovieDisplayWindow.
        /// It initializes the movie list and the 'isAddingMovie' boolean variable.
        /// </summary>
        /// <param name="window">The main window.</param>
        public MovieDisplayWindow(MainWindow window) {
            InitializeComponent();
            isAddingMovie = true;
            initWindow();
            this.window = window;
            movieList = window.getMovieList();
        }

        /// <summary>
        /// Constructor of a MovieDisplayWindow.
        /// It initializes the movie list, the 'isAddingMovie' boolean variable
        /// and the chosen movie.
        /// </summary>
        /// <param name="window">The main window.</param>
        /// <param name="movie">The movie to display.</param>
        public MovieDisplayWindow(MainWindow window, Movie movie) {
            InitializeComponent();
            this.movie = movie;
            initWindow();
            this.window = window;
            movieList = window.getMovieList();
        }

        /// <summary>
        /// Initializes the movie.
        /// There are two kind of MovieDisplay forms:
        /// - the form when the user is adding a new movie;
        /// - the form when the user watch the chosen movie or modifies it.
        /// </summary>
        public void initWindow() {
            if (isAddingMovie) {
                this.Text = "Nouveau film";
                modifyMovieBtn.Visible = false;
                saveModifBtn.Visible = true;
                browseBtn.Enabled = true;
            } else {
                modifyMovieBtn.Visible = true;
                saveModifBtn.Visible = false;
                setTextsBoxes(!isAddingMovie);
                title = movie.getTitle();
                titleBox.Text = title;
                this.Text = title;
                director = movie.getDirector();
                dirBox.Text = director;
                date = movie.getDate();
                datePicker.Value = Convert.ToDateTime(date);
                gender = movie.getGender();
                genderBox.Text = gender;
                cover = movie.getCover();
                coverPathBox.Text = cover;
                plot = movie.getPlot();
                plotBox.Text = plot;
            }
        }

        /// <summary>
        /// This is the event handler of the 'Sauvegarder' button.
        /// It saves all the changes in the list and in the backup file.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        private void saveModifBtn_Click(object sender, EventArgs e) {
            string folderCover = "Resources\\Covers\\" + window.getLibraryName() + "\\";
            if (string.IsNullOrWhiteSpace(title)) { // if title contains letter/number
                MessageBox.Show("Veuillez entrer un titre !", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            } else if (!modifMovie && titleAlreadyExists()) {
                MessageBox.Show("Ce titre existe déjà !", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            } else {
                if (modifMovie) {
                    string previousTitle = movie.getTitle();
                    movie.setTitle(title);
                    movie.setDirector(director);
                    movie.setDate(date);
                    movie.setGender(gender);
                    if (coverPath.Contains(folderCover)) {
                        MessageBox.Show("Vous ne pouvez pas prendre une image de ce dossier !", "Erreur",
                            MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    } else if (!coverPath.Equals("")) {
                        // If cover changed
                        getpictureBox().Image.Dispose();
                        copyCover();
                    } else if (!title.Equals(previousTitle)) {
                        // If title changed
                        coverPath = movie.getCover();
                        cover = setPathToCover();
                        changeCoverName();
                    }
                    movie.setCover(cover);
                    movie.setPlot(plot);
                    modifMovie = false;
                    PictureBox picBox = getpictureBox();
                    movieList.RemoveAt(window.getIndex(movieList, title));
                    window.addPicture(movie);
                    movieList = window.getMovieList();
                } else {
                    movie = new Movie(title, director, date, gender, plot);
                    window.addPicture(movie);
                    if (coverPath.Contains(folderCover)) {
                        MessageBox.Show("Vous ne pouvez pas prendre une image de ce dossier !", "Erreur",
                            MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    } else if (!coverPath.Equals("")) {
                        copyCover();
                    }
                    movie.setCover(cover);
                }
                getpictureBox().Image = Image.FromFile(movie.getCover());
            }
            window.saveInFile();
            this.Close();
        }

        /// <summary>
        /// This is the event handler of the 'Modifier' button.
        /// It enables the change of all the values of the movie.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        private void modifyMovieBtn_Click(object sender, EventArgs e) {
            saveModifBtn.Visible = true;
            modifyMovieBtn.Visible = false;
            setTextsBoxes(false);
            modifMovie = true;
            title = movie.getTitle();
            director = movie.getDirector();
            date = movie.getDate();
            gender = movie.getGender();
            cover = movie.getCover();
            plot = movie.getPlot();
        }

        /// <summary>
        /// This is the event handler of the DatePicker object.
        /// When the date is updated, the date of the movie is changed.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        private void datePicker_ValueChanged(object sender, EventArgs e) {
            date = datePicker.Value.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// This is the event handler of the 'Chercher' button.
        /// It opens an OpenFileDIalog form to choose a cover image for the movie.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        private void browseBtn_Click(object sender, EventArgs e) {
            OpenFileDialog fileDial = new OpenFileDialog();
            fileDial.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            fileDial.ShowDialog();
            coverPath = fileDial.FileName.ToString();
            coverPathBox.Text = coverPath;
        }

        /// <summary>
        /// Initializes the textboxes, the date picker and the search button
        /// from the given boolea.n
        /// </summary>
        /// <param name="isReadOnly">The boolean enables or disables the textboxes, the date picker and the search button.</param>
        private void setTextsBoxes(bool isReadOnly) {
            titleBox.ReadOnly = isReadOnly;
            dirBox.ReadOnly = isReadOnly;
            datePicker.Enabled = !isReadOnly;
            genderBox.ReadOnly = isReadOnly;
            plotBox.ReadOnly = isReadOnly;
            browseBtn.Enabled = !isReadOnly;
        }

        /// <summary>
        /// This is the event handler when the text changes in the textboxes.
        /// When the textbox is changed, the corresponding value of the movie is updated.
        /// </summary>
        /// <param name="sender">References the object that raised the event.</param>
        /// <param name="e">Represents the data related to that event.</param>
        public void txtBox_TextChanged(object sender, EventArgs e) {
            TextBox objTextBox = (TextBox)sender;
            switch (objTextBox.Name) {
                case "titleBox":
                    title = objTextBox.Text;
                    break;
                case "dirBox":
                    director = objTextBox.Text;
                    break;
                case "genderBox":
                    gender = objTextBox.Text;
                    break;
                case "plotBox":
                    plot = objTextBox.Text;
                    break;
            }
        }

        /// <summary>
        /// Copies the cover to the library's folder.
        /// If an image with the same name already exists, this image replaces it.
        /// </summary>
        private void copyCover() {
            cover = setPathToCover();

            File.Copy(coverPath, cover, true);
        }

        /// <summary>
        /// Changes the cover's name.
        /// </summary>
        private void changeCoverName() {
            File.Copy(coverPath, cover);

            deleteCover(coverPath);
        }

        /// <summary>
        /// Sets the path to the cover.
        /// If the folder doesn't exist, it's created.
        /// </summary>
        /// <returns>The path to the cover.</returns>
        private string setPathToCover() {
            string pathToCover = "Resources\\Covers\\" + window.getLibraryName() + "\\";
            if (!Directory.Exists(pathToCover)) {
                Directory.CreateDirectory(pathToCover);
            }
            return pathToCover + verifString(title) + Path.GetExtension(coverPath);
        }

        /// <summary>
        /// Deletes the cover from the given path, if it exists.
        /// </summary>
        /// <param name="path">The path to the cover.</param>
        private void deleteCover(string path) {
            if (File.Exists(path)) {
                getpictureBox().Image.Dispose();
                File.Delete(path);
            }
        }

        /// <summary>
        /// Verifies if the cover's name doesn't contain
        /// incompatible characters with Windows as ':' or '?'.
        /// </summary>
        /// <param name="name">The name of the cover.</param>
        /// <returns>The name without the incompatible characters.</returns>
        private string verifString(string name) {
            string newName = "";
            for (int i = 0; i < name.Length; i++) {
                if (forbiddenChar.Contains(name[i].ToString())) {
                    newName += "-";
                } else {
                    newName += name[i];
                }
            }
            return newName;
        }

        /// <summary>
        /// Verifies if a movie with the same title already exists.
        /// </summary>
        /// <returns>true if a movie already exists; false otherwise.</returns>
        private bool titleAlreadyExists() {
            foreach (Tuple<PictureBox, Movie> tuple in movieList) {
                if (tuple.Item2.getTitle().Equals(title)) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets the PictureBox linked with the movie.
        /// </summary>
        /// <returns>The PictureBox linked with the movie.</returns>
        private PictureBox getpictureBox() {
            int i = window.getIndex(movieList, movie.getTitle());
            return movieList[i].Item1;
        }

    }
}
