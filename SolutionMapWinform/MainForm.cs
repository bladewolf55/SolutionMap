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

        #endregion


        #region "Events"

        private void buttonSqliteDatabaseFolder_Click(object sender, EventArgs e)
        {
            ShowFolderBrowserDialog(textBoxSqliteDatabaseFolder);
        }

        private void buttonSolutionsFolder_Click(object sender, EventArgs e)
        {
            ShowFolderBrowserDialog(textBoxSolutionsFolder);
        }

        #endregion
    }
}
