using LINQPad;
using NTextEditor.Languages.CSharp;
using NTextEditor.View.Winforms;
using SolutionMap.DataImport;
using SolutionMap.Domain.Models;

namespace SolutionMapWinform
{
    public partial class MainForm : Form
    {
        private const string sqliteDatabaseFileName = "solutionmap.db";
        public MainForm()
        {
            InitializeComponent();
            codeEditorBox.SetLanguageToCSharp(isLibrary: false);
        }

        #region "Methods"

        private void ShowFolderBrowserDialog(TextBox textBox)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog()
            {
                SelectedPath = textBox.Text,
                InitialDirectory = textBox.Text
            };
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox.Text = dialog.SelectedPath;
            }
        }

        private void LoadSettings()
        {
            textBoxSqliteDatabaseFolder.Text = Properties.Settings.Default.SqliteDatabaseFolder;
            textBoxSolutionsFolder.Text = Properties.Settings.Default.SolutionsFolder;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.SqliteDatabaseFolder = textBoxSqliteDatabaseFolder.Text;
            Properties.Settings.Default.SolutionsFolder = textBoxSolutionsFolder.Text;
            Properties.Settings.Default.Save();
        }

        private void AddProgress(string message)
        {
            textBoxProgress.Text += $"{DateTime.Now:HH:mm:ss} {message}{Environment.NewLine}";
        }

        private string GetSqliteDatabaseFilePath() => Path.Combine(textBoxSqliteDatabaseFolder.Text, sqliteDatabaseFileName);

        private string GetSqliteConnectionString() => $"Data Source={GetSqliteDatabaseFilePath()}";

        private void Import()
        {
            var errors = ValidationErrors();
            if (errors.Length > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, errors), "Validation Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var importService = new DataImportService();
            importService.ImportStatus += (s, e) =>
            {
                AddProgress(e.Message);
            };
            textBoxProgress.Clear();
            try
            {
                var sqliteFilePath = GetSqliteDatabaseFilePath();
                var solutionsPath = textBoxSolutionsFolder.Text;
                importService.ImportVisualBasicSolutions(sqliteFilePath, solutionsPath);
            }
            catch (Exception ex)
            {
                AddProgress($"Error: {ex.Message}");
            }
        }

        private string[] ValidationErrors()
        {
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(textBoxSqliteDatabaseFolder.Text))
            {
                errors.Add("SQLite database folder is required.");
            }
            else if (!Directory.Exists(textBoxSqliteDatabaseFolder.Text))
            {
                errors.Add("SQLite database folder does not exist.");
            }
            if (string.IsNullOrWhiteSpace(textBoxSolutionsFolder.Text))
            {
                errors.Add("Solutions folder is required.");
            }
            else if (!Directory.Exists(textBoxSolutionsFolder.Text))
            {
                errors.Add("Solutions folder does not exist.");
            }
            return errors.ToArray();
        }

        private async void ShowResults(params object[] results)
        {
            var df = Util.BrowserEngine.GetWebView2DataFolder();
            var ef = Util.BrowserEngine.GetWebView2ExecutableFolder();

            var html = Util.ToHtmlString(enableExpansions: true, results);
            // initialize
            //webView2Results.Source = new Uri("about:blank");
            //await webView2Results.EnsureCoreWebView2Async();
            // show
            //webView2Results.NavigateToString(html);


            var tempPath = Path.GetTempPath();
            var temp = Path.Join(tempPath, "solutionMap.html");
            File.WriteAllText(temp, html);
            var uri = new Uri(new Uri(temp).AbsoluteUri);
            webView2Results.Source = new Uri("about:blank");
            webView2Results.Source = uri;
        }

        #endregion


        #region "Events"
        private void buttonImport_Click(object sender, EventArgs e)
        {
            Import();
        }
        private void buttonSqliteDatabaseFolder_Click(object sender, EventArgs e)
        {
            ShowFolderBrowserDialog(textBoxSqliteDatabaseFolder);
            SaveSettings();
        }

        private void buttonSolutionsFolder_Click(object sender, EventArgs e)
        {
            ShowFolderBrowserDialog(textBoxSolutionsFolder);
            SaveSettings();
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            var dataService = new SolutionMap.Database.SolutionMapDb(GetSqliteConnectionString());
            var solutions = dataService.Solutions.ToList();
            ShowResults(solutions);
        }

        private void buttonEvaluate_Click(object sender, EventArgs e)
        {
            var script = codeEditorBox.GetText();
            var options = Microsoft.CodeAnalysis.Scripting.ScriptOptions.Default
                .AddReferences(typeof(Solution).Assembly)
                .AddImports("System", "System.Linq", "SolutionMap.Domain.Models", "SolutionMap.Database");
            var cn = GetSqliteConnectionString().Replace(@"\", @"\\");
            var dbCode = $@"var db = new SolutionMap.Database.SolutionMapDb(""{cn}"");";
            script = dbCode + Environment.NewLine + script;
            try
            {
                var results = Microsoft.CodeAnalysis.CSharp.Scripting.CSharpScript.EvaluateAsync(script, options).Result;
                ShowResults(results);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Script Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
