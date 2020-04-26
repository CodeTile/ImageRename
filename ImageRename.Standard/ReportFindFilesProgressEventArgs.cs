using System;
using System.Collections.ObjectModel;
using ImageRename.Standard.Model;

namespace ImageRename.Standard
{
    public class ReportFindFilesProgressEventArgs : EventArgs
    {
        public int TotalFileCount { get; set; }
        public int FilesToRename { get; set; }
        public ObservableCollection<IImageDetails> Images { get; internal set; }
    }
}