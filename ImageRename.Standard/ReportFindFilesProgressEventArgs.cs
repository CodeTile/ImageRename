using System;

namespace ImageRename.Standard
{
    public class ReportFindFilesProgressEventArgs : EventArgs
    {
        public int TotalFileCount { get; set; }
        public int FilesToRename { get; set; }
    }
}