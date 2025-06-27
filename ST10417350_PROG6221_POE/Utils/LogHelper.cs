//=========================== START OF FILE ===========================//

using ST10417350_PROG6221_POE.Models;
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
    /// Static utility class that provides logging functionality for storing and retrieving log entries.
    /// </summary>
    public static class LogHelper
    {
        /// <summary>
        /// Internal list to store all log entries in memory.
        /// </summary>
        private static List<LogEntry> log = new List<LogEntry>();

        /// <summary>
        /// Adds a new log entry with the current timestamp and provided message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Add(string message)
        {
            log.Add(new LogEntry(message)); 
        }

        /// <summary>
        /// Retrieves the most recent log entries, up to the specified count.
        /// </summary>
        /// <param name="count">The number of recent log entries to retrieve (default is 10).</param>
        /// <returns>A list of the most recent log entries.</returns>
        public static List<LogEntry> GetRecent(int count = 10)
        {
            // Calculate how many entries to skip if the list is longer than the requested count
            int skip = Math.Max(0, log.Count - count);

            // Return the last 'count' entries from the log
            return log.GetRange(skip, log.Count - skip);
        }

        /// <summary>
        /// Retrieves all log entries currently stored.
        /// </summary>
        /// <returns>A new list containing all log entries.</returns>
        public static List<LogEntry> GetAll()
        {
            // Return a copy of the entire log list
            return new List<LogEntry>(log);
        }
    }
}
//=========================== END OF FILE ===========================//