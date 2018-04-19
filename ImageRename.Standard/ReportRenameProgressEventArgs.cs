using System;

namespace ImageRename.Core
{
    public class ReportRenameProgressEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}