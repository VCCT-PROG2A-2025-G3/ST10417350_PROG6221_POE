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

namespace ST10417350_PROG6221_POE.Models
{
    /// <summary>
    /// Represents a single log entry with a timestamp and description.
    /// Used for tracking user actions or system events.
    /// </summary>
    public class LogEntry
    {
        /// <summary>
        /// The time when the log entry was created.
        /// </summary>
        public DateTime Timestamp { get; }

        /// <summary>
        /// A description of the action or event being logged.
        /// </summary>
        public string ActionDescription { get; }

        /// <summary>
        /// Constructor that creates a log entry with the current time and a given description.
        /// </summary>
        /// <param name="description">The description of the action/event to log.</param>
        public LogEntry(string description)
        {
            Timestamp = DateTime.Now; // Capture the current date and time
            ActionDescription = description; // Set the action description
        }

        /// <summary>
        /// Returns a string representation of the log entry in a readable format.
        /// </summary>
        /// <returns>A string with timestamp and description.</returns>
        public override string ToString()
        {
            return $"[{Timestamp:HH:mm:ss}] {ActionDescription}";
        }
    }
}
//=========================== END OF FILE ===========================//