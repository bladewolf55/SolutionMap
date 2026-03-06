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
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            panelWebView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView2Results).BeginInit();
            SuspendLayout();
            // 
            // buttonEvaluate
            // 
            buttonEvaluate.Location = new Point(38, 70);
            buttonEvaluate.Name = "buttonEvaluate";
            buttonEvaluate.Size = new Size(112, 34);
            buttonEvaluate.TabIndex = 12;
            buttonEvaluate.Text = "Run (F5)";
            buttonEvaluate.UseVisualStyleBackColor = true;
            buttonEvaluate.Click += buttonEvaluate_Click;
            // 
            // codeEditorBox
            // 
            codeEditorBox.Font = new Font("Cascadia Mono", 12F);
            codeEditorBox.Location = new Point(263, 59);
            codeEditorBox.Margin = new Padding(6, 6, 6, 6);
            codeEditorBox.Name = "codeEditorBox";
            codeEditorBox.Size = new Size(1025, 283);
            codeEditorBox.TabIndex = 15;
            // 
            // buttonImport
            // 
            buttonImport.Location = new Point(38, 12);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(112, 34);
            buttonImport.TabIndex = 16;
            buttonImport.Text = "Import";
            buttonImport.UseVisualStyleBackColor = true;
            buttonImport.Click += buttonImportForm_Click;
            // 
            // labelSolutionsFolder
            // 
            labelSolutionsFolder.AutoSize = true;
            labelSolutionsFolder.Location = new Point(156, 17);
            labelSolutionsFolder.Name = "labelSolutionsFolder";
            labelSolutionsFolder.Size = new Size(138, 25);
            labelSolutionsFolder.TabIndex = 17;
            labelSolutionsFolder.Text = "solutions/folder";
            // 
            // splitContainer
            // 
            splitContainer.Location = new Point(39, 138);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(codeEditorBox);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(panelWebView);
            splitContainer.Size = new Size(1496, 776);
            splitContainer.SplitterDistance = 386;
            splitContainer.TabIndex = 18;
            // 
            // panelWebView
            // 
            panelWebView.BorderStyle = BorderStyle.FixedSingle;
            panelWebView.Controls.Add(webView2Results);
            panelWebView.Location = new Point(523, 100);
            panelWebView.Name = "panelWebView";
            panelWebView.Size = new Size(497, 184);
            panelWebView.TabIndex = 19;
            // 
            // webView2Results
            // 
            webView2Results.AllowExternalDrop = true;
            webView2Results.CreationProperties = null;
            webView2Results.DefaultBackgroundColor = Color.White;
            webView2Results.Location = new Point(64, 40);
            webView2Results.Name = "webView2Results";
            webView2Results.Size = new Size(385, 116);
            webView2Results.TabIndex = 10;
            webView2Results.ZoomFactor = 1D;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1566, 926);
            Controls.Add(splitContainer);
            Controls.Add(labelSolutionsFolder);
            Controls.Add(buttonImport);
            Controls.Add(buttonEvaluate);
            KeyPreview = true;
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
    }
}
