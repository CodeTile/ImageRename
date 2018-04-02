using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
 
namespace ImageTools
{

    //public class NewImageAddedListener
    //{
    //    public void ShowOnScreen(object o, NewImageAddedEventArgs  e)
    //    {
    //        Console.WriteLine(
    //            "divisible by seven event raised!!! the guilty party is {0}",
    //            e.TotalImages);
    //    }
    //}

    public partial class frmCompareImages : Form
    {


        public frmCompareImages()
        {
            InitializeComponent();
             
        }

        #region frmCompareImages_Load
        private void frmCompareImages_Load(object sender, EventArgs e)
        {
            ucSourceFolder.Text = "c:\\_icons".ToUpper();
            ucDuplicateFolder.Text = ucSourceFolder.Text + "\\Duplicates".ToUpper();
        }
        
        #endregion
        #region btnCompare_Click
        private void btnCompare_Click(object sender, EventArgs e)
        {
           CompareImages ci = new CompareImages();
            BackgroundWorker bw = new BackgroundWorker();

           // ci.bw_PassBw(ref bw);
            ci.SourceFolder = ucSourceFolder.Text;
            ci.DuplicatesFolder = ucDuplicateFolder.Text;
            ci.KeepImages = chkKeepImages.Checked;
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;


            bw.DoWork +=                new DoWorkEventHandler(ci.bw_DoWork);
            bw.ProgressChanged +=       new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted +=    new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            
            bw.RunWorkerAsync();
        }
        #endregion


      

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Text= (e.ProgressPercentage.ToString() + "% - "+ e.UserState.ToString());
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                this.Text = "Canceled!";
            }

            else if (!(e.Error == null))
            {
                this.Text = ("Error: " + e.Error.Message);
            }

            else
            {
                this.Text = "Done!";
            }
        }


        //////////////////////////////////////////////////////////////////

    }
}
