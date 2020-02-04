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
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Path"});
            table8.AddRow(new string[] {
                        "ProcessFolderDontMoveTest"});
            table8.AddRow(new string[] {
                        "ProcessFolderMoveTest"});
            table8.AddRow(new string[] {
                        "ProcessFolderMoveTestProcessed"});
            table8.AddRow(new string[] {
                        "ProcessFolderMoveTest2"});
            table8.AddRow(new string[] {
                        "ProcessFolderMoveTest2Processed"});
            table8.AddRow(new string[] {
                        "DuplicateTimeStampDontMove"});
#line 5
 testRunner.Given("I delete the folders", ((string)(null)), table8, "Given ");
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
#line 14
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
#line 15
 testRunner.Given("I create a copy of all test files in the folder \'ProcessFolderDontMoveTest\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table9.AddRow(new string[] {
                            "\\CR2\\20180408_122634.CR2"});
                table9.AddRow(new string[] {
                            "\\CR2\\Good.CR2"});
                table9.AddRow(new string[] {
                            "\\JPG\\Bad.jpg"});
                table9.AddRow(new string[] {
                            "\\JPG\\Good.jpg"});
                table9.AddRow(new string[] {
                            "\\JPG\\GPS.jpg"});
                table9.AddRow(new string[] {
                            "\\mov\\20160124_141023.MOV"});
                table9.AddRow(new string[] {
                            "\\mov\\Good.MOV"});
                table9.AddRow(new string[] {
                            "\\mov\\Good2.MOV"});
                table9.AddRow(new string[] {
                            "\\NEF\\20080601_020200.nef"});
                table9.AddRow(new string[] {
                            "\\NEF\\Good.nef"});
#line 16
 testRunner.And("the folder \'ProcessFolderDontMoveTest\' with subfolders contains", ((string)(null)), table9, "And ");
#line hidden
                TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                            "DebugDontRenameFile",
                            "MoveToProcessedByYear",
                            "ProcessedPath"});
                table10.AddRow(new string[] {
                            "false",
                            "false",
                            ""});
#line 29
 testRunner.When("I process the folder \'ProcessFolderDontMoveTest\' with the following flags", ((string)(null)), table10, "When ");
#line hidden
                TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table11.AddRow(new string[] {
                            "\\CR2\\20180408_072740.CR2"});
                table11.AddRow(new string[] {
                            "\\CR2\\20180408_122634.CR2"});
                table11.AddRow(new string[] {
                            "\\JPG\\20180310_115353.jpg"});
                table11.AddRow(new string[] {
                            "\\JPG\\Bad.jpg"});
                table11.AddRow(new string[] {
                            "\\JPG\\20200127_115041.jpg"});
                table11.AddRow(new string[] {
                            "\\mov\\20151129_093543.MOV"});
                table11.AddRow(new string[] {
                            "\\mov\\20160124_141020.MOV"});
                table11.AddRow(new string[] {
                            "\\mov\\20160124_141023.MOV"});
                table11.AddRow(new string[] {
                            "\\NEF\\20080601_020200.nef"});
                table11.AddRow(new string[] {
                            "\\NEF\\20080601_020200_2.nef"});
#line 33
 testRunner.Then("the folder \'ProcessFolderDontMoveTest\' with subfolders contains", ((string)(null)), table11, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="MoveTest1")]
        [Xunit.TraitAttribute("FeatureTitle", "ProcessFolder")]
        [Xunit.TraitAttribute("Description", "MoveTest1")]
        public virtual void MoveTest1()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MoveTest1", null, ((string[])(null)));
#line 46
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
#line 47
 testRunner.Given("I create a copy of all test files in the folder \'ProcessFolderMoveTest\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table12.AddRow(new string[] {
                            "\\CR2\\20180408_122634.CR2"});
                table12.AddRow(new string[] {
                            "\\CR2\\Good.CR2"});
                table12.AddRow(new string[] {
                            "\\JPG\\Bad.jpg"});
                table12.AddRow(new string[] {
                            "\\JPG\\Good.jpg"});
                table12.AddRow(new string[] {
                            "\\JPG\\GPS.jpg"});
                table12.AddRow(new string[] {
                            "\\mov\\20160124_141023.MOV"});
                table12.AddRow(new string[] {
                            "\\mov\\Good.MOV"});
                table12.AddRow(new string[] {
                            "\\mov\\Good2.MOV"});
                table12.AddRow(new string[] {
                            "\\NEF\\20080601_020200.nef"});
                table12.AddRow(new string[] {
                            "\\NEF\\Good.nef"});
#line 48
 testRunner.And("the folder \'ProcessFolderMoveTest\' with subfolders contains", ((string)(null)), table12, "And ");
