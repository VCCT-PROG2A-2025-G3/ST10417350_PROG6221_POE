//=========================== START OF FILE ===========================//

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

namespace ST10417350_PROG6221_POE.Models
{
    /// <summary>
    /// Represents a reminder which links a task item with a timer to trigger notifications.
    /// </summary>
    public class Reminder
    {
        /// <summary>
        /// The task associated with this reminder.
        /// </summary>
        public TaskItem Task { get; set; }

        /// <summary>
        /// The timer responsible for triggering the reminder.
        /// </summary>
        public Timer Timer { get; set; }

        /// <summary>
        /// Constructs a Reminder object binding a TaskItem with a Timer.
        /// </summary>
        /// <param name="task">The task to remind about.</param>
        /// <param name="timer">The timer that triggers the reminder event.</param>
        public Reminder(TaskItem task, Timer timer)
        {
            Task = task;
            Timer = timer;
        }
    }
}
//=========================== END OF FILE ===========================//