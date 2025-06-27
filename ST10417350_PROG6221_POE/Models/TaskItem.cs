using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10417350_PROG6221_POE.Models
{
    public class TaskItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReminderTime { get; set; }
        public bool IsCompleted { get; set; }

        public TaskItem(string title, string description, DateTime? reminderTime = null)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            ReminderTime = reminderTime;
            IsCompleted = false;
        }

        /// <summary>
        /// Returns a user-friendly string representation of the task
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            // Status indicator
            sb.Append(IsCompleted ? "[✓] " : "[ ] ");

            // Title
            sb.AppendLine(Title);

            // Description
            sb.AppendLine($"    {Description}");

            // Optional Reminder
            if (ReminderTime.HasValue)
            {
                string timeText = GetRelativeTime(ReminderTime.Value);
                sb.AppendLine($"    Reminder: {timeText}");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Converts reminder time to friendly text (Today, Tomorrow, or full date)
        /// </summary>
        private string GetRelativeTime(DateTime due)
        {
            TimeSpan diff = due - DateTime.Now;

            if (diff.TotalDays < 1 && due.Date == DateTime.Now.Date)
                return "Today";
            else if (diff.TotalDays >= 1 && diff.TotalDays < 2 && due.Date == DateTime.Now.Date.AddDays(1))
                return "Tomorrow";
            else
                return due.ToString("yyyy-MM-dd HH:mm");
        }
    }
}