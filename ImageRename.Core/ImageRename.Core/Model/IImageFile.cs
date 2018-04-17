using System;
using System.IO;

namespace ImageRename.Core.Model
{
    public interface IImageFile
    {
        FileInfo FileDetails { get; set; }
        DateTime? ImageCreated { get; }
        bool NeedsRenaming { get; }
        bool NeedsMoving { get; }
        string ProcessedFileName { get; }
        string ProcessedFullName { get; }
        string ProcessedDirectory { get; }
    }
}