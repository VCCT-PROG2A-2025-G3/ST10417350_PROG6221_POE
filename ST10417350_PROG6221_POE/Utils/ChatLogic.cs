//=========================== START OF FILE ===========================//

using ST10417350_PROG6221_POE.Models;
using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Connor Manuel
 * ST10417350@vcconnect.edu.za
 * ST10417350 
 */

namespace ST10417350_PROG6221_POE.Utils
{
    /// <summary>
    /// Core logic class responsible for processing chatbot input and generating context-aware responses.
    /// </summary>
    public class ChatLogic
    {
        /// <summary>
        /// Stores the user's name for personalization.
        /// </summary>
        private string userName = "User";

        /// <summary>
        /// Random number generator for selecting randomized responses.
        /// </summary>
        private readonly Random rand = new Random();

        /// <summary>
        /// Sets the user's name if the input is not null or whitespace.
        /// </summary>
        /// <param name="name">The name entered by the user.</param>
        public void SetUserName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                userName = name;
            }
        }

        /// <summary>
        /// Processes user input and returns a chatbot response based on sentiment, commands, or detected keywords.
        /// </summary>
        /// <param name="input">User's text input.</param>
        /// <returns>A generated chatbot response string.</returns>
        public string ProcessInput(string input)
        {
            string lowerInput = input.ToLower(); 

            // Check for emotional sentiment
            string sentiment = SentimentHelper.GetSentiment(lowerInput);
            if (!string.IsNullOrEmpty(sentiment))
            {
                return SentimentHelper.GetResponse(sentiment);
            }

            // Respond to 'help' command
            if (lowerInput.Contains("help"))
            {
                return "Here's what you can ask me about:\r\n" +
                       "🔹 Password safety\r\n" +
                       "🔹 Phishing\r\n" +
                       "🔹 Scams & fraud\r\n" +
                       "🔹 Privacy settings\r\n" +
                       "🔹 Two-factor authentication (2FA)\r\n" +
                       "🔹 Fun facts\r\n" +
                       "🔹 Cybersecurity tips\r\n\r\n" +
                       "Just type your question or topic!";
            }

            // Respond with a random cybersecurity tip or fun fact
            if (lowerInput.Contains("tip"))
            {
                return "🛡️ Tip: " + CyberTipsManager.GetRandomTip();
            }
            else if (lowerInput.Contains("fact"))
            {
                return "💡 Did you know? " + FunFactsManager.GetRandomFact();
            }

            // Detect predefined cybersecurity-related keywords
            string keyword = NLPHelper.DetectKeyword(lowerInput);
            if (!string.IsNullOrEmpty(keyword))
            {
                return GetKeywordResponse(keyword);
            }

            // Detect meaningless or invalid input
            if (IsNonsensicalInput(lowerInput))
            {
                return "Sorry, I don't understand. Can you rephrase?";
            }

            // Default fallback if no other condition is met
            return GetRandomFallback();
        }

        /// <summary>
        /// Returns a topic-specific response based on the identified keyword.
        /// </summary>
        /// <param name="keyword">The keyword found in user input.</param>
        /// <returns>A related educational response string.</returns>
        private string GetKeywordResponse(string keyword)
        {
            Dictionary<string, List<string>> responses = new Dictionary<string, List<string>>
            {
                { "password", new List<string> {
                    "Use a strong, unique password for each account.",
                    "Avoid reusing passwords across different websites.",
                    "Consider using a password manager."
                }},
                { "scam", new List<string> {
                    "Scams often arrive via email or SMS. Always verify the sender.",
                    "Never click suspicious links.",
                    "Look for bad grammar or urgent requests — common scam signs."
                }},
                { "phishing", new List<string> {
                    "Phishing attempts try to trick you into revealing sensitive info.",
                    "Look out for fake login pages and spoofed emails.",
                    "Always verify links before clicking them."
                }},
                { "privacy", new List<string> {
                    "Review your social media privacy settings regularly.",
                    "Be cautious about the personal info you share online.",
                    "Use encrypted messaging apps for private conversations."
                }},
                { "2fa", new List<string> {
                    "Two-factor authentication adds a second layer of security beyond your password.",
                    "Use an authenticator app or hardware key when possible.",
                    "Enable 2FA on all accounts that support it."
                }}
            };

            // If keyword has predefined responses, return one randomly
            if (responses.ContainsKey(keyword))
            {
                List<string> list = responses[keyword];
                return list[rand.Next(list.Count)];
            }

            // Generic fallback for unmatched keywords
            return "That's an important topic. Let's talk more about it!";
        }

        /// <summary>
        /// Returns a general-purpose fallback response when no keywords or commands are matched.
        /// </summary>
        /// <returns>A randomly selected fallback chatbot message.</returns>
        private string GetRandomFallback()
        {
            List<string> responses = new List<string>
            {
                "Interesting! Tell me more.",
                "That's good to know.",
                "Cybersecurity is important. Let's talk about it!",
                "Thanks for sharing!"
            };

            return responses[rand.Next(responses.Count)];
        }

        /// <summary>
        /// Checks if the user's input is considered nonsensical or invalid for chatbot processing.
        /// </summary>
        /// <param name="input">The normalized user input.</param>
        /// <returns>True if input is meaningless, false otherwise.</returns>
        private bool IsNonsensicalInput(string input)
        {
            input = input.Trim().ToLower(); 

            // Empty or whitespace input
            if (string.IsNullOrWhiteSpace(input))
                return true;

            // Very short and meaningless input
            if (input.Length < 3 && !new[] { "hi", "hey", "yo", "ok" }.Contains(input))
                return true;

            // No letters at all
            if (!input.Any(char.IsLetter))
                return true;

            // Input composed only of symbols or digits
            if (input.All(c => char.IsDigit(c) || char.IsPunctuation(c) || char.IsSymbol(c)))
                return true;

            return false;
        }
    }
}
//=========================== END OF FILE ===========================//