namespace SolutionMapWinform
{
    public partial class MainForm : Form
    {
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

        #endregion


        #region "Events"

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
