﻿using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using ImageRename.Core;

namespace ImageRename
{
    public partial class frmMain : Form
    {
        private ProcessFolder _processor;


        public frmMain()
        {
            InitializeComponent();
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;

        }

        private void _processor_ReportProgress(object sender, ReportProgressEventArgs e)
        {
            var msg = e.Message.ToString();
            backgroundWorker1.ReportProgress(0, msg);
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtProgress.AppendText("#######################################\r\n");
            txtProgress.AppendText("###          Finished               ###\r\n");
            txtProgress.AppendText("#######################################\r\n");
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            txtProgress.AppendText($"{e.UserState.ToString()}\r\n");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            _processor = new ProcessFolder()
            {
                DebugDontRenameFile = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["DebugDontRenameFile"])
            };
            _processor.ReportProgress += _processor_ReportProgress;
            backgroundWorker1.ReportProgress(0, "Starting");
            _processor.Process(e.Argument.ToString());
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
            if (!string.IsNullOrEmpty(Properties.Settings.Default.Path) &&
                Directory.Exists(Properties.Settings.Default.Path))
            {
                txtPath.Text = Properties.Settings.Default.Path;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            txtProgress.Clear();
            backgroundWorker1.RunWorkerAsync(txtPath.Text);
        }
    }
}