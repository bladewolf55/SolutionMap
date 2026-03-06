namespace SolutionMapWinform
{
    partial class ImportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxProgress = new TextBox();
            buttonImport = new Button();
            buttonSolutionsFolder = new Button();
            buttonSqliteDatabaseFolder = new Button();
            textBoxSolutionsFolder = new TextBox();
            labelSolutionsFolder = new Label();
            labelSqliteDatabaseFolder = new Label();
            textBoxSqliteDatabaseFolder = new TextBox();
            SuspendLayout();
            // 
            // textBoxProgress
            // 
            textBoxProgress.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxProgress.Location = new Point(26, 177);
            textBoxProgress.Multiline = true;
            textBoxProgress.Name = "textBoxProgress";
            textBoxProgress.ScrollBars = ScrollBars.Both;
            textBoxProgress.Size = new Size(828, 326);
            textBoxProgress.TabIndex = 15;
            textBoxProgress.WordWrap = false;
            // 
            // buttonImport
            // 
            buttonImport.Location = new Point(26, 119);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(112, 34);
            buttonImport.TabIndex = 14;
            buttonImport.Text = "Import";
            buttonImport.UseVisualStyleBackColor = true;
            buttonImport.Click += buttonImport_Click;
            // 
            // buttonSolutionsFolder
            // 
            buttonSolutionsFolder.Location = new Point(820, 70);
            buttonSolutionsFolder.Name = "buttonSolutionsFolder";
            buttonSolutionsFolder.Size = new Size(34, 34);
            buttonSolutionsFolder.TabIndex = 13;
            buttonSolutionsFolder.Text = "...";
            buttonSolutionsFolder.UseVisualStyleBackColor = true;
            buttonSolutionsFolder.Click += buttonSolutionsFolder_Click;
            // 
            // buttonSqliteDatabaseFolder
            // 
            buttonSqliteDatabaseFolder.Location = new Point(820, 21);
            buttonSqliteDatabaseFolder.Name = "buttonSqliteDatabaseFolder";
            buttonSqliteDatabaseFolder.Size = new Size(34, 34);
            buttonSqliteDatabaseFolder.TabIndex = 12;
            buttonSqliteDatabaseFolder.Text = "...";
            buttonSqliteDatabaseFolder.UseVisualStyleBackColor = true;
            buttonSqliteDatabaseFolder.Click += buttonSqliteDatabaseFolder_Click;
            // 
            // textBoxSolutionsFolder
            // 
            textBoxSolutionsFolder.Location = new Point(222, 72);
            textBoxSolutionsFolder.Name = "textBoxSolutionsFolder";
            textBoxSolutionsFolder.Size = new Size(592, 31);
            textBoxSolutionsFolder.TabIndex = 11;
            textBoxSolutionsFolder.TextChanged += textBoxSolutionsFolder_TextChanged;
            // 
            // labelSolutionsFolder
            // 
            labelSolutionsFolder.AutoSize = true;
            labelSolutionsFolder.Location = new Point(26, 72);
            labelSolutionsFolder.Name = "labelSolutionsFolder";
            labelSolutionsFolder.Size = new Size(138, 25);
            labelSolutionsFolder.TabIndex = 10;
            labelSolutionsFolder.Text = "Solutions folder";
            // 
            // labelSqliteDatabaseFolder
            // 
            labelSqliteDatabaseFolder.AutoSize = true;
            labelSqliteDatabaseFolder.Location = new Point(26, 26);
            labelSqliteDatabaseFolder.Name = "labelSqliteDatabaseFolder";
            labelSqliteDatabaseFolder.Size = new Size(185, 25);
            labelSqliteDatabaseFolder.TabIndex = 9;
            labelSqliteDatabaseFolder.Text = "Sqlite database folder";
            // 
            // textBoxSqliteDatabaseFolder
            // 
            textBoxSqliteDatabaseFolder.Location = new Point(222, 26);
            textBoxSqliteDatabaseFolder.Name = "textBoxSqliteDatabaseFolder";
            textBoxSqliteDatabaseFolder.Size = new Size(592, 31);
            textBoxSqliteDatabaseFolder.TabIndex = 8;
            textBoxSqliteDatabaseFolder.TextChanged += textBoxSqliteDatabaseFolder_TextChanged;
            // 
            // ImportForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(881, 539);
            Controls.Add(textBoxProgress);
            Controls.Add(buttonImport);
            Controls.Add(buttonSolutionsFolder);
            Controls.Add(buttonSqliteDatabaseFolder);
            Controls.Add(textBoxSolutionsFolder);
            Controls.Add(labelSolutionsFolder);
            Controls.Add(labelSqliteDatabaseFolder);
            Controls.Add(textBoxSqliteDatabaseFolder);
            Name = "ImportForm";
            Text = "ImportForm";
            Load += ImportForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxProgress;
        private Button buttonImport;
        private Button buttonSolutionsFolder;
        private Button buttonSqliteDatabaseFolder;
        private TextBox textBoxSolutionsFolder;
        private Label labelSolutionsFolder;
        private Label labelSqliteDatabaseFolder;
        private TextBox textBoxSqliteDatabaseFolder;
    }
}