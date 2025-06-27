//=========================== START OF FILE ===========================//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Connor Manuel
 * ST10417350@vcconnect.edu.za
 * ST10417350 
 */

namespace ST10417350_PROG6221_POE.Utils
{
    /// <summary>
    /// Helper class for analyzing user sentiment and generating appropriate responses.
    /// </summary>
    public static class SentimentHelper
    {
        /// <summary>
        /// Analyzes the input string to determine the sentiment category.
        /// </summary>
        /// <param name="input">The user input string to analyze.</param>
        /// <returns>A string representing the detected sentiment. Returns an empty string if no sentiment is matched.</returns>
        public static string GetSentiment(string input)
        {
            input = input.ToLower(); 

            // Check for keywords that indicate a specific sentiment
            if (input.Contains("worried") || input.Contains("scared"))
                return "worried";

            if (input.Contains("curious") || input.Contains("want to learn"))
                return "curious";

            if (input.Contains("frustrated") || input.Contains("annoyed") || input.Contains("tired"))
                return "frustrated";

            if (input.Contains("happy") || input.Contains("good") || input.Contains("great"))
                return "positive";

            // If no keywords matched, return an empty string
            return string.Empty;
        }

        /// <summary>
        /// Generates a chatbot response based on the user's detected sentiment.
        /// </summary>
        /// <param name="sentiment">The sentiment category to respond to.</param>
        /// <returns>A random friendly response based on the sentiment.</returns>
        public static string GetResponse(string sentiment)
        {
            // Define responses for each sentiment type
            Dictionary<string, List<string>> responseMap = new Dictionary<string, List<string>>
            {
                { "worried", new List<string>
                {
                    "It's okay to be worried. Let's take steps to protect you online.",
                    "Feeling worried is normal when it comes to cybersecurity. I'm here to help.",
                    "You're not alone in feeling concerned about cyber threats."
                }},

                { "curious", new List<string>
                {
                    "Great! Curiosity is the first step toward being cyber-smart.",
                    "I love that you're curious! Cybersecurity is fascinating.",
                    "Ask away — I'm happy to teach you how to stay safe online."
                }},

                { "frustrated", new List<string>
                {
                    "I understand. Cyber threats can be overwhelming — I'm here to help.",
                    "Don't worry — we'll simplify things so it’s easier to manage.",
                    "Cybersecurity can feel frustrating at times. Let’s tackle it together."
                }},

                { "positive", new List<string>
                {
                    "Glad to hear that! Let's keep learning.",
                    "Awesome! Positivity helps when learning about cybersecurity.",
                    "Keep that energy going — let's stay secure and positive!"
                }}
            };

            // Attempt to get the list of responses for the detected sentiment
            if (responseMap.TryGetValue(sentiment, out var responses))
            {
                Random rand = new Random(); 
                return responses[rand.Next(responses.Count)]; 
            }

            // Return an empty string if the sentiment was not found in the dictionary
            return string.Empty;
        }
    }
}
//=========================== END OF FILE ===========================//