using SolutionMap.DataImport;

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

    }
}
