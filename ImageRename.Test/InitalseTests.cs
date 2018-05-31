using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageRename.Test
{
    [TestClass()]
    public sealed class InitalseTests
    {
        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            var originalFolder = Path.GetFullPath(".\\..\\..\\Test Files");

            // As we need the file timestamp for MOV's
            File.SetCreationTime(Path.Combine(originalFolder, "mov\\20160124_141026.MOV"), Convert.ToDateTime("24 Jan 2016 14:10:26"));
            File.SetCreationTime(Path.Combine(originalFolder, "mov\\Good.MOV"), Convert.ToDateTime("24 January 2016 14:10:22"));
            File.SetCreationTime(Path.Combine(originalFolder, "mov\\Good2.MOV"), Convert.ToDateTime("29 November 2015 09:35:44"));

        }
    }
}