#line hidden
                TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                            "DebugDontRenameFile",
                            "MoveToProcessedByYear",
                            "ProcessedPath"});
                table13.AddRow(new string[] {
                            "false",
                            "true",
                            "ProcessFolderMoveTestProcessed"});
#line 61
 testRunner.When("I process the folder \'ProcessFolderMoveTest\' with the following flags", ((string)(null)), table13, "When ");
#line hidden
                TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table14.AddRow(new string[] {
                            "\\2008\\Q2\\20080601_020200.nef"});
                table14.AddRow(new string[] {
                            "\\2008\\Q2\\20080601_020200_2.nef"});
                table14.AddRow(new string[] {
                            "\\2015\\Q4\\20151129_093543.MOV"});
                table14.AddRow(new string[] {
                            "\\2016\\Q1\\20160124_141020.MOV"});
                table14.AddRow(new string[] {
                            "\\2016\\Q1\\20160124_141023.MOV"});
                table14.AddRow(new string[] {
                            "\\2018\\Q1\\20180310_115353.jpg"});
                table14.AddRow(new string[] {
                            "\\2018\\Q2\\20180408_072740.CR2"});
                table14.AddRow(new string[] {
                            "\\2018\\Q2\\20180408_122634.CR2"});
                table14.AddRow(new string[] {
                            "\\2020\\Q1\\20200127_115041.jpg"});
#line 65
 testRunner.Then("the folder \'ProcessFolderMoveTestProcessed\' with subfolders contains", ((string)(null)), table14, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table15.AddRow(new string[] {
                            "\\JPG\\Bad.jpg"});
#line 76
 testRunner.And("the folder \'ProcessFolderMoveTest\' with subfolders contains", ((string)(null)), table15, "And ");
#line hidden
                TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table16.AddRow(new string[] {
                            "\\JPG"});
#line 79
 testRunner.And("the folder \'ProcessFolderMoveTest\' has subfolders", ((string)(null)), table16, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="MoveTest2")]
        [Xunit.TraitAttribute("FeatureTitle", "ProcessFolder")]
        [Xunit.TraitAttribute("Description", "MoveTest2")]
        public virtual void MoveTest2()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MoveTest2", null, ((string[])(null)));
#line 83
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
#line 84
 testRunner.Given("I create a copy of all test files in the folder \'ProcessFolderMoveTest2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table17.AddRow(new string[] {
                            "JPG\\Bad.jpg"});
#line 85
 testRunner.And("in the folder \'ProcessFolderMoveTest2\' I delete the files", ((string)(null)), table17, "And ");
#line hidden
                TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table18.AddRow(new string[] {
                            "\\CR2\\20180408_122634.CR2"});
                table18.AddRow(new string[] {
                            "\\CR2\\Good.CR2"});
                table18.AddRow(new string[] {
                            "\\JPG\\Good.jpg"});
                table18.AddRow(new string[] {
                            "\\JPG\\GPS.jpg"});
                table18.AddRow(new string[] {
                            "\\mov\\20160124_141023.MOV"});
                table18.AddRow(new string[] {
                            "\\mov\\Good.MOV"});
                table18.AddRow(new string[] {
                            "\\mov\\Good2.MOV"});
                table18.AddRow(new string[] {
                            "\\NEF\\20080601_020200.nef"});
                table18.AddRow(new string[] {
                            "\\NEF\\Good.nef"});
#line 88
 testRunner.And("the folder \'ProcessFolderMoveTest2\' with subfolders contains", ((string)(null)), table18, "And ");
#line hidden
                TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                            "DebugDontRenameFile",
                            "MoveToProcessedByYear",
                            "ProcessedPath"});
                table19.AddRow(new string[] {
                            "false",
                            "true",
                            "ProcessFolderMoveTest2Processed"});
#line 100
 testRunner.When("I process the folder \'ProcessFolderMoveTest2\' with the following flags", ((string)(null)), table19, "When ");
#line hidden
                TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table20.AddRow(new string[] {
                            "\\2008\\Q2\\20080601_020200.nef"});
                table20.AddRow(new string[] {
                            "\\2008\\Q2\\20080601_020200_2.nef"});
                table20.AddRow(new string[] {
                            "\\2015\\Q4\\20151129_093543.MOV"});
                table20.AddRow(new string[] {
                            "\\2016\\Q1\\20160124_141020.MOV"});
                table20.AddRow(new string[] {
                            "\\2016\\Q1\\20160124_141023.MOV"});
                table20.AddRow(new string[] {
                            "\\2018\\Q1\\20180310_115353.jpg"});
                table20.AddRow(new string[] {
                            "\\2018\\Q2\\20180408_072740.CR2"});
                table20.AddRow(new string[] {
                            "\\2018\\Q2\\20180408_122634.CR2"});
                table20.AddRow(new string[] {
                            "\\2020\\Q1\\20200127_115041.jpg"});
