using System.IO;
using System.Linq;
using ImageRename.Tests.Context;
using Microsoft.Extensions.Configuration;

namespace ImageRename.Tests.Steps
{
    public abstract class BaseSteps
    {
        protected readonly IConfiguration Configuration;
        protected BaseContext Context;

        /// <summary>
        /// Original Test File folder
        /// </summary>
        public string OriginalFolder => Helper.TestFilesSourceFolder;
        public string TestFileFolder => Helper.TestFilesFolder;
        public BaseSteps(BaseContext context)
        {
            Configuration = TestHelper.GetConfiguration();
            Context = context;
        }
        public string GetFilesList(string header, string targetPath, ref string[] targetContent)
        {
            if (targetContent == null || !targetContent.Any())
            {
                targetContent = Directory.GetFiles(targetPath, "*", SearchOption.AllDirectories);
            }

            var retval = $"\r\n{header}:\r\n\t{string.Join("\r\n\t", targetContent).Replace(targetPath, string.Empty)}";

            return retval;
        }
        public void Wait(int milliSeconds)
        {
            System.Threading.Thread.Sleep(milliSeconds);
        }
    }
}