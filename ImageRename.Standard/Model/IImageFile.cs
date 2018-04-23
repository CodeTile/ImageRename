using System;
using System.IO;

namespace ImageRename.Standard.Model
{
    public interface IImageFile
    {
        FileInfo SourceFileInfo { get; set; }
        FileInfo DestinationFileInfo { get; }
        DateTime? ImageCreated { get; }
        bool NeedsRenaming { get; }
        bool NeedsMoving { get; }
        string DestinationFileName { get; }
        string DestinationFilePath { get; }
    }
}