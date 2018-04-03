using System;
using System.IO;

namespace ImageRename.Core
{
    public class ProcessFolder
    {
        public void Process(string root)
        {
            if(!Directory.Exists(root))
            {
                throw new DirectoryNotFoundException(root);
            }
            FindFiles(root);
        }

        private void FindFiles(string root)
        {
            throw new NotImplementedException();
        }
    }
}
