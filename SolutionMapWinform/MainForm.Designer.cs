namespace SolutionMapWinform
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxSqliteDatabaseFolder = new TextBox();
            labelSqliteDatabaseFolder = new Label();
            labelSolutionsFolder = new Label();
            textBoxSolutionsFolder = new TextBox();
            buttonSqliteDatabaseFolder = new Button();
            buttonSolutionsFolder = new Button();
            buttonImport = new Button();
            textBoxProgress = new TextBox();
            SuspendLayout();
            // 
            // textBoxSqliteDatabaseFolder
            // 
            textBoxSqliteDatabaseFolder.Location = new Point(234, 35);
            textBoxSqliteDatabaseFolder.Name = "textBoxSqliteDatabaseFolder";
            textBoxSqliteDatabaseFolder.Size = new Size(592, 31);
            textBoxSqliteDatabaseFolder.TabIndex = 0;
            // 
            // labelSqliteDatabaseFolder
            // 
            labelSqliteDatabaseFolder.AutoSize = true;
            labelSqliteDatabaseFolder.Location = new Point(38, 35);
            labelSqliteDatabaseFolder.Name = "labelSqliteDatabaseFolder";
            labelSqliteDatabaseFolder.Size = new Size(185, 25);
            labelSqliteDatabaseFolder.TabIndex = 1;
            labelSqliteDatabaseFolder.Text = "Sqlite database folder";
            // 
            // labelSolutionsFolder
            // 
            labelSolutionsFolder.AutoSize = true;
            labelSolutionsFolder.Location = new Point(38, 81);
            labelSolutionsFolder.Name = "labelSolutionsFolder";
            labelSolutionsFolder.Size = new Size(138, 25);
            labelSolutionsFolder.TabIndex = 2;
            labelSolutionsFolder.Text = "Solutions folder";
            // 
            // textBoxSolutionsFolder
            // 
            textBoxSolutionsFolder.Location = new Point(234, 81);
            textBoxSolutionsFolder.Name = "textBoxSolutionsFolder";
            textBoxSolutionsFolder.Size = new Size(592, 31);
            textBoxSolutionsFolder.TabIndex = 3;
            // 
            // buttonSqliteDatabaseFolder
            // 
            buttonSqliteDatabaseFolder.Location = new Point(832, 30);
            buttonSqliteDatabaseFolder.Name = "buttonSqliteDatabaseFolder";
            buttonSqliteDatabaseFolder.Size = new Size(34, 34);
            buttonSqliteDatabaseFolder.TabIndex = 4;
            buttonSqliteDatabaseFolder.Text = "...";
            buttonSqliteDatabaseFolder.UseVisualStyleBackColor = true;
            buttonSqliteDatabaseFolder.Click += buttonSqliteDatabaseFolder_Click;
            // 
            // buttonSolutionsFolder
            // 
            buttonSolutionsFolder.Location = new Point(832, 79);
            buttonSolutionsFolder.Name = "buttonSolutionsFolder";
            buttonSolutionsFolder.Size = new Size(34, 34);
            buttonSolutionsFolder.TabIndex = 5;
            buttonSolutionsFolder.Text = "...";
            buttonSolutionsFolder.UseVisualStyleBackColor = true;
            buttonSolutionsFolder.Click += buttonSolutionsFolder_Click;
            // 
            // buttonImport
            // 
            buttonImport.Location = new Point(38, 128);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(112, 34);
            buttonImport.TabIndex = 6;
            buttonImport.Text = "Import";
            buttonImport.UseVisualStyleBackColor = true;
            // 
            // textBoxProgress
            // 
            textBoxProgress.Location = new Point(234, 128);
            textBoxProgress.Multiline = true;
            textBoxProgress.Name = "textBoxProgress";
            textBoxProgress.ScrollBars = ScrollBars.Horizontal;
            textBoxProgress.Size = new Size(632, 231);
            textBoxProgress.TabIndex = 7;
            textBoxProgress.WordWrap = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(903, 401);
            Controls.Add(textBoxProgress);
            Controls.Add(buttonImport);
            Controls.Add(buttonSolutionsFolder);
            Controls.Add(buttonSqliteDatabaseFolder);
            Controls.Add(textBoxSolutionsFolder);
            Controls.Add(labelSolutionsFolder);
            Controls.Add(labelSqliteDatabaseFolder);
            Controls.Add(textBoxSqliteDatabaseFolder);
            Name = "MainForm";
            Text = "SolutionMap";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxSqliteDatabaseFolder;
        private Label labelSqliteDatabaseFolder;
        private Label labelSolutionsFolder;
        private TextBox textBoxSolutionsFolder;
        private Button buttonSqliteDatabaseFolder;
        private Button buttonSolutionsFolder;
        private Button buttonImport;
        private TextBox textBoxProgress;
    }
}
