﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ImageRename.Test
{
    public static class Helper
    {

        public static string TestSourceFolder { get; } = Path.GetFullPath(".\\Test Files");

        public static void DeleteDirectory(string path, bool isRelative = true)
        {
            if (isRelative)
            {
                path = Path.GetFullPath(path);
            }
            if (Directory.Exists(path))
            {
                Debug.WriteLine($"{DateTime.Now.ToLongTimeString()} Delete ==> {path}");
                Directory.Delete(path, true);
            }
        }

        public static void CopyTestFilesTo(string destinationFolder)
        {
            // DeleteDirectory(destinationFolder, true);
            var originalPath = Path.GetFullPath(".\\Test Files");
            var fullDestination = Path.GetFullPath(destinationFolder);
            DirectoryCopy(originalPath, fullDestination);
            RemoveFilesNotInSource(originalPath, fullDestination);
        }

        private static void RemoveFilesNotInSource(string source, string destination)
        {
            var sourceFiles = Directory.GetFiles(source, "*", SearchOption.AllDirectories)
                             .Select(s => s.Replace(source, string.Empty)).ToList();
            var destinationFiles = Directory.GetFiles(destination, "*", SearchOption.AllDirectories)
                               .Select(s => s.Replace(destination, string.Empty)).ToList();
            var destinationFilesToDelete = destinationFiles.Except(sourceFiles).ToList();
            foreach (var item in destinationFilesToDelete)
            {
                var path = destination + item;
                if (!File.Exists(path))
                {
                    continue;
                }
                File.Delete(path);
            }
        }
        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Debug.WriteLine($"{DateTime.Now.ToLongTimeString()} Create  ==> {path}");
                Directory.CreateDirectory(path);
            }
        }
        public static void DirectoryCopy(string sourceDirName, string destDirName)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles().Where(w => !w.Extension.Equals(".db", StringComparison.CurrentCultureIgnoreCase)).ToArray();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                if (!File.Exists(temppath))
                {
                    Debug.WriteLine($"{DateTime.Now.ToLongTimeString()} Copy to ==> {temppath}");
                    file.CopyTo(temppath, false);
                }
            }

            // If copying subdirectories, copy them and their contents to new location.
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(subdir.FullName, temppath);
            }
        }
        
        internal static void DuplicateFile(string root, string original, string duplicate)
        {
            var originalPath = new FileInfo(Path.Combine(root, original));
            var duplicatePath = new FileInfo(Path.Combine(root, duplicate));
            if (!originalPath.Exists)
            {
                throw new FileNotFoundException($"\r\nSource file does not exist.\r\n\t{originalPath.FullName}");
            }
            CreateDirectory(duplicatePath.DirectoryName);

            if (!duplicatePath.Exists)
            {
                Debug.WriteLine($"{DateTime.Now.ToLongTimeString()} Copy to ==> {duplicatePath}");
                originalPath.CopyTo(duplicatePath.FullName, false);
            }
        }
    }
}
