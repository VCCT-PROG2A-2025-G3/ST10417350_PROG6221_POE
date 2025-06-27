using System;
using System.Collections.Generic;
using System.Linq;

namespace ST10417350_PROG6221_POE.Utils
{
    public class ChatLogic
    {
        private string userName = "User";
        private readonly Random rand = new Random();

        public void SetUserName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                userName = name;
            }
        }

        public string ProcessInput(string input)
        {
            string lowerInput = input.ToLower();

            // Step 1: Check for sentiment
            string sentiment = SentimentHelper.GetSentiment(lowerInput);
            if (!string.IsNullOrEmpty(sentiment))
            {
                return SentimentHelper.GetResponse(sentiment);
            }

            // Step 2: Handle help command
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

            // Step 3: Handle direct 'tip' or 'fact' commands
            if (lowerInput.Contains("tip"))
            {
                return "🛡️ Tip: " + CyberTipsManager.GetRandomTip();
            }
            else if (lowerInput.Contains("fact"))
            {
                return "💡 Did you know? " + FunFactsManager.GetRandomFact();
            }

            // Step 4: NLP keyword detection
            string keyword = NLPHelper.DetectKeyword(lowerInput);
            if (!string.IsNullOrEmpty(keyword))
            {
                return GetKeywordResponse(keyword);
            }

            // Step 5: Detect if input is truly nonsensical
            if (IsNonsensicalInput(lowerInput))
            {
                return "Sorry, I don't understand. Can you rephrase?";
            }

            // Step 6: Otherwise, use a general response
            return GetRandomFallback();
        }

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

            if (responses.ContainsKey(keyword))
            {
                List<string> list = responses[keyword];
                return list[rand.Next(list.Count)];
            }

            return "That's an important topic. Let's talk more about it!";
        }

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

        private bool IsNonsensicalInput(string input)
        {
            // Trim and remove extra spaces
            input = input.Trim().ToLower();

            // Basic checks
            if (string.IsNullOrWhiteSpace(input))
                return true;

            // Reject inputs that are too short unless they match known keywords
            if (input.Length < 3 && !new[] { "hi", "hey", "yo", "ok" }.Contains(input))
                return true;

            // Check if the input has any actual letters
            if (!input.Any(char.IsLetter))
                return true;

            // Reject random number-only or symbol-only inputs
            if (input.All(c => char.IsDigit(c) || char.IsPunctuation(c) || char.IsSymbol(c)))
                return true;

            return false;
        }
    }
}