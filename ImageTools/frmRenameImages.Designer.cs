namespace ImageTools
{
    partial class frmRenameImages
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnProcess = new System.Windows.Forms.Button();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProcessedCaption = new System.Windows.Forms.Label();
            this.lblRenamedCaption = new System.Windows.Forms.Label();
            this.lblXMPCaption = new System.Windows.Forms.Label();
            this.lblXMP = new System.Windows.Forms.Label();
            this.lblRenamed = new System.Windows.Forms.Label();
            this.lblProcessed = new System.Windows.Forms.Label();
            this.ucBrowse2 = new ImageTools.User_Controls.ucBrowse();
            this.chkMoveToYearFolder = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(18, 120);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtResults
            // 
            this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResults.Location = new System.Drawing.Point(13, 162);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ReadOnly = true;
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResults.Size = new System.Drawing.Size(831, 493);
            this.txtResults.TabIndex = 2;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(379, 128);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(433, 14);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 3;
            // 
            // lblProcessedCaption
            // 
            this.lblProcessedCaption.AutoSize = true;
            this.lblProcessedCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessedCaption.Location = new System.Drawing.Point(119, 120);
            this.lblProcessedCaption.Name = "lblProcessedCaption";
            this.lblProcessedCaption.Size = new System.Drawing.Size(60, 13);
            this.lblProcessedCaption.TabIndex = 4;
            this.lblProcessedCaption.Text = "Procesed";
            // 
            // lblRenamedCaption
            // 
            this.lblRenamedCaption.AutoSize = true;
            this.lblRenamedCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenamedCaption.Location = new System.Drawing.Point(221, 120);
            this.lblRenamedCaption.Name = "lblRenamedCaption";
            this.lblRenamedCaption.Size = new System.Drawing.Size(60, 13);
            this.lblRenamedCaption.TabIndex = 5;
            this.lblRenamedCaption.Text = "Renamed";
            // 
            // lblXMPCaption
            // 
            this.lblXMPCaption.AutoSize = true;
            this.lblXMPCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXMPCaption.Location = new System.Drawing.Point(311, 120);
            this.lblXMPCaption.Name = "lblXMPCaption";
            this.lblXMPCaption.Size = new System.Drawing.Size(33, 13);
            this.lblXMPCaption.TabIndex = 6;
            this.lblXMPCaption.Text = "XMP";
            // 
            // lblXMP
            // 
            this.lblXMP.Location = new System.Drawing.Point(303, 133);
            this.lblXMP.Name = "lblXMP";
            this.lblXMP.Size = new System.Drawing.Size(47, 14);
            this.lblXMP.TabIndex = 9;
            this.lblXMP.Text = "0";
            this.lblXMP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRenamed
            // 
            this.lblRenamed.Location = new System.Drawing.Point(221, 133);
            this.lblRenamed.Name = "lblRenamed";
            this.lblRenamed.Size = new System.Drawing.Size(60, 14);
            this.lblRenamed.TabIndex = 8;
            this.lblRenamed.Text = "0";
            this.lblRenamed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProcessed
            // 
            this.lblProcessed.Location = new System.Drawing.Point(119, 133);
            this.lblProcessed.Name = "lblProcessed";
            this.lblProcessed.Size = new System.Drawing.Size(57, 14);
            this.lblProcessed.TabIndex = 7;
            this.lblProcessed.Text = "0";
            this.lblProcessed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucBrowse2
            // 
            this.ucBrowse2.Location = new System.Drawing.Point(82, 12);
            this.ucBrowse2.Name = "ucBrowse2";
            this.ucBrowse2.Size = new System.Drawing.Size(576, 34);
            this.ucBrowse2.TabIndex = 11;
            // 
            // chkMoveToYearFolder
            // 
            this.chkMoveToYearFolder.AutoSize = true;
            this.chkMoveToYearFolder.Checked = true;
            this.chkMoveToYearFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMoveToYearFolder.Location = new System.Drawing.Point(82, 53);
            this.chkMoveToYearFolder.Name = "chkMoveToYearFolder";
            this.chkMoveToYearFolder.Size = new System.Drawing.Size(117, 17);
            this.chkMoveToYearFolder.TabIndex = 12;
            this.chkMoveToYearFolder.Text = "Move to year folder";
            this.chkMoveToYearFolder.UseVisualStyleBackColor = true; 
            // 
            // frmRenameImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 667);
            this.Controls.Add(this.chkMoveToYearFolder);
            this.Controls.Add(this.ucBrowse2);
            this.Controls.Add(this.lblXMP);
            this.Controls.Add(this.lblRenamed);
            this.Controls.Add(this.lblProcessed);
            this.Controls.Add(this.lblXMPCaption);
            this.Controls.Add(this.lblRenamedCaption);
            this.Controls.Add(this.lblProcessedCaption);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.btnProcess);
            this.Name = "frmRenameImages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rename Images";
            this.Load += new System.EventHandler(this.frmRenameImages_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProcessedCaption;
        private System.Windows.Forms.Label lblRenamedCaption;
        private System.Windows.Forms.Label lblXMPCaption;
        private System.Windows.Forms.Label lblXMP;
        private System.Windows.Forms.Label lblRenamed;
        private System.Windows.Forms.Label lblProcessed;
        private ImageTools.User_Controls.ucBrowse ucBrowse2;
        private System.Windows.Forms.CheckBox chkMoveToYearFolder;
    }
}