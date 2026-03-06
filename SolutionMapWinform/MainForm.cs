using LINQPad;
using NTextEditor.Languages.CSharp;
using NTextEditor.View.Winforms;
using SolutionMap.DataImport;
using SolutionMap.Domain.Models;
using SolutionMapWinform.Properties;

namespace SolutionMapWinform
{
    public partial class MainForm : Form
    {
        private const string sqliteDatabaseFileName = "solutionmap.db";
        public MainForm()
        {
            InitializeComponent();
        }

        #region "Methods"

        private void InitializeControls()
        {
            codeEditorBox.SetLanguageToCSharp(isLibrary: false);
            codeEditorBox.Dock = DockStyle.Fill;
            webView2Results.Dock = DockStyle.Fill;
            panelWebView.Dock = DockStyle.Fill;
            splitContainer.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            SetStatus();
            // TODO: Why can't this control receive focus? .CanFocus = false.
            codeEditorBox.Focus();
        }

        private string GetSqliteConnectionString() => $"Data Source={AppSettings.GetSqliteDatabaseFilePath()}";


        private async void ShowResults(params object[] results)
        {
            var df = Util.BrowserEngine.GetWebView2DataFolder();
            var ef = Util.BrowserEngine.GetWebView2ExecutableFolder();

            var html = Util.ToHtmlString(enableExpansions: true, results);

            var tempPath = Path.GetTempPath();
            var temp = Path.Join(tempPath, "solutionMap.html");
            File.WriteAllText(temp, html);
            var uri = new Uri(new Uri(temp).AbsoluteUri);
            webView2Results.Source = new Uri("about:blank");
            webView2Results.Source = uri;
        }

        private void SetStatus()
        {
            var text = $"Solution folder: {Settings.Default.SolutionsFolder}";
            var db = new SolutionMap.Database.SolutionMapDb(GetSqliteConnectionString());
            text += " Database state: ";
            if (!db.Database.CanConnect())
            {
                text += "Connection failed. Try importing.";
            }
            else
            {
                try
                {
                    var solutionCount = db.Solutions.Count();
                    text += $"Solution count = {solutionCount}";

                }
                catch (Exception ex)
                {
                    text += $"Could not retrieve solutions. Try importing";
                }
            }
            labelSolutionsFolder.Text = text;
        }

        private void Evaluate()
        {
            var script = codeEditorBox.GetText();
            var options = Microsoft.CodeAnalysis.Scripting.ScriptOptions.Default
                .AddReferences(typeof(Solution).Assembly)
                .AddImports("System", "System.Linq", "SolutionMap.Domain.Models", "SolutionMap.Database");
            var cn = GetSqliteConnectionString().Replace(@"\", @"\\");
            var dbCode = $@"var db = new SolutionMap.Database.SolutionMapDb(""{cn}"");";
            script = dbCode + Environment.NewLine + script;
            var results = Microsoft.CodeAnalysis.CSharp.Scripting.CSharpScript.EvaluateAsync(script, options).Result;
            ShowResults(results);
        }

        #endregion


        #region "Events"

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeControls();
        }


        private void buttonEvaluate_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Evaluate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void buttonImportForm_Click(object sender, EventArgs e)
        {
            var form = new ImportForm();
            form.ShowDialog();
            SetStatus();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                e.Handled = true;
                try
                {
                    Cursor = Cursors.WaitCursor;
                    Evaluate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        #endregion
    }
}
