using System;
using System.IO;
using System.Windows.Forms;

namespace ImageRename
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnFindPath_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtPath.Text))
            {
                folderBrowserDialog1.SelectedPath = txtPath.Text;
            }
            folderBrowserDialog1.ShowNewFolderButton = true;

            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog1.SelectedPath.ToString();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(Properties.Settings.Default.Path) &&
                Directory.Exists(Properties.Settings.Default.Path))
            {
                txtPath.Text = Properties.Settings.Default.Path;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtPath.Text))
            {
                throw new DirectoryNotFoundException(txtPath.Text);
            }
        }
    }
}
