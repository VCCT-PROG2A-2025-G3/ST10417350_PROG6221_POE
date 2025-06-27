using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace ST10417350_PROG6221_POE.Utils
{
    internal class Greeting
    {
        /// <summary>
        /// Plays the AI greeting WAV file from the Assets folder.
        /// </summary>
        public static void PlayGreeting()
        {
            // Construct the path to the audio file
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "AI_Greeting_For_Project.wav");

            // Check if the file exists
            if (File.Exists(path))
            {
                try
                {
                    // Load and play the sound
                    using (SoundPlayer player = new SoundPlayer(path))
                    {
                        player.PlaySync(); // Play the sound synchronously
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error playing audio: {ex.Message}", "Audio Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Voice greeting not found. Ensure the 'Assets' folder and audio file are present.",
                                "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}