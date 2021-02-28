namespace Projet {
    partial class MainWindow {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.resetBtn = new System.Windows.Forms.Button();
            this.modifBtn = new System.Windows.Forms.Button();
            this.helpBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.delBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.delBibBtn = new System.Windows.Forms.Button();
            this.newBibBtn = new System.Windows.Forms.Button();
            this.moviesPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mainPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.ColumnCount = 1;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.mainPanel.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.mainPanel.Controls.Add(this.moviesPanel, 0, 1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 3;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.mainPanel.Size = new System.Drawing.Size(454, 391);
            this.mainPanel.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.searchBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.resetBtn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.modifBtn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.helpBtn, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(448, 29);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // searchBox
            // 
            this.searchBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchBox.Location = new System.Drawing.Point(181, 3);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(218, 20);
            this.searchBox.TabIndex = 3;
            this.searchBox.Text = "Rechercher";
            this.searchBox.Click += new System.EventHandler(this.searchBox_Click);
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // resetBtn
            // 
            this.resetBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resetBtn.FlatAppearance.BorderSize = 0;
            this.resetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetBtn.Location = new System.Drawing.Point(92, 3);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(83, 23);
            this.resetBtn.TabIndex = 2;
            this.resetBtn.Text = "&Réinitialiser";
            this.resetBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.reset_Click);
            // 
            // modifBtn
            // 
            this.modifBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modifBtn.FlatAppearance.BorderSize = 0;
            this.modifBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modifBtn.Location = new System.Drawing.Point(3, 3);
            this.modifBtn.Name = "modifBtn";
            this.modifBtn.Size = new System.Drawing.Size(83, 23);
            this.modifBtn.TabIndex = 1;
            this.modifBtn.Text = "&Modifier";
            this.modifBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.modifBtn.UseVisualStyleBackColor = true;
            this.modifBtn.Click += new System.EventHandler(this.modifBtn_Click);
            // 
            // helpBtn
            // 
            this.helpBtn.FlatAppearance.BorderSize = 0;
            this.helpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpBtn.Location = new System.Drawing.Point(405, 3);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(40, 23);
            this.helpBtn.TabIndex = 4;
            this.helpBtn.Text = "Aide&h";
            this.helpBtn.UseVisualStyleBackColor = true;
            this.helpBtn.Click += new System.EventHandler(this.helpBtn_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.delBtn, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.addBtn, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.delBibBtn, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.newBibBtn, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 359);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(448, 29);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // delBtn
            // 
            this.delBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.delBtn.FlatAppearance.BorderSize = 0;
            this.delBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delBtn.Location = new System.Drawing.Point(226, 3);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(83, 23);
            this.delBtn.TabIndex = 7;
            this.delBtn.Text = "&Supprimer";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Visible = false;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addBtn.FlatAppearance.BorderSize = 0;
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtn.Location = new System.Drawing.Point(137, 3);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(83, 23);
            this.addBtn.TabIndex = 6;
            this.addBtn.Text = "&Ajouter";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Visible = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // delBibBtn
            // 
            this.delBibBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.delBibBtn.FlatAppearance.BorderSize = 0;
            this.delBibBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delBibBtn.Location = new System.Drawing.Point(315, 3);
            this.delBibBtn.Name = "delBibBtn";
            this.delBibBtn.Size = new System.Drawing.Size(130, 23);
            this.delBibBtn.TabIndex = 8;
            this.delBibBtn.Text = "Supprimer bibliothèque";
            this.delBibBtn.UseVisualStyleBackColor = true;
            this.delBibBtn.Click += new System.EventHandler(this.delBibBtn_Click);
            // 
            // newBibBtn
            // 
            this.newBibBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newBibBtn.FlatAppearance.BorderSize = 0;
            this.newBibBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newBibBtn.Location = new System.Drawing.Point(3, 3);
            this.newBibBtn.Name = "newBibBtn";
            this.newBibBtn.Size = new System.Drawing.Size(128, 23);
            this.newBibBtn.TabIndex = 5;
            this.newBibBtn.Text = "Créer bibliothèque";
            this.newBibBtn.UseVisualStyleBackColor = true;
            this.newBibBtn.Click += new System.EventHandler(this.newBibBtn_Click);
            // 
            // moviesPanel
            // 
            this.moviesPanel.AutoScroll = true;
            this.moviesPanel.ColumnCount = 4;
            this.moviesPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.moviesPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.moviesPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.moviesPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.moviesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moviesPanel.Location = new System.Drawing.Point(3, 38);
            this.moviesPanel.Name = "moviesPanel";
            this.moviesPanel.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.moviesPanel.RowCount = 1;
            this.moviesPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.moviesPanel.Size = new System.Drawing.Size(448, 315);
            this.moviesPanel.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 391);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(470, 750);
            this.MinimumSize = new System.Drawing.Size(470, 292);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bibliothèque de films";
            this.Load += new System.EventHandler(this.Window_Load);
            this.mainPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainPanel, tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2, moviesPanel;
        private System.Windows.Forms.Button modifBtn, resetBtn;
        private System.Windows.Forms.Button delBtn, addBtn, delBibBtn, newBibBtn;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button helpBtn;
    }
}

