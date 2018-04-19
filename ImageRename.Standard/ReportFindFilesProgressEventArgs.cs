using System;

namespace ImageRename.Core
{
    public class ReportFindFilesProgressEventArgs : EventArgs
    {
        public int TotalFileCount { get; set; }
        public int FilesToRename { get; set; }
    }
}