using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10417350_PROG6221_POE.Utils
{
    internal class FunFactsManager
    {
        // Static list of cybersecurity fun facts
        private static readonly List<string> AllFacts = new List<string>
        {
            // 1. The term 'computer bug' was inspired by an actual moth found in a computer in 1947.
            // Reference: TechTarget - https://www.techtarget.com/searchsoftwarequality/definition/bug 
            "The term 'computer bug' was inspired by an actual moth found in a computer in 1947.",

            // 2. The first computer virus, called 'Creeper', appeared in the early 1970s.
            // Reference: Exabeam - https://www.exabeam.com/blog/infosec-trends/creeper-the-worlds-first-computer-virus/ 
            "The first computer virus, called 'Creeper', appeared in the early 1970s.",

            // 3. The first computer virus was created in 1986 and was called 'Brain'.
            // Reference: TRT World - https://www.trtworld.com/magazine/the-making-of-the-first-computer-virus-the-pakistani-brain-32296 
            "The first computer virus was created in 1986 and was called 'Brain'.",

            // 4. The term 'phishing' was first used in 1996 by hackers stealing AOL accounts.
            // Reference: Webopedia - https://www.webopedia.com/term/p/phishing/ 
            "The term 'phishing' was first used in 1996 by hackers stealing AOL accounts.",

            // 5. Over 90% of successful cyberattacks start with a phishing email.
            // Reference: CISA - https://www.cisa.gov/shields-guidance-families 
            "Over 90% of successful cyberattacks start with a phishing email.",

            // 6. The average person reuses the same password across 5+ sites.
            // Reference: Security Magazine - https://www.securitymagazine.com/articles/100765-78-of-people-use-the-same-password-across-multiple-accounts 
            "The average person reuses the same password across 5+ sites.",

            // 7. More than 30,000 websites are hacked every single day.
            // Reference: Cybersecurity Ventures - https://cybersecurityventures.com/intrusion-daily-cyber-threat-alert/ 
            "More than 30,000 websites are hacked every single day.",

            // 8. The most common password in the world is still '123456'.
            // Reference: NordPass - https://nordpass.com/most-common-passwords-list/ 
            "The most common password in the world is still '123456'.",

            // 9. Kevin Mitnick, once the most-wanted hacker in the US, now runs a cybersecurity firm.
            // Reference: Cybersecurity Ventures - https://cybersecurityventures.com/cybersecuritys-greatest-show-on-earth-kevin-mitnick/ 
            "Kevin Mitnick, once the most-wanted hacker in the US, now runs a cybersecurity firm.",

            // 10. The word 'hacker' originally had a positive meaning, referring to skilled programmers.
            // Reference: Deepgram - https://deepgram.com/learn/the-history-of-the-word-hacker-2 
            "The word 'hacker' originally had a positive meaning, referring to skilled programmers.",

            // 11. ‘Social engineering’ is one of the most effective hacking techniques – it targets people, not code.
            // Reference: Spiceworks - https://www.spiceworks.com/it-security/cyber-risk-management/articles/social-engineering-still-rampant/ 
            "‘Social engineering’ is one of the most effective hacking techniques – it targets people, not code.",

            // 12. Cybercrime damages are projected to reach $10.5 trillion annually by 2025.
            // Reference: Cybersecurity Ventures - https://cybersecurityventures.com/cybercrime-damages-report/ 
            "Cybercrime damages are projected to reach $10.5 trillion annually by 2025.",

            // 13. Wi-Fi was invented in 1997, but it wasn’t secured properly until years later.
            // Reference: Wi-Fi First - https://www.wifirst.com/en/blog/thehistoryofwifitechnology 
            "Wi-Fi was invented in 1997, but it wasn’t secured properly until years later.",

            // 14. In 2013, Yahoo suffered a breach affecting over 3 billion accounts — the largest in history.
            // Reference: Twingate - https://www.twingate.com/blog/tips/Yahoo%20Inc-data-breach 
            "In 2013, Yahoo suffered a breach affecting over 3 billion accounts — the largest in history."
        };

        /// <summary>
        /// Returns a random cybersecurity fun fact.
        /// </summary>
        public static string GetRandomFact()
        {
            Random random = new Random();
            int index = random.Next(AllFacts.Count);
            return AllFacts[index];
        }
    }
}