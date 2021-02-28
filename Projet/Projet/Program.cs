using System;
using System.IO;
using System.Windows.Forms;

namespace Projet {
    /// <summary>
    /// The main class of the application.
    /// </summary>
    static class Program {
      
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainWindow mainWindow = new MainWindow();
            verifSaveFile();
        }

        /// <summary>
        /// This method verifies if a saved file exists.
        /// There're 3 cases:
        /// - No file: the user must enter a name to create a file;
        /// - One file: the file is loaded;
        /// - Several files: the user must choose the file.
        /// </summary>
        static void verifSaveFile() {
            var fileMatches = Directory.GetFiles("Resources\\libraries\\", "*.ibib", SearchOption.TopDirectoryOnly);

            if (fileMatches.Length == 0) {
                Application.Run(new DialogWindow());
            } else if (fileMatches.Length == 1) {
                string libraryName = fileMatches[0].Remove(fileMatches[0].Length - 5);
                libraryName = libraryName.Remove(0, 20);
                Application.Run(new MainWindow(libraryName, fileMatches[0]));
            } else if (fileMatches.Length > 1) {
                Application.Run(new DialogWindow(fileMatches));
            }
        }
    }
}
