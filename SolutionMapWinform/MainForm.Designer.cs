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
            buttonEvaluate = new Button();
            codeEditorBox = new NTextEditor.View.Winforms.CodeEditorBox();
            buttonImport = new Button();
            labelSolutionsFolder = new Label();
            splitContainer = new SplitContainer();
            panelWebView = new Panel();
            webView2Results = new Microsoft.Web.WebView2.WinForms.WebView2();
            textBoxOutput = new TextBox();
            tabControlResults = new TabControl();
            tabPageConsole = new TabPage();
            tabPageGrid = new TabPage();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            panelWebView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView2Results).BeginInit();
            tabControlResults.SuspendLayout();
            tabPageConsole.SuspendLayout();
            tabPageGrid.SuspendLayout();
            SuspendLayout();
            // 
            // buttonEvaluate
            // 
            buttonEvaluate.Location = new Point(27, 42);
            buttonEvaluate.Margin = new Padding(2, 2, 2, 2);
            buttonEvaluate.Name = "buttonEvaluate";
            buttonEvaluate.Size = new Size(78, 20);
            buttonEvaluate.TabIndex = 12;
            buttonEvaluate.Text = "Run (F5)";
            buttonEvaluate.UseVisualStyleBackColor = true;
            buttonEvaluate.Click += buttonEvaluate_Click;
            // 
            // codeEditorBox
            // 
            codeEditorBox.Font = new Font("Cascadia Mono", 12F);
            codeEditorBox.Location = new Point(184, 35);
            codeEditorBox.Margin = new Padding(4, 4, 4, 4);
            codeEditorBox.Name = "codeEditorBox";
            codeEditorBox.Size = new Size(718, 170);
            codeEditorBox.TabIndex = 15;
            // 
            // buttonImport
            // 
            buttonImport.Location = new Point(27, 7);
            buttonImport.Margin = new Padding(2, 2, 2, 2);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(78, 20);
            buttonImport.TabIndex = 16;
            buttonImport.Text = "Import";
            buttonImport.UseVisualStyleBackColor = true;
            buttonImport.Click += buttonImportForm_Click;
            // 
            // labelSolutionsFolder
            // 
            labelSolutionsFolder.AutoSize = true;
            labelSolutionsFolder.Location = new Point(109, 10);
            labelSolutionsFolder.Margin = new Padding(2, 0, 2, 0);
            labelSolutionsFolder.Name = "labelSolutionsFolder";
            labelSolutionsFolder.Size = new Size(91, 15);
            labelSolutionsFolder.TabIndex = 17;
            labelSolutionsFolder.Text = "solutions/folder";
            // 
            // splitContainer
            // 
            splitContainer.Location = new Point(27, 83);
            splitContainer.Margin = new Padding(2, 2, 2, 2);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(codeEditorBox);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(tabControlResults);
            splitContainer.Size = new Size(1047, 466);
            splitContainer.SplitterDistance = 231;
            splitContainer.SplitterWidth = 2;
            splitContainer.TabIndex = 18;
            // 
            // panelWebView
            // 
            panelWebView.BorderStyle = BorderStyle.FixedSingle;
            panelWebView.Controls.Add(webView2Results);
            panelWebView.Location = new Point(50, 36);
            panelWebView.Margin = new Padding(2, 2, 2, 2);
            panelWebView.Name = "panelWebView";
            panelWebView.Size = new Size(348, 111);
            panelWebView.TabIndex = 19;
            // 
            // webView2Results
            // 
            webView2Results.AllowExternalDrop = true;
            webView2Results.CreationProperties = null;
            webView2Results.DefaultBackgroundColor = Color.White;
            webView2Results.Location = new Point(45, 24);
            webView2Results.Margin = new Padding(2, 2, 2, 2);
            webView2Results.Name = "webView2Results";
            webView2Results.Size = new Size(270, 70);
            webView2Results.TabIndex = 10;
            webView2Results.ZoomFactor = 1D;
            // 
            // textBoxOutput
            // 
            textBoxOutput.Location = new Point(51, 38);
            textBoxOutput.Margin = new Padding(2, 2, 2, 2);
            textBoxOutput.Multiline = true;
            textBoxOutput.Name = "textBoxOutput";
            textBoxOutput.ScrollBars = ScrollBars.Both;
            textBoxOutput.Size = new Size(270, 95);
            textBoxOutput.TabIndex = 19;
            // 
            // tabControlResults
            // 
            tabControlResults.Controls.Add(tabPageConsole);
            tabControlResults.Controls.Add(tabPageGrid);
            tabControlResults.Location = new Point(283, 20);
            tabControlResults.Name = "tabControlResults";
            tabControlResults.SelectedIndex = 0;
            tabControlResults.Size = new Size(450, 197);
            tabControlResults.TabIndex = 20;
            // 
            // tabPageConsole
            // 
            tabPageConsole.Controls.Add(textBoxOutput);
            tabPageConsole.Location = new Point(4, 24);
            tabPageConsole.Name = "tabPageConsole";
            tabPageConsole.Padding = new Padding(3);
            tabPageConsole.Size = new Size(442, 169);
            tabPageConsole.TabIndex = 0;
            tabPageConsole.Text = "Output";
            tabPageConsole.UseVisualStyleBackColor = true;
            // 
            // tabPageGrid
            // 
            tabPageGrid.Controls.Add(panelWebView);
            tabPageGrid.Location = new Point(4, 24);
            tabPageGrid.Name = "tabPageGrid";
            tabPageGrid.Padding = new Padding(3);
            tabPageGrid.Size = new Size(442, 169);
            tabPageGrid.TabIndex = 1;
            tabPageGrid.Text = "Grid";
            tabPageGrid.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1096, 565);
            Controls.Add(splitContainer);
            Controls.Add(labelSolutionsFolder);
            Controls.Add(buttonImport);
            Controls.Add(buttonEvaluate);
            KeyPreview = true;
            Margin = new Padding(2, 2, 2, 2);
            Name = "MainForm";
            Text = "SolutionMap";
            Load += MainForm_Load;
            KeyDown += MainForm_KeyDown;
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            panelWebView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)webView2Results).EndInit();
            tabControlResults.ResumeLayout(false);
            tabPageConsole.ResumeLayout(false);
            tabPageConsole.PerformLayout();
            tabPageGrid.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonEvaluate;
        private NTextEditor.View.Winforms.CodeEditorBox codeEditorBox;
        private Button buttonImport;
        private Label labelSolutionsFolder;
        private SplitContainer splitContainer;
        private Panel panelWebView;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2Results;
        private TextBox textBoxOutput;
        private TabControl tabControlResults;
        private TabPage tabPageConsole;
        private TabPage tabPageGrid;
    }
}
