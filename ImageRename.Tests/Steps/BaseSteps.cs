using System.IO;
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
    }
}