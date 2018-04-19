namespace ImageTools
{
    partial class frmCompareImages
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
             System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompareImages));
             this.lblSourceFolder = new System.Windows.Forms.Label();
            this.lblDuplicateFolder = new System.Windows.Forms.Label();
            this.btnCompare = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            //this.ucDuplicateFolder = new ImageTools.User_Controls.ucBrowse();
            //this.ucSourceFolder = new ImageTools.User_Controls.ucBrowse();
            this.chkKeepImages = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblSourceFolder
            // 
            this.lblSourceFolder.AutoSize = true;
            this.lblSourceFolder.Location = new System.Drawing.Point(12, 18);
            this.lblSourceFolder.Name = "lblSourceFolder";
            this.lblSourceFolder.Size = new System.Drawing.Size(41, 13);
            this.lblSourceFolder.TabIndex = 1;
            this.lblSourceFolder.Text = "Source";
            // 
            // lblDuplicateFolder
            // 
            this.lblDuplicateFolder.AutoSize = true;
            this.lblDuplicateFolder.Location = new System.Drawing.Point(12, 48);
            this.lblDuplicateFolder.Name = "lblDuplicateFolder";
            this.lblDuplicateFolder.Size = new System.Drawing.Size(57, 13);
            this.lblDuplicateFolder.TabIndex = 3;
            this.lblDuplicateFolder.Text = "Duplicates";
            // 
            
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(15, 84);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 62);
            this.btnCompare.TabIndex = 4;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // ultraGauge1
            // 
        
            // 
       
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(233, 186);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(287, 23);
            this.progressBar1.TabIndex = 8;
          
            // 
            // chkKeepImages
            // 
            this.chkKeepImages.AutoSize = true;
            this.chkKeepImages.Checked = true;
            this.chkKeepImages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeepImages.Location = new System.Drawing.Point(20, 162);
            this.chkKeepImages.Name = "chkKeepImages";
            this.chkKeepImages.Size = new System.Drawing.Size(88, 17);
            this.chkKeepImages.TabIndex = 9;
            this.chkKeepImages.Text = "Keep Umage";
            this.chkKeepImages.UseVisualStyleBackColor = true;
            // 
            // frmCompareImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 264);
            this.Controls.Add(this.chkKeepImages);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.lblDuplicateFolder);
            this.Controls.Add(this.lblSourceFolder);
            this.Name = "frmCompareImages";
            this.Text = "Compare Images";
            this.Load += new System.EventHandler(this.frmCompareImages_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSourceFolder;
        private System.Windows.Forms.Label lblDuplicateFolder;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox chkKeepImages;
    }
}