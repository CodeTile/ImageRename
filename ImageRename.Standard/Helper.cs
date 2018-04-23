using System.IO;

namespace ImageRename.Standard
{
    public static class Helper
    {
        internal static void CreateDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}
