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
            buttonEvaluate = new Button();
            panel1 = new Panel();
            webView2Results = new Microsoft.Web.WebView2.WinForms.WebView2();
            codeEditorBox = new NTextEditor.View.Winforms.CodeEditorBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView2Results).BeginInit();
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
            buttonImport.Click += buttonImport_Click;
            // 
            // textBoxProgress
            // 
            textBoxProgress.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxProgress.Location = new Point(904, 30);
            textBoxProgress.Multiline = true;
            textBoxProgress.Name = "textBoxProgress";
            textBoxProgress.ScrollBars = ScrollBars.Both;
            textBoxProgress.Size = new Size(632, 261);
            textBoxProgress.TabIndex = 7;
            textBoxProgress.WordWrap = false;
            // 
            // buttonEvaluate
            // 
            buttonEvaluate.Location = new Point(38, 290);
            buttonEvaluate.Name = "buttonEvaluate";
            buttonEvaluate.Size = new Size(112, 34);
            buttonEvaluate.TabIndex = 12;
            buttonEvaluate.Text = "Run";
            buttonEvaluate.UseVisualStyleBackColor = true;
            buttonEvaluate.Click += buttonEvaluate_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(webView2Results);
            panel1.Location = new Point(38, 788);
            panel1.Name = "panel1";
            panel1.Size = new Size(1498, 561);
            panel1.TabIndex = 14;
            // 
            // webView2Results
            // 
            webView2Results.AllowExternalDrop = true;
            webView2Results.CreationProperties = null;
            webView2Results.DefaultBackgroundColor = Color.White;
            webView2Results.Dock = DockStyle.Fill;
            webView2Results.Location = new Point(0, 0);
            webView2Results.Name = "webView2Results";
            webView2Results.Size = new Size(1496, 559);
            webView2Results.TabIndex = 9;
            webView2Results.ZoomFactor = 1D;
            // 
            // codeEditorBox
            // 
            codeEditorBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            codeEditorBox.Font = new Font("Cascadia Mono", 12F);
            codeEditorBox.Location = new Point(39, 333);
            codeEditorBox.Margin = new Padding(6, 6, 6, 6);
            codeEditorBox.Name = "codeEditorBox";
            codeEditorBox.Size = new Size(1497, 446);
            codeEditorBox.TabIndex = 15;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1566, 1361);
            Controls.Add(codeEditorBox);
            Controls.Add(panel1);
            Controls.Add(buttonEvaluate);
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
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)webView2Results).EndInit();
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
        private Button buttonEvaluate;
        private Panel panel1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2Results;
        private NTextEditor.View.Winforms.CodeEditorBox codeEditorBox;
    }
}
