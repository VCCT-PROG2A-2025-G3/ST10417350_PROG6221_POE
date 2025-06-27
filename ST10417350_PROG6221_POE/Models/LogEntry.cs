using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10417350_PROG6221_POE.Models
{
    public class LogEntry
    {
        public DateTime Timestamp { get; }
        public string ActionDescription { get; }

        public LogEntry(string description)
        {
            Timestamp = DateTime.Now;
            ActionDescription = description;
        }

        public override string ToString()
        {
            return $"[{Timestamp:HH:mm:ss}] {ActionDescription}";
        }
    }
}