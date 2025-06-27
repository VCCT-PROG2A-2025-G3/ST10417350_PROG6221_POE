//=========================== START OF FILE ===========================//

using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

/*
 * Connor Manuel
 * ST10417350@vcconnect.edu.za
 * ST10417350 
 */

namespace ST10417350_PROG6221_POE.Utils
{
    /// <summary>
    /// Provides functionality to play a greeting audio clip stored in the Assets folder.
    /// </summary>
    internal class Greeting
    {
        /// <summary>
        /// Plays the AI greeting WAV file from the 'Assets' directory.
        /// Displays error messages if the file is missing or cannot be played.
        /// </summary>
        public static void PlayGreeting()
        {
            // Construct the absolute path to the greeting audio file
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "AI_Greeting_For_Project.wav");

            // Check if the file exists before attempting to play it
            if (File.Exists(path))
            {
                try
                {
                    // Create a SoundPlayer using the audio file path
                    using (SoundPlayer player = new SoundPlayer(path))
                    {
                        player.PlaySync(); 
                    }
                }
                catch (Exception ex)
                {
                    // Display an error message if the audio file fails to play
                    MessageBox.Show($"Error playing audio: {ex.Message}", "Audio Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Inform the user if the file does not exist
                MessageBox.Show("Voice greeting not found. Ensure the 'Assets' folder and audio file are present.",
                                "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
//=========================== END OF FILE ===========================//