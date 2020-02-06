using ImageRename.Tests.Context;
using TechTalk.SpecFlow;

namespace ImageRename.Tests.Steps
{
    [Binding]
    public class ExtensionSteps : BaseSteps
    {
        public ExtensionSteps(BaseContext context) : base(context)
        {
        }

        [Given(@"I test the coridantes")]
        public void GivenITestTheCoridantes(Table table)
        {
            throw new System.NotImplementedException();
        }

    }
}