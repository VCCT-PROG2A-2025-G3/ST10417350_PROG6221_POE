//=========================== START OF FILE ===========================//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*
 * Connor Manuel
 * ST10417350@vcconnect.edu.za
 * ST10417350 
 */

namespace ST10417350_PROG6221_POE.Utils
{
    /// <summary>
    /// Provides basic Natural Language Processing (NLP) functionality to identify cybersecurity-related keywords in user input.
    /// </summary>
    public static class NLPHelper
    {
        /// <summary>
        /// List of important cybersecurity keywords to search for in the user input.
        /// </summary>
        private static readonly List<string> Keywords = new List<string>
        {
            "password", "scam", "phishing", "privacy", "2fa", "two-factor", "help"
        };

        /// <summary>
        /// Scans a string input and attempts to detect any predefined cybersecurity-related keyword.
        /// </summary>
        /// <param name="input">The user's raw input text.</param>
        /// <returns>
        /// Returns the first keyword found in the input. 
        /// Returns an empty string if no keyword is detected.
        /// </returns>
        public static string DetectKeyword(string input)
        {
            input = input.ToLower(); 

            // Iterate through all keywords and check if any are contained in the input string.
            foreach (var keyword in Keywords)
            {
                if (input.Contains(keyword))
                {
                    return keyword; 
                }
            }

            // If no keywords were found, return an empty string.
            return string.Empty;
        }
    }
}
//=========================== END OF FILE ===========================//