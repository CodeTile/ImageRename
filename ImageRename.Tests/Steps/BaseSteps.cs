using ImageRename.Tests.Context;
using Microsoft.Extensions.Configuration;

namespace ImageRename.Tests.Steps
{
    public abstract class BaseSteps
    {
        protected readonly IConfiguration Configuration;
        protected BaseContext Context;

        public BaseSteps(BaseContext context)
        {
            Configuration = TestHelper.GetConfiguration();
            Context = context;
        }
    }
}