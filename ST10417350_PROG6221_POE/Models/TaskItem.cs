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
    /// Represents a single task item which can include a title, description, optional reminder time, and completion status.
    /// </summary>
    public class TaskItem
    {
        /// <summary>
        /// The title of the task.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// A detailed description of the task.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Optional reminder time for the task. Null if no reminder is set.
        /// </summary>
        public DateTime? ReminderTime { get; set; }

        /// <summary>
        /// Boolean flag indicating whether the task is completed.
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Constructor to create a new task with title, description, and optional reminder time.
        /// </summary>
        /// <param name="title">The task title.</param>
        /// <param name="description">The task description.</param>
        /// <param name="reminderTime">Optional reminder time for the task.</param>
        public TaskItem(string title, string description, DateTime? reminderTime = null)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));             
            Description = description ?? throw new ArgumentNullException(nameof(description)); 
            ReminderTime = reminderTime;        
            IsCompleted = false;                
        }

        /// <summary>
        /// Returns a formatted string representation of the task including status, title, description, and optional reminder.
        /// </summary>
        /// <returns>A user-readable string that summarizes the task.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            // Task completion status indicator
            sb.Append(IsCompleted ? "[✓] " : "[ ] ");

            // Task title
            sb.AppendLine(Title);

            // Task description, indented for clarity
            sb.AppendLine($"    {Description}");

            // If a reminder is set, display a friendly time description
            if (ReminderTime.HasValue)
            {
                string timeText = GetRelativeTime(ReminderTime.Value);
                sb.AppendLine($"    Reminder: {timeText}");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Converts the due time to a human-readable label (e.g., Today, Tomorrow, or full timestamp).
        /// </summary>
        /// <param name="due">The DateTime of the reminder.</param>
        /// <returns>A string describing how soon the reminder is due.</returns>
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
//=========================== END OF FILE ===========================//