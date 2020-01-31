using System;
using ImageRename.Tests;

namespace ImageRename.Tests.Context
{
    public class BaseContext : IDisposable,IBaseContext
    {
        public BaseContext()
        {
            //TimeProvider.ResetToDefault();
        }
        public TimeProvider TimeProvider { get;  set; }
        public dynamic SUT { get; set; }

        public void Dispose()
        {
           //TimeProvider.ResetToDefault();
        }
    }

    internal interface IBaseContext
    {
        TimeProvider TimeProvider { get;  set; }
        dynamic SUT { get; set; }
    }
}