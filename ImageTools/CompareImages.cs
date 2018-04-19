using System;
using System.Collections.Generic;
using System.IO ;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.ComponentModel;


namespace ImageTools
{


 

    public class CompareImages
    {
        System.Collections.ArrayList mImages;

        //int iFileCount = 0;

        BackgroundWorker worker;


        #region Properties
        public bool KeepImages { get; set; }
        private string mSourceFolder;

        public string SourceFolder
        {
            get { return mSourceFolder; }
            set { mSourceFolder = value; }
        }
        private string mDuplictesFolder;

        public string DuplicatesFolder
        {
            get { return mDuplictesFolder; }
            set { mDuplictesFolder = value; }
        } 
	#endregion

        #region GO
		        public void GO(string sourcefolder, string duplicatesfolder)
        {
            //pass in the parameters
            SourceFolder = sourcefolder;
            DuplicatesFolder = duplicatesfolder;
            //start the event
            //run the main Go Method
            GO();
        }



        public void GO()
        {


            //Create duplicates file if it does not exist
            if (Directory.Exists(DuplicatesFolder)  == false)
            {
                Directory.CreateDirectory(DuplicatesFolder);
            }

            //clear class level variables
            mImages = new System.Collections.ArrayList();
            //Get Image Details
            GetFileNames(SourceFolder);


            if (mImages.Count > 1)
            {
                //Compare Images
                decimal iImagesProcessed = 0;
                int  iProgress = 0;
                decimal iOriginalCount = mImages.Count;

                foreach (ImageDetails CompareImage in mImages)
                {
                    CompareAllImages(CompareImage);
                    iImagesProcessed+=1;
                    iProgress = Convert.ToInt32(100 * (iImagesProcessed / iOriginalCount));

                    worker.ReportProgress(iProgress, "Files Left To Process " + (mImages.Count - iImagesProcessed).ToString());

                }
            }
        }

	    #endregion
        #region CompareAllImages

        private void CompareAllImages(ImageDetails masterimage)
        {
            if (masterimage.IsDuplicate == true ||
                masterimage.FileInfo.FullName.ToUpper().StartsWith(DuplicatesFolder.ToUpper()))
            {
                return;
            }
            foreach (ImageDetails CompareImage in mImages)
            {
                if (masterimage.FileInfo.FullName != CompareImage.FileInfo.FullName &&
                    CompareImage.IsDuplicate == false)
                {
                    CompareImage.IsDuplicate = IsImageDuplicate(masterimage, CompareImage);
                    if (CompareImage.IsDuplicate == true)
                    {
                        string newFilename = CompareImage.FileInfo.FullName;
                        newFilename = newFilename.Replace(SourceFolder, DuplicatesFolder);
                        MoveFile(CompareImage.FileInfo.FullName, newFilename);
                    }
                }
            }//end foreach
        }// end CompareAllImages
        
        #endregion
        #region MoveFile
        private void MoveFile(string OldFilename, string newFilename)
        {
            if (KeepImages &&
                File.Exists(newFilename) == false &&
                File.Exists(OldFilename))
            {
                File.Copy(OldFilename, newFilename);

            }
            if (File.Exists(OldFilename))
            {
                File.Delete(OldFilename);
            }
        }
        
        #endregion

        #region IsImageDuplicate
        private bool IsImageDuplicate(ImageDetails masterimage, ImageDetails compareimage)
        {
            bool bReturn = false;
            byte[] source;
            byte[] tocompare;

            if (masterimage.FileInfo.Length == compareimage.FileInfo.Length &&
                masterimage.Hash.Length == compareimage.Hash.Length)
            {
                //for speed copy to local variables.
                source = masterimage.Hash;
                tocompare = compareimage.Hash;

                ////Compare the hash values
                //for (int i = 0; i < hash1.Length && i < hash2.Length 
                //                  && cr == CompareResult.ciCompareOk; i++)
                //{
                //    if (hash1[i] != hash2[i])
                //        cr = CompareResult.ciPixelMismatch;
                //}
                bReturn = true;
                for (int i = 0; i < source.Length && i < tocompare.Length; i++)
                {
                    if (source[i] != tocompare[i])
                        bReturn = false;
                }
            }

            return bReturn;
        }

        
        #endregion

        #region GetFileNames
        private void GetFileNames(string pPath)
        {
            if (pPath.ToUpper().StartsWith(DuplicatesFolder.ToUpper()))
            {
                return;
            }

            #region process Childfolders
            //process Childfolders
            if (pPath != DuplicatesFolder)
            {
                foreach (string child in System.IO.Directory.GetDirectories(pPath))
                {
                    GetFileNames(child);
                }
            }// end if 
            #endregion

            //process Files in this folder
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(pPath);
            string sFilter = "*.ico";
            string[] sFilters = sFilter.Split(';');

            ImageDetails idLocal;
            foreach (string Filter in sFilters)
            {
                foreach (System.IO.FileInfo f in dir.GetFiles(Filter))
                {
                    idLocal = new ImageDetails();
                    idLocal.FileInfo = f;
                    idLocal.Bitmap = ImageToBitmap(f.FullName);

                    if (idLocal.Bitmap != null)
                    {
                        //add to the master arraylist
                        mImages.Add(idLocal);
                        //raise a notification event
                        worker.ReportProgress(0, "Reading Images - " + mImages.Count.ToString("#,##0"));
                    }

                }// end for each file
            }// end for each filter
        }//end void getfilenames
        
        #endregion


        #region ImageToBitmap


        private Bitmap ImageToBitmap(string p)
        {
            try
            {

                Bitmap bmpReturn;
             

                Icon i = new Icon(p);
                bmpReturn = i.ToBitmap();


                return bmpReturn;
            }
            catch (Exception)
            {

                return null;
            }

        }// end ImageToBitmap 
        #endregion

        #region bw_DoWork
        internal void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            worker = sender as BackgroundWorker;

            for (int i = 1; (i <= 10); i++)
            {
                if ((worker.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    GO();
                }
            }
        } 
        #endregion


    }//end class
}//end namespace
