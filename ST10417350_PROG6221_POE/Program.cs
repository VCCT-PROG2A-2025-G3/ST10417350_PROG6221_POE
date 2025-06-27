//=========================== START OF FILE ===========================//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Connor Manuel
 * ST10417350@vcconnect.edu.za
 * ST10417350 
 */

namespace ST10417350_PROG6221_POE
{
    /// <summary>
    /// Contains the main entry point of the application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main method where the application starts execution.
        /// </summary>
        [STAThread] // Indicates that the COM threading model for the application is single-threaded apartment
        static void Main()
        {
            // Enables visual styles for the application, giving it a modern look.
            Application.EnableVisualStyles();

            // Sets whether to use GDI+ or GDI for rendering text; false means GDI is used.
            Application.SetCompatibleTextRenderingDefault(false);

            // Starts the application with the ChatbotForm as the main form.
            Application.Run(new ChatbotForm());
        }
    }
}
//=========================== END OF FILE ===========================//