#line 104
 testRunner.Then("the folder \'ProcessFolderMoveTest2Processed\' with subfolders contains", ((string)(null)), table20, "Then ");
#line hidden
#line 115
 testRunner.And("there are no subfolders in \'ProcessFolderMoveTest2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="DuplicateTimeStampDontMove")]
        [Xunit.TraitAttribute("FeatureTitle", "ProcessFolder")]
        [Xunit.TraitAttribute("Description", "DuplicateTimeStampDontMove")]
        public virtual void DuplicateTimeStampDontMove()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DuplicateTimeStampDontMove", null, ((string[])(null)));
#line 117
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
#line 118
 testRunner.Given("I create a copy of all test files in the folder \'DuplicateTimeStampDontMove\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                            "SourceFolder",
                            "SourceFile",
                            "DestinationFolder",
                            "DestinationFile"});
                table21.AddRow(new string[] {
                            "CR2",
                            "good.cr2",
                            "cr2",
                            "Duplicate.cr2"});
                table21.AddRow(new string[] {
                            "jpg",
                            "good.jpg",
                            "jpg",
                            "duplicate.jpg"});
                table21.AddRow(new string[] {
                            "JPG",
                            "gps.jpg",
                            "jpg",
                            "Duplicate2.jpg"});
                table21.AddRow(new string[] {
                            "mov",
                            "good.mov",
                            "mov",
                            "duplicate.Mov"});
#line 119
 testRunner.And("I copy the following files in the folder \'DuplicateTimeStampDontMove\'", ((string)(null)), table21, "And ");
#line hidden
                TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table22.AddRow(new string[] {
                            "\\CR2\\20180408_122634.CR2"});
                table22.AddRow(new string[] {
                            "\\CR2\\Good.CR2"});
                table22.AddRow(new string[] {
                            "\\JPG\\Good.jpg"});
                table22.AddRow(new string[] {
                            "\\JPG\\GPS.jpg"});
                table22.AddRow(new string[] {
                            "\\mov\\20160124_141023.MOV"});
                table22.AddRow(new string[] {
                            "\\mov\\Good.MOV"});
                table22.AddRow(new string[] {
                            "\\mov\\Good2.MOV"});
                table22.AddRow(new string[] {
                            "\\NEF\\20080601_020200.nef"});
                table22.AddRow(new string[] {
                            "\\NEF\\Good.nef"});
                table22.AddRow(new string[] {
                            "\\CR2\\Duplicate.cr2"});
                table22.AddRow(new string[] {
                            "\\JPG\\Bad.jpg"});
                table22.AddRow(new string[] {
                            "\\JPG\\duplicate.jpg"});
                table22.AddRow(new string[] {
                            "\\JPG\\Duplicate2.jpg"});
                table22.AddRow(new string[] {
                            "\\mov\\duplicate.Mov"});
#line 126
 testRunner.Then("the folder \'DuplicateTimeStampDontMove\' with subfolders contains", ((string)(null)), table22, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                            "DebugDontRenameFile",
                            "MoveToProcessedByYear",
                            "ProcessedPath"});
                table23.AddRow(new string[] {
                            "false",
                            "false",
                            ""});
#line 143
 testRunner.When("I process the folder \'DuplicateTimeStampDontMove\' with the following flags", ((string)(null)), table23, "When ");
#line hidden
                TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table24.AddRow(new string[] {
                            "\\CR2\\20180408_122634.CR2"});
                table24.AddRow(new string[] {
                            "\\CR2\\20180408_072740.cr2"});
                table24.AddRow(new string[] {
                            "\\CR2\\20180408_072740_2.CR2"});
                table24.AddRow(new string[] {
                            "\\JPG\\20180310_115353.jpg"});
                table24.AddRow(new string[] {
                            "\\JPG\\20180310_115353_2.jpg"});
                table24.AddRow(new string[] {
                            "\\JPG\\20200127_115041.jpg"});
                table24.AddRow(new string[] {
                            "\\JPG\\20200127_115041_2.jpg"});
                table24.AddRow(new string[] {
                            "\\JPG\\Bad.jpg"});
                table24.AddRow(new string[] {
                            "\\mov\\20151129_093543.MOV"});
                table24.AddRow(new string[] {
                            "\\mov\\20160124_141020.Mov"});
                table24.AddRow(new string[] {
                            "\\mov\\20160124_141020_2.MOV"});
                table24.AddRow(new string[] {
                            "\\mov\\20160124_141023.MOV"});
                table24.AddRow(new string[] {
                            "\\NEF\\20080601_020200.nef"});
                table24.AddRow(new string[] {
                            "\\NEF\\20080601_020200_2.nef"});
#line 146
 testRunner.Then("the folder \'DuplicateTimeStampDontMove\' with subfolders contains", ((string)(null)), table24, "Then ");
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
