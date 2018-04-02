using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;

namespace ImageTools
{
    class ImageDetails
    {
        private static System.Drawing.ImageConverter imageConverter;
        private FileInfo mFileInfo;

        private bool mIsDuplicate = false;

        public bool IsDuplicate
        {
            get { return mIsDuplicate; }
            set { mIsDuplicate = value; }
        }


        public FileInfo FileInfo
        {
            get { return mFileInfo; }
            set { mFileInfo = value; }
        }


        private Bitmap mBitmap;

        public Bitmap Bitmap
        {
            get { return mBitmap; }
            set { mBitmap = value; }
        }
        byte[] mHash = null;

        public byte[] Hash
        {
            get
            {
                if (mHash == null||mHash.Length ==0)
                {
                    imageConverter = new ImageConverter();
                    mHash = (byte[])imageConverter.ConvertTo(mBitmap, typeof(byte[]));
                    imageConverter = null;
                   
                }

                return mHash;
            }
            //set { mHash = value; }
        }

        //public Image Image { get; private set; }


    }//end class ImageDetails



}//end namespace
