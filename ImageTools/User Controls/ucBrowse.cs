using System;
using System.IO;
using System.Windows.Forms;

namespace ImageTools.User_Controls
{
    public partial class ucBrowse : UserControl
    {
        public ucBrowse()
        {
            InitializeComponent();
        }



        private void btnBrowse_Click(object sender, EventArgs e)
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

        public override string Text
        {
            get { return txtPath.Text; }
            set { txtPath.Text = value; }
        }

    }
}
