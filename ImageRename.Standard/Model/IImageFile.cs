using System;
using System.IO;

namespace ImageRename.Standard.Model
{
    public interface IImageFile
    {
        FileInfo DestinationFileInfo { get; }
        string DestinationFileName { get; }
        string DestinationFilePath { get; }
        GPSCoridates GPS { get; set; }
        DateTime? ImageCreated { get; }
        DateTime? ImageCreatedOriginal { get; }
        bool NeedsMoving { get; }
        bool NeedsRenaming { get; }
        FileInfo SourceFileInfo { get; set; }
    }
}