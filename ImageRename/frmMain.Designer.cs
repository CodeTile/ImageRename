namespace ImageRename
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnFindPath = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnProcess = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileSummary = new System.Windows.Forms.TextBox();
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.chkMoveToProcessedByYear = new System.Windows.Forms.CheckBox();
            this.btnProcessedBrowse = new System.Windows.Forms.Button();
            this.txtProcessedPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path";
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(108, 22);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(529, 20);
            this.txtPath.TabIndex = 1;
            this.txtPath.Leave += new System.EventHandler(this.txtPath_Leave);
            // 
            // btnFindPath
            // 
            this.btnFindPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindPath.Location = new System.Drawing.Point(643, 20);
            this.btnFindPath.Name = "btnFindPath";
            this.btnFindPath.Size = new System.Drawing.Size(29, 23);
            this.btnFindPath.TabIndex = 2;
            this.btnFindPath.Text = "...";
            this.btnFindPath.UseVisualStyleBackColor = true;
            this.btnFindPath.Click += new System.EventHandler(this.btnFindPath_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(31, 169);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(131, 33);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Images Found";
            // 
            // txtFileSummary
            // 
            this.txtFileSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileSummary.Location = new System.Drawing.Point(108, 94);
            this.txtFileSummary.Multiline = true;
            this.txtFileSummary.Name = "txtFileSummary";
            this.txtFileSummary.ReadOnly = true;
            this.txtFileSummary.Size = new System.Drawing.Size(564, 69);
            this.txtFileSummary.TabIndex = 5;
            // 
            // txtProgress
            // 
            this.txtProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProgress.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProgress.Location = new System.Drawing.Point(31, 208);
            this.txtProgress.Multiline = true;
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.ReadOnly = true;
            this.txtProgress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProgress.Size = new System.Drawing.Size(641, 141);
            this.txtProgress.TabIndex = 6;
            // 
            // chkMoveToProcessedByYear
            // 
            this.chkMoveToProcessedByYear.AutoSize = true;
            this.chkMoveToProcessedByYear.Checked = true;
            this.chkMoveToProcessedByYear.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMoveToProcessedByYear.Location = new System.Drawing.Point(108, 49);
            this.chkMoveToProcessedByYear.Name = "chkMoveToProcessedByYear";
            this.chkMoveToProcessedByYear.Size = new System.Drawing.Size(172, 17);
            this.chkMoveToProcessedByYear.TabIndex = 7;
            this.chkMoveToProcessedByYear.Text = "Move file to processed by Year";
            this.chkMoveToProcessedByYear.UseVisualStyleBackColor = true;
            // 
            // btnProcessedBrowse
            // 
            this.btnProcessedBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcessedBrowse.Location = new System.Drawing.Point(643, 70);
            this.btnProcessedBrowse.Name = "btnProcessedBrowse";
            this.btnProcessedBrowse.Size = new System.Drawing.Size(29, 23);
            this.btnProcessedBrowse.TabIndex = 10;
            this.btnProcessedBrowse.Text = "...";
            this.btnProcessedBrowse.UseVisualStyleBackColor = true;
            this.btnProcessedBrowse.Click += new System.EventHandler(this.btnProcessedBrowse_Click);
            // 
            // txtProcessedPath
            // 
            this.txtProcessedPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcessedPath.Location = new System.Drawing.Point(108, 72);
            this.txtProcessedPath.Name = "txtProcessedPath";
            this.txtProcessedPath.Size = new System.Drawing.Size(529, 20);
            this.txtProcessedPath.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Processed path";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.btnProcessedBrowse);
            this.Controls.Add(this.txtProcessedPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkMoveToProcessedByYear);
            this.Controls.Add(this.txtProgress);
            this.Controls.Add(this.txtFileSummary);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnFindPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "frmMain";
            this.Text = "Rename Images";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnFindPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFileSummary;
        private System.Windows.Forms.TextBox txtProgress;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox chkMoveToProcessedByYear;
        private System.Windows.Forms.Button btnProcessedBrowse;
        private System.Windows.Forms.TextBox txtProcessedPath;
        private System.Windows.Forms.Label label3;
    }
}

