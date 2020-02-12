using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using ExifLibrary;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ImageRename.Tests
{
    public static class Helper
    {
        public static string TestFilesFolder { get; } = Path.GetFullPath("..\\Test Files");

        public static string TestFilesSourceFolder { get; } = Path.GetFullPath(".\\..\\..\\..\\Test Files");

        /// <summary>
        /// Remove any files that do not exist in the source folder
        /// </summary>
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

        public static DateTime ConvertToDateTime(string value)
        {
            return ConvertToDateTime(value, Convert.ToDateTime(TimeProvider.Current.Now));
        }

        public static DateTime ConvertToDateTime(string value, DateTime currentDateTime)
        {
            DateTime retVal;
            switch (value.ToLower())
            {
                case "<<today>>":
                case "<<now>>":
                    retVal = currentDateTime;
                    break;

                case "<<yesterday>>":
                    retVal = currentDateTime.AddDays(-1);
                    break;

                case "<<yearstart>>":
                    retVal = new DateTime(currentDateTime.Year, 1, 1);
                    break;

                case "<<monthstart>>":
                    retVal = new DateTime(currentDateTime.Year, currentDateTime.Month, 1);
                    break;

                case "<<mondaylastweek>>":
                    retVal = currentDateTime.AddDays(-7).GetDayInWeek(DayOfWeek.Monday);
                    break;

                case "<<fridaylastweek>>":
                    retVal = currentDateTime.AddDays(-7).GetDayInWeek(DayOfWeek.Friday);
                    break;

                default:
                    retVal = Convert.ToDateTime(value);
                    break;
            }

            if (retVal.Year == 1)
            {
                throw new ArgumentOutOfRangeException(value, $"parameter '{nameof(value)}' value '{value}' is out of range");
            }
            return retVal;
        }

        internal static void WriteKeywords(string filename, string keywords)
        {
            if (filename.Contains("<<DEBUG>>"))
            {
                return;
            }
            var filePath = Path.Combine(TestFilesFolder, filename);
            var file = ExifLibrary.ImageFile.FromFile(filePath);
            file.Properties.Set(ExifTag.WindowsKeywords, keywords);
            file.Save(filePath);
        }

        /// <summary>
        /// Create a copy of all test files.
        /// </summary>
        /// <param name="destinationFolder"></param>
        public static void CopyTestFilesTo(string destinationFolder)
        {
            // DeleteDirectory(destinationFolder, true);
            var originalPath = Path.GetFullPath(".\\Test Files");
            var fullDestination = Path.GetFullPath(destinationFolder);
            DirectoryCopy(originalPath, fullDestination);
            RemoveFilesNotInSource(originalPath, fullDestination);
        }

        /// <summary>
        /// Create a copy of a test file
        /// </summary>
        public static void CopyTestFileTo(string source, string destination)
        {
            var target = new FileInfo(destination);
            CreateDirectory(target.DirectoryName);

            if (!target.Exists)
            {
                Debug.WriteLine($"{DateTime.Now.ToLongTimeString()} Copy to ==> {target.FullName}");
                File.Copy(source, target.FullName, false);
            }
        }

        /// <summary>
        /// Create a directory if it does not exist.
        /// </summary>
        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Debug.WriteLine($"{DateTime.Now.ToLongTimeString()} Create  ==> {path}");
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// Delete a test file.
        /// </summary>
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

        public static void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        /// <summary>
        /// Copy the complete contents of a directory
        /// </summary>
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

        /// <summary>
        /// Duplicate a testfile
        /// </summary>
        public static void DuplicateFile(string root, string original, string duplicate)
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

        public static IConfiguration GetConfiguration(string settingsFileName = "appsettings.json")
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), settingsFileName);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(path, optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables();

#if DEBUG
            path = Path.Combine(Directory.GetCurrentDirectory(), "secrets.json");
            if (File.Exists(path))
            {
                builder.AddJsonFile(path, optional: false, reloadOnChange: true);
            }
#endif
            return builder.Build();
        }

        public static ILogger<T> GetILoggerFactory<T>()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddConsole();
                //.AddEventLog();
            });

            return loggerFactory.CreateLogger<T>();
        }

        public static List<T> ToList<T>(dynamic[] source)
        {
            var retVal = new List<T>();
            foreach (var item in source)
            {
                retVal.Add(JsonSerializer.Deserialize<T>(item.ToString()));
            }
            return retVal;
        }
    }
}