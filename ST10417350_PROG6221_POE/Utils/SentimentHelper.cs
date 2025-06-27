using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10417350_PROG6221_POE.Utils
{
    public static class SentimentHelper
    {
        public static string GetSentiment(string input)
        {
            input = input.ToLower();

            if (input.Contains("worried") || input.Contains("scared"))
                return "worried";

            if (input.Contains("curious") || input.Contains("want to learn"))
                return "curious";

            if (input.Contains("frustrated") || input.Contains("annoyed") || input.Contains("tired"))
                return "frustrated";

            if (input.Contains("happy") || input.Contains("good") || input.Contains("great"))
                return "positive";

            return string.Empty;
        }

        public static string GetResponse(string sentiment)
        {
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

            if (responseMap.TryGetValue(sentiment, out var responses))
            {
                Random rand = new Random();
                return responses[rand.Next(responses.Count)];
            }

            return string.Empty;
        }
    }
}