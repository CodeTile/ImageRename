using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ImageRename.Tests
{
    public static class TableExtensions
    {
        public static string GetFirstCell(this Table table, string colName)
        {
            var retval = table.Rows[0].GetString(colName);
            return retval;
        }
    }
}