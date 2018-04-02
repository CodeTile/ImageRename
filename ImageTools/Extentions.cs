using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageTools
{
    public static class Extentions
    {
        public static string ReplaceNullOrEmpty(this string s, string replacement ="")
        {
            
            if(string.IsNullOrEmpty(s))
            {
                s = replacement;
            }
            return s;
        }
    }
}
