namespace Projet {
    partial class MovieDisplayWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieDisplayWindow));
            this.titleLbl = new System.Windows.Forms.Label();
            this.directorLbl = new System.Windows.Forms.Label();
            this.dateLbl = new System.Windows.Forms.Label();
            this.genderLbl = new System.Windows.Forms.Label();
            this.plotLbl = new System.Windows.Forms.Label();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.dirBox = new System.Windows.Forms.TextBox();
            this.genderBox = new System.Windows.Forms.TextBox();
            this.plotBox = new System.Windows.Forms.TextBox();
            this.modifyMovieBtn = new System.Windows.Forms.Button();
            this.saveModifBtn = new System.Windows.Forms.Button();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.coverLbl = new System.Windows.Forms.Label();
            this.coverPathBox = new System.Windows.Forms.TextBox();
            this.browseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLbl.Location = new System.Drawing.Point(11, 30);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(44, 15);
            this.titleLbl.TabIndex = 0;
            this.titleLbl.Text = "Titre: ";
            // 
            // directorLbl
            // 
            this.directorLbl.AutoSize = true;
            this.directorLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directorLbl.Location = new System.Drawing.Point(11, 56);
            this.directorLbl.Name = "directorLbl";
            this.directorLbl.Size = new System.Drawing.Size(93, 15);
            this.directorLbl.TabIndex = 1;
            this.directorLbl.Text = "Réalisateur:  ";
            // 
            // dateLbl
            // 
            this.dateLbl.AutoSize = true;
            this.dateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLbl.Location = new System.Drawing.Point(11, 82);
            this.dateLbl.Name = "dateLbl";
            this.dateLbl.Size = new System.Drawing.Size(45, 15);
            this.dateLbl.TabIndex = 2;
            this.dateLbl.Text = "Date: ";
            // 
            // genderLbl
            // 
            this.genderLbl.AutoSize = true;
            this.genderLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genderLbl.Location = new System.Drawing.Point(11, 107);
            this.genderLbl.Name = "genderLbl";
            this.genderLbl.Size = new System.Drawing.Size(54, 15);
            this.genderLbl.TabIndex = 3;
            this.genderLbl.Text = "Genre: ";
            // 
            // plotLbl
            // 
            this.plotLbl.AutoSize = true;
            this.plotLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plotLbl.Location = new System.Drawing.Point(11, 132);
            this.plotLbl.Name = "plotLbl";
            this.plotLbl.Size = new System.Drawing.Size(68, 15);
            this.plotLbl.TabIndex = 4;
            this.plotLbl.Text = "Résumé: ";
            // 
            // titleBox
            // 
            this.titleBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.titleBox.Location = new System.Drawing.Point(125, 29);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(370, 13);
            this.titleBox.TabIndex = 2;
            this.titleBox.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // dirBox
            // 
            this.dirBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dirBox.Location = new System.Drawing.Point(125, 55);
            this.dirBox.Name = "dirBox";
            this.dirBox.Size = new System.Drawing.Size(370, 13);
            this.dirBox.TabIndex = 3;
            this.dirBox.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // genderBox
            // 
            this.genderBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.genderBox.Location = new System.Drawing.Point(125, 106);
            this.genderBox.Name = "genderBox";
            this.genderBox.Size = new System.Drawing.Size(208, 13);
            this.genderBox.TabIndex = 5;
            this.genderBox.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // plotBox
            // 
            this.plotBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.plotBox.Location = new System.Drawing.Point(125, 132);
            this.plotBox.Multiline = true;
            this.plotBox.Name = "plotBox";
            this.plotBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.plotBox.Size = new System.Drawing.Size(370, 138);
            this.plotBox.TabIndex = 6;
            this.plotBox.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // modifyMovieBtn
            // 
            this.modifyMovieBtn.BackColor = System.Drawing.SystemColors.Control;
            this.modifyMovieBtn.FlatAppearance.BorderSize = 0;
            this.modifyMovieBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modifyMovieBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyMovieBtn.Location = new System.Drawing.Point(150, 0);
            this.modifyMovieBtn.Name = "modifyMovieBtn";
            this.modifyMovieBtn.Size = new System.Drawing.Size(75, 23);
            this.modifyMovieBtn.TabIndex = 0;
            this.modifyMovieBtn.Text = "Modifier";
            this.modifyMovieBtn.UseVisualStyleBackColor = false;
            this.modifyMovieBtn.Click += new System.EventHandler(this.modifyMovieBtn_Click);
            // 
            // saveModifBtn
            // 
            this.saveModifBtn.BackColor = System.Drawing.SystemColors.Control;
            this.saveModifBtn.FlatAppearance.BorderSize = 0;
            this.saveModifBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveModifBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveModifBtn.Location = new System.Drawing.Point(258, 0);
            this.saveModifBtn.Name = "saveModifBtn";
            this.saveModifBtn.Size = new System.Drawing.Size(93, 23);
            this.saveModifBtn.TabIndex = 1;
            this.saveModifBtn.Text = "Sauvegarder";
            this.saveModifBtn.UseVisualStyleBackColor = false;
            this.saveModifBtn.Click += new System.EventHandler(this.saveModifBtn_Click);
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(125, 78);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 20);
            this.datePicker.TabIndex = 4;
            this.datePicker.ValueChanged += new System.EventHandler(this.datePicker_ValueChanged);
            // 
            // coverLbl
            // 
            this.coverLbl.AutoSize = true;
            this.coverLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coverLbl.Location = new System.Drawing.Point(12, 287);
            this.coverLbl.Name = "coverLbl";
            this.coverLbl.Size = new System.Drawing.Size(70, 15);
            this.coverLbl.TabIndex = 13;
            this.coverLbl.Text = "Jaquette: ";
            // 
            // coverPathBox
            // 
            this.coverPathBox.BackColor = System.Drawing.SystemColors.Window;
            this.coverPathBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.coverPathBox.Location = new System.Drawing.Point(125, 289);
            this.coverPathBox.Name = "coverPathBox";
            this.coverPathBox.ReadOnly = true;
            this.coverPathBox.Size = new System.Drawing.Size(280, 13);
            this.coverPathBox.TabIndex = 7;
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(420, 284);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(75, 23);
            this.browseBtn.TabIndex = 8;
            this.browseBtn.Text = "Chercher";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // MovieDisplayWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 319);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.coverPathBox);
            this.Controls.Add(this.coverLbl);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.saveModifBtn);
            this.Controls.Add(this.modifyMovieBtn);
            this.Controls.Add(this.plotBox);
            this.Controls.Add(this.genderBox);
            this.Controls.Add(this.dirBox);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.plotLbl);
            this.Controls.Add(this.genderLbl);
            this.Controls.Add(this.dateLbl);
            this.Controls.Add(this.directorLbl);
            this.Controls.Add(this.titleLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MovieDisplayWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Label directorLbl;
        private System.Windows.Forms.Label dateLbl;
        private System.Windows.Forms.Label genderLbl;
        private System.Windows.Forms.Label plotLbl;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.TextBox dirBox;
        private System.Windows.Forms.TextBox genderBox;
        private System.Windows.Forms.TextBox plotBox;
        private System.Windows.Forms.Button modifyMovieBtn;
        private System.Windows.Forms.Button saveModifBtn;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label coverLbl;
        private System.Windows.Forms.TextBox coverPathBox;
        private System.Windows.Forms.Button browseBtn;
    }
}