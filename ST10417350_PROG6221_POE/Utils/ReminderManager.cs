using ST10417350_PROG6221_POE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ST10417350_PROG6221_POE.Utils
{
    public class ReminderManager
    {
        private List<Reminder> activeReminders = new List<Reminder>();

        /// <summary>
        /// Sets a reminder for a task at the specified time.
        /// </summary>
        public void SetReminder(TaskItem task, DateTime time)
        {
            double interval = (time - DateTime.Now).TotalMilliseconds;
            if (interval <= 0) return;

            Timer timer = new Timer();
            timer.Interval = (int)Math.Min(interval, int.MaxValue);
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                MessageBox.Show($"Reminder: {task.Title}\n{task.Description}", "Task Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            timer.Start();

            // ✅ Create a Reminder object with both Task and Timer
            Reminder reminder = new Reminder(task, timer);

            // ✅ Add the Reminder object to the list
            activeReminders.Add(reminder);
        }

        /// <summary>
        /// Clears all active reminders (e.g., when form closes or tasks are deleted).
        /// </summary>
        public void ClearAllReminders()
        {
            foreach (var reminder in activeReminders)
            {
                reminder.Timer.Stop();
                reminder.Timer.Dispose();
            }
            activeReminders.Clear();
        }
    }
}