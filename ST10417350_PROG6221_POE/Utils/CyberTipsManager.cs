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
    internal class CyberTipsManager
    {
        // Static list of cybersecurity tips
        private static readonly List<string> AllTips = new List<string>
        {
            // 1. Use a password manager to create and store strong, unique passwords for each account.
            // Reference: Roguewaive - https://www.roguewaive.com/password-manager-guide/ 
            "Use a password manager to create and store strong, unique passwords for each account.",

            // 2. Enable two-factor authentication (2FA) wherever possible.
            // Reference: Duo Security - https://duo.com/resources/ebooks/two-factor-authentication-evaluation-guide 
            "Enable two-factor authentication (2FA) wherever possible.",

            // 3. Avoid using public Wi-Fi for sensitive transactions like online banking.
            // Reference: InfoRegulatorZA - https://eservices.inforegulator.org.za/pps/principles.aspx 
            "Avoid using public Wi-Fi for sensitive transactions like online banking.",

            // 4. Keep your operating system and apps updated to fix known vulnerabilities.
            // Reference: CISA - https://www.cisa.gov/stopransomware/ransomware-guide 
            "Keep your operating system and apps updated to fix known vulnerabilities.",

            // 5. Don’t click on suspicious links or download unknown attachments.
            // Reference: UTHSC - https://uthsc.edu/its/cybersecurity/tip-of-the-week.php 
            "Don’t click on suspicious links or download unknown attachments.",

            // 6. Check for 'https://' in URLs before entering personal information.
            // Reference: Mailchimp - https://mailchimp.com/resources/how-to-conduct-a-website-safety-check/ 
            "Check for 'https://' in URLs before entering personal information.",

            // 7. Regularly back up your important files to a secure location.
            // Reference: NordVPN - https://nordvpn.com/blog/pc-app-store-adware-removal/ 
            "Regularly back up your important files to a secure location.",

            // 8. Log out of accounts when using shared or public devices.
            // Reference: ITGuru - https://itguru.lk/blog/stay-smart-stay-safe-how-to-protect-your-bank-social-and-mobile-accounts/ 
            "Log out of accounts when using shared or public devices.",

            // 9. Use long passphrases that are easy to remember but hard to guess.
            // Reference: Roguewaive - https://www.roguewaive.com/password-manager-guide/ 
            "Use long passphrases that are easy to remember but hard to guess."
        };

        /// <summary>
        /// Returns a completely random cybersecurity tip.
        /// </summary>
        public static string GetRandomTip()
        {
            Random random = new Random();
            int index = random.Next(AllTips.Count);
            return AllTips[index];
        }

        /// <summary>
        /// Returns a shuffled list of all tips (useful for quizzes or daily tips).
        /// </summary>
        public static List<string> GetAllTipsShuffled()
        {
            var rand = new Random();
            return AllTips.OrderBy(x => rand.Next()).ToList();
        }
    }
}
//=========================== END OF FILE ===========================//