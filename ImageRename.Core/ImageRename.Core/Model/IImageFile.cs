using System;
using System.IO;

namespace ImageRename.Core.Model
{
    public interface IImageFile
    {
        FileInfo FileDetails { get; }
        DateTime? ImageCreated { get; }
        bool NeedsRenaming { get; }
        string NewFileName { get; }
        string NewFilePath { get; }
    }
}