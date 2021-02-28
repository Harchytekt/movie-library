using System;
using System.IO;

namespace Projet {
    [Serializable()]
    /// <summary>
    /// This class creates a 'Movie' object.
    /// A movie has a title, a director, a date, a gender, a cover and a plot.
    /// </summary>
    public class Movie {
        protected string title, director, date, gender, cover = "Resources\\Covers\\NoCover.png", plot;

        /// <summary>
        /// This is the main constructor,
        /// it creates the fourth episode of Star Wars.
        /// </summary>
        public Movie() {
            title = "Star Wars Episode IV: A New Hope";
            director = "George Lucas";
            date = "25/5/1977";
            gender = "Science fiction";
            cover = "Resources\\covers\\ANewHope.png";
            plot = @"The Imperial Forces - under orders from cruel Darth Vader (David Prowse) - hold Princess Leia (Carrie Fisher) hostage, in their efforts to quell the rebellion against the Galactic Empire.
Luke Skywalker (Mark Hamill) and Han Solo (Harrison Ford), captain of the Millennium Falcon, work together with the companionable droid duo R2-D2 (Kenny Baker) and C-3PO (Anthony Daniels) to rescue the beautiful princess, help the Rebel Alliance, and restore freedom and justice to the Galaxy.";
        }

        /// <summary>
        /// Constructor of a movie.
        /// </summary>
        /// 
        /// <param name='title'>The title of the movie.</param>
        /// <param name='director'>The director of the movie.</param>
        /// <param name='date'>The date of the movie.</param>
        /// <param name='gender'>The gender of the movie.</param>
        /// <param name='plot'>The plot of the movie.</param>
        public Movie(string title, string director, string date, string gender, string plot) {
            this.title = title;
            this.director = director;
            this.date = date;
            this.gender = gender;
            this.plot = plot;
        }

        /// <summary>
        /// Returns a string representation of a Movie.
        /// </summary>
        /// <returns>A string representation of a Movie.</returns>
        public override string ToString() {
            string movieInfos = "Title: " + title + "\n";
            movieInfos += "Director: " + director + "\n";
            movieInfos += "Date: " + date + "\n";
            movieInfos += "Gender: " + gender + "\n";
            movieInfos += "Cover: " + cover + "\n";
            movieInfos += "Plot: " + plot;
            return movieInfos;
        }

        /// <summary>
        /// Sets the title of the movie.
        /// </summary>
        /// <param name="title">The title of the movie.</param>
        public void setTitle(string title) {
            this.title = title;
        }

        /// <summary>
        /// Gets the title of the movie.
        /// </summary>
        /// <returns>The title of the movie.</returns>
        public string getTitle() {
            return title;
        }

        /// <summary>
        /// Sets the director of the movie.
        /// </summary>
        /// <param name="director">The director of the movie.</param>
        public void setDirector(string director) {
            this.director = director;
        }

        /// <summary>
        /// Gets the director of the movie.
        /// </summary>
        /// <returns>The director of the movie.</returns>
        public string getDirector() {
            return director;
        }

        /// <summary>
        /// Sets the date of the movie.
        /// </summary>
        /// <param name="date">The date of the movie.</param>
        public void setDate(string date) {
            this.date = date;
        }

        /// <summary>
        /// Gets the date of the movie.
        /// </summary>
        /// <returns>The date of the movie.</returns>
        public string getDate() {
            return date.ToString();
        }

        /// <summary>
        /// Sets the gender of the movie.
        /// </summary>
        /// <param name="gender">The gender of the movie.</param>
        public void setGender(string gender) {
            this.gender = gender;
        }

        /// <summary>
        /// Gets the gender of the movie.
        /// </summary>
        /// <returns>The gender of the movie.</returns>
        public string getGender() {
            return gender;
        }

        /// <summary>
        /// Sets the cover of the movie.
        /// </summary>
        /// <param name="cover">The cover of the movie.</param>
        public void setCover(string cover) {
            this.cover = cover;
        }

        /// <summary>
        /// Gets the cover of the movie.
        /// </summary>
        /// <returns>The cover of the movie.</returns>
        public string getCover() {
            return cover;
        }

        /// <summary>
        /// Sets the plot of the movie.
        /// </summary>
        /// <param name="plot">The plot of the movie.</param>
        public void setPlot(string plot) {
            this.plot = plot;
        }

        /// <summary>
        /// Gets the plot of the movie.
        /// </summary>
        /// <returns>The plot of the movie.</returns>
        public string getPlot() {
            return plot;
        }

        /// <summary>
        /// Writes the infos of the movie in the file.
        /// </summary>
        /// <param name="file">The backup file.</param>
        public void writeToFile(StreamWriter file) {
            file.WriteLine("BeginMovieInfos");
            file.WriteLine(title);
            file.WriteLine(director);
            file.WriteLine(date);
            file.WriteLine(gender);
            file.WriteLine(cover);
            file.WriteLine(plot);
            file.WriteLine("EndMovieInfos");
            file.WriteLine();
        }

        /// <summary>
        /// When a library backup is loaded, the informations
        /// of the saved movies are added in new Movie objects
        /// one by one.
        /// </summary>
        /// <param name="item">The item can be the title or the director or... of the movie.</param>
        /// <param name="nbItem">The number of the item identifies it as a title or a director or...</param>
        public void addItem(string item, int nbItem) {
            switch (nbItem) {
                case 0:
                    title = item;
                    break;
                case 1:
                    director = item;
                    break;
                case 2:
                    date = item;
                    break;
                case 3:
                    gender = item;
                    break;
                case 4:
                    cover = item;
                    break;
                case 5:
                    plot = item;
                    break;
                default:
                    plot += "\n" + item;
                    break;
            }
        }

        /// <summary>
        /// This method verifies if the movie contains the given text
        /// in the title, the director's name or in another detail of the movie.
        /// </summary>
        /// <param name="text">The text to verify.</param>
        /// <returns></returns>
        public bool contains(string text) {
            text = text.ToLower();
            return (title.ToLower().Contains(text) || director.ToLower().Contains(text) ||
                date.Contains(text) || gender.ToLower().Contains(text) || plot.ToLower().Contains(text));
        }

    }
}
