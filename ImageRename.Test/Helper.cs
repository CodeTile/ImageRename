using System.IO;

namespace ImageRename.Test
{
    public static class Helper
    {
        public static void DeleteDirectory(string relativePath)
        {
            string target = Path.GetFullPath(".") + relativePath;
            if (Directory.Exists(target))
            {
                Directory.Delete(target, true);
            }
            System.Threading.Thread.Sleep(211);
        }
        public static void DirectoryCopy( string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            var dirs = dir.EnumerateDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
                System.Threading.Thread.Sleep(200);
            }

            // Get the files in the directory and copy them to the new location.
            var files = dir.GetFiles();
            System.Threading.Thread.Sleep(200);
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                if(!File.Exists(file.FullName))
                {
                    throw new FileNotFoundException(file.FullName);
                }
                file.CopyTo(temppath,true);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                    System.Threading.Thread.Sleep(200);
                }
            }
        }
    }
}
