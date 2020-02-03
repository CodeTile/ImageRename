// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.1.0.0
//      SpecFlow Generator Version:3.1.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ImageRename.Tests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class ProcessFolderFeature : Xunit.IClassFixture<ProcessFolderFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "ProcessFolder.feature"
#line hidden
        
        public ProcessFolderFeature(ProcessFolderFeature.FixtureData fixtureData, ImageRename_Tests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-GB"), "ProcessFolder", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 4
#line hidden
#line 5
 testRunner.Given("I clear the testfiles folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="DontMoveTest")]
        [Xunit.TraitAttribute("FeatureTitle", "ProcessFolder")]
        [Xunit.TraitAttribute("Description", "DontMoveTest")]
        public virtual void DontMoveTest()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DontMoveTest", null, ((string[])(null)));
#line 7
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
this.FeatureBackground();
#line hidden
#line 8
 testRunner.Given("I create a copy of all test files in the folder \'ProcessFolderDontMoveTest\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table7.AddRow(new string[] {
                            "\\CR2\\20180408_122634.CR2"});
                table7.AddRow(new string[] {
                            "\\CR2\\Good.CR2"});
                table7.AddRow(new string[] {
                            "\\JPG\\Bad.jpg"});
                table7.AddRow(new string[] {
                            "\\JPG\\Good.jpg"});
                table7.AddRow(new string[] {
                            "\\JPG\\GPS.jpg"});
                table7.AddRow(new string[] {
                            "\\mov\\20160124_141023.MOV"});
                table7.AddRow(new string[] {
                            "\\mov\\Good.MOV"});
                table7.AddRow(new string[] {
                            "\\mov\\Good2.MOV"});
                table7.AddRow(new string[] {
                            "\\NEF\\20080601_020200.nef"});
                table7.AddRow(new string[] {
                            "\\NEF\\Good.nef"});
#line 9
 testRunner.And("the folder \'ProcessFolderDontMoveTest\' with subfolders contains", ((string)(null)), table7, "And ");
#line hidden
                TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                            "DebugDontRenameFile",
                            "MoveToProcessedByYear",
                            "ProcessedPath"});
                table8.AddRow(new string[] {
                            "false",
                            "false",
                            ""});
#line 22
 testRunner.When("I process the folder \'ProcessFolderDontMoveTest\' with the following flags", ((string)(null)), table8, "When ");
#line hidden
                TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table9.AddRow(new string[] {
                            "\\CR2\\20180408_072740.CR2"});
                table9.AddRow(new string[] {
                            "\\CR2\\20180408_122634.CR2"});
                table9.AddRow(new string[] {
                            "\\JPG\\20180310_115353.jpg"});
                table9.AddRow(new string[] {
                            "\\JPG\\Bad.jpg"});
                table9.AddRow(new string[] {
                            "\\JPG\\20200127_115041.jpg"});
                table9.AddRow(new string[] {
                            "\\mov\\20151129_093543.MOV"});
                table9.AddRow(new string[] {
                            "\\mov\\20160124_141020.MOV"});
                table9.AddRow(new string[] {
                            "\\mov\\20160124_141023.MOV"});
                table9.AddRow(new string[] {
                            "\\NEF\\20080601_020200.nef"});
                table9.AddRow(new string[] {
                            "\\NEF\\20080601_020200_2.nef"});
#line 26
 testRunner.Then("the folder \'ProcessFolderDontMoveTest\' with subfolders contains", ((string)(null)), table9, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="MoveTest")]
        [Xunit.TraitAttribute("FeatureTitle", "ProcessFolder")]
        [Xunit.TraitAttribute("Description", "MoveTest")]
        public virtual void MoveTest()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MoveTest", null, ((string[])(null)));
#line 39
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
this.FeatureBackground();
#line hidden
#line 40
 testRunner.Given("I create a copy of all test files in the folder \'ProcessFolderMoveTest\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table10.AddRow(new string[] {
                            "\\CR2\\20180408_122634.CR2"});
                table10.AddRow(new string[] {
                            "\\CR2\\Good.CR2"});
                table10.AddRow(new string[] {
                            "\\JPG\\Bad.jpg"});
                table10.AddRow(new string[] {
                            "\\JPG\\Good.jpg"});
                table10.AddRow(new string[] {
                            "\\JPG\\GPS.jpg"});
                table10.AddRow(new string[] {
                            "\\mov\\20160124_141023.MOV"});
                table10.AddRow(new string[] {
                            "\\mov\\Good.MOV"});
                table10.AddRow(new string[] {
                            "\\mov\\Good2.MOV"});
                table10.AddRow(new string[] {
                            "\\NEF\\20080601_020200.nef"});
                table10.AddRow(new string[] {
                            "\\NEF\\Good.nef"});
#line 41
 testRunner.And("the folder \'ProcessFolderMoveTest\' with subfolders contains", ((string)(null)), table10, "And ");
#line hidden
                TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                            "DebugDontRenameFile",
                            "MoveToProcessedByYear",
                            "ProcessedPath"});
                table11.AddRow(new string[] {
                            "false",
                            "true",
                            "ProcessFolderMoveTestProcessed"});
#line 54
 testRunner.When("I process the folder \'ProcessFolderMoveTest\' with the following flags", ((string)(null)), table11, "When ");
#line hidden
                TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table12.AddRow(new string[] {
                            "\\2008\\Q2\\20080601_020200.nef"});
                table12.AddRow(new string[] {
                            "\\2008\\Q2\\20080601_020200_2.nef"});
                table12.AddRow(new string[] {
                            "\\2015\\Q4\\20151129_093543.MOV"});
                table12.AddRow(new string[] {
                            "\\2016\\Q1\\20160124_141020.MOV"});
                table12.AddRow(new string[] {
                            "\\2016\\Q1\\20160124_141023.MOV"});
                table12.AddRow(new string[] {
                            "\\2018\\Q1\\20180310_115353.jpg"});
                table12.AddRow(new string[] {
                            "\\2018\\Q2\\20180408_072740.CR2"});
                table12.AddRow(new string[] {
                            "\\2018\\Q2\\20180408_122634.CR2"});
                table12.AddRow(new string[] {
                            "\\2020\\Q1\\20200127_115041.jpg"});
#line 58
 testRunner.Then("the folder \'ProcessFolderMoveTestProcessed\' with subfolders contains", ((string)(null)), table12, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table13.AddRow(new string[] {
                            "\\JPG\\Bad.jpg"});
#line 69
 testRunner.And("the folder \'ProcessFolderMoveTest\' with subfolders contains", ((string)(null)), table13, "And ");
#line hidden
                TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table14.AddRow(new string[] {
                            "\\JPG"});
#line 72
 testRunner.And("the folder \'ProcessFolderMoveTest\' has subfolders", ((string)(null)), table14, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.1.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                ProcessFolderFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                ProcessFolderFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
