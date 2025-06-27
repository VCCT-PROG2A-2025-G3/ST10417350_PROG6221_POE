using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ST10417350_PROG6221_POE.Models
{
    public class Reminder
    {
        public TaskItem Task { get; set; }
        public Timer Timer { get; set; }

        public Reminder(TaskItem task, Timer timer)
        {
            Task = task;
            Timer = timer;
        }
    }
}