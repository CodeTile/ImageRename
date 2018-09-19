using System.IO;

namespace ImageRename.Standard
{
    public static class Helper
    {
        /// <summary>
        /// Create a directory if it does not exist
        /// </summary>
        internal static void CreateDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}