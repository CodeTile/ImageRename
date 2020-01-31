using System;
using System.Collections.Generic;
using ImageRename.Tests.Context;
using ImageRename.Tests.Models;
using Moq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace ImageRename.Tests.Steps
{
    [Binding]
    public class TestHelperSteps : BaseSteps
    {
        public TestHelperSteps(BaseContext context) : base(context)
        {
        }

        private void SetTimeProvider(string date)
        {
            DateTime nowDateTime;
            DateTime todayDateTime;
            if (!date.Contains(':'))
            {
                todayDateTime = Convert.ToDateTime(date + " 00:00:00");
                nowDateTime = Convert.ToDateTime(date += " 23:14:59");
            }
            else
            {
                todayDateTime = Convert.ToDateTime(Convert.ToDateTime(date).ToString("d MMM yyyy 0:00:00"));
                nowDateTime = Convert.ToDateTime(date);
            }

            var timeMock = new Mock<TimeProvider>();
            timeMock.SetupGet(tp => tp.Now).Returns(nowDateTime);
            timeMock.SetupGet(tp => tp.Today).Returns(todayDateTime);
            TimeProvider.Current = timeMock.Object;

            Context.TimeProvider = TimeProvider.Current;
        }

        [Given(@"I reset the TimeProvider")]
        public void GivenIResetTheTimeProvider()
        {
            TimeProvider.ResetToDefault();
        }

        [Given(@"I TestHelper function convertToDateTime with the following")]
        public void GivenITestHelperFunctionConvertToDateTimeWithTheFollowing(Table table)
        {
            var results = new List<ExpectedTimeResults1>();
            foreach (var row in table.Rows)
            {
                var value = row["Value"];
                var includeTime = row["IncludeTime"].ToString().ToLower();
                var actualDateFormat = "d MMM yyyy";
                if (includeTime == "true")
                {
                    actualDateFormat += " HH:mm:ss";
                }
                var testDateTime = Convert.ToDateTime(row["CurrentDate"]);
                var actual = TestHelper.ConvertToDateTime(value, testDateTime).ToString(actualDateFormat);
                results.Add(new ExpectedTimeResults1 { Value = value, Result = actual, IncludeTime = row["IncludeTime"], CurrentDate = testDateTime });
            }

            table.CompareToSet(results);
        }

        [Given(@"I set the TimeProvider date to '(.*)'")]
        public void GivenWhenISetTheTimeProviderDateTo(string date)
        {
            SetTimeProvider(date);
        }

        [Then(@"the first workday of the week is '(.*)'")]
        public void ThenTheFirstWorkdayOfTheWeekIs(string firstWorkDay)
        {
            Assert.Equal(Context.SUT.Data.weekStartsOn, firstWorkDay);
        }

        [Then(@"the testUser has (.*) working days a month")]
        public void ThenTheTestUserHasWorkingDaysAMonth(int expectedWorkingDays)
        {
            Assert.Equal(Context.SUT.Data.workingDaysPerMonth, expectedWorkingDays);
        }
    }
}