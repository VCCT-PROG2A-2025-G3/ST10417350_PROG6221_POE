using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ST10417350_PROG6221_POE.Utils
{
    public static class NLPHelper
    {
        private static readonly List<string> Keywords = new List<string>
    {
        "password", "scam", "phishing", "privacy", "2fa", "two-factor", "help"
    };

        public static string DetectKeyword(string input)
        {
            input = input.ToLower();

            foreach (var keyword in Keywords)
            {
                if (input.Contains(keyword))
                {
                    return keyword;
                }
            }

            return string.Empty;
        }
    }
}