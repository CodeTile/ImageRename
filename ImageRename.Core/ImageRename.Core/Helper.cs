using System.IO;

namespace ImageRename.Core
{
    public static class Helper
    {
        public static void CreateDirectory(string relativePath, bool isFullPath = false)
        {
            string target;
            if(isFullPath)
            {
                target = relativePath;
            }
            else
            {
                target = Path.GetFullPath(".") + relativePath;
            }
            if (!Directory.Exists(target))
            {
                Directory.CreateDirectory(target);
            }
        }
    }
}
