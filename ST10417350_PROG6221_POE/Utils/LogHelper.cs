using ST10417350_PROG6221_POE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ST10417350_PROG6221_POE.Utils
{
    public static class LogHelper
    {
        private static List<LogEntry> log = new List<LogEntry>();

        public static void Add(string message)
        {
            log.Add(new LogEntry(message));
        }

        public static List<LogEntry> GetRecent(int count = 10)
        {
            int skip = Math.Max(0, log.Count - count);
            return log.GetRange(skip, log.Count - skip);
        }

        public static List<LogEntry> GetAll()
        {
            return new List<LogEntry>(log);
        }
    }
}