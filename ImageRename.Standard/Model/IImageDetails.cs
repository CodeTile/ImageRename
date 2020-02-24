using System;
using System.IO;

namespace ImageRename.Standard.Model
{
    public interface IImageDetails
    {
        FileInfo DestinationFileInfo { get; }
        string DestinationFileName { get; }
        string DestinationFilePath { get; }
        IGPSCoridates GPS { get; set; }
        DateTime? ImageCreated { get; }
        DateTime? ImageCreatedOriginal { get; }
        string KeyWords { get; set; }
        bool NeedsMoving { get; }
        bool NeedsRenaming { get; }
        string OriginalKeywords { get; set; }
        FileInfo SourceFileInfo { get; set; }
        bool HasInternet { get; set; }
    }
}