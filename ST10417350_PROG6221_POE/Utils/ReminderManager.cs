//=========================== START OF FILE ===========================//

using ST10417350_PROG6221_POE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Connor Manuel
 * ST10417350@vcconnect.edu.za
 * ST10417350 
 */

namespace ST10417350_PROG6221_POE.Utils
{
    /// <summary>
    /// Manages reminders for scheduled tasks by using Windows Forms timers.
    /// </summary>
    public class ReminderManager
    {
        /// <summary>
        /// A list to keep track of all active reminders.
        /// </summary>
        private List<Reminder> activeReminders = new List<Reminder>();

        /// <summary>
        /// Sets a reminder for a specific task at the provided time.
        /// </summary>
        /// <param name="task">The task to be reminded about.</param>
        /// <param name="time">The future time at which the reminder should trigger.</param>
        public void SetReminder(TaskItem task, DateTime time)
        {
            // Calculate the time difference in milliseconds between now and the scheduled reminder time.
            double interval = (time - DateTime.Now).TotalMilliseconds;

            // If the scheduled time is in the past or immediate, ignore the reminder setup.
            if (interval <= 0) return;

            // Create and configure a new timer.
            Timer timer = new Timer();
            timer.Interval = (int)Math.Min(interval, int.MaxValue); 

            // Define what happens when the timer interval elapses.
            timer.Tick += (s, e) =>
            {
                timer.Stop(); 

                // Show a message box to the user with the task reminder.
                MessageBox.Show(
                    $"Reminder: {task.Title}\n{task.Description}",
                    "Task Reminder",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            };

            // Start the timer.
            timer.Start();

            // Create a Reminder object linking the task and its associated timer.
            Reminder reminder = new Reminder(task, timer);

            // Add the reminder to the active list for future management.
            activeReminders.Add(reminder);
        }

        /// <summary>
        /// Stops and clears all currently active reminders.
        /// </summary>
        public void ClearAllReminders()
        {
            // Loop through all active reminders and clean them up.
            foreach (var reminder in activeReminders)
            {
                reminder.Timer.Stop();      
                reminder.Timer.Dispose();   
            }

            // Clear the list of active reminders.
            activeReminders.Clear();
        }
    }
}
//=========================== END OF FILE ===========================//