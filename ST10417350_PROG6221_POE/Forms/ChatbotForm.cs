//=========================== START OF FILE ===========================//

using Microsoft.VisualBasic;
using ST10417350_PROG6221_POE.Models;
using ST10417350_PROG6221_POE.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

/*
 * Connor Manuel
 * ST10417350@vcconnect.edu.za
 * ST10417350 
 */

namespace ST10417350_PROG6221_POE
{
    public partial class ChatbotForm : Form
    {
        private readonly ChatLogic chatLogic = new ChatLogic();
        private readonly List<QuizQuestion> allQuizQuestions = new List<QuizQuestion>();
        private List<QuizQuestion> quizQuestions = new List<QuizQuestion>();
        private int currentQuestionIndex = 0;
        private int score = 0;
        private int logPage = 0;
        private const int LOG_ENTRIES_PER_PAGE = 10;
        private readonly ReminderManager reminderManager = new ReminderManager();
        private readonly Random rand = new Random();
        private const string TITLE_PLACEHOLDER = "Enter Task Title";
        private const string DESCRIPTION_PLACEHOLDER = "Enter Description";
        private NotifyIcon notifyIcon;
        private string userName = "";

        private bool titlePlaceholderVisible = true;
        private bool descriptionPlaceholderVisible = true;

        public ChatbotForm()
        {
            InitializeComponent();
            InitializeChatbot();
            InitializeQuiz(); 
            LoadTasks();
            UpdateLogBox();

            // Set placeholders initially

            titleBox.Text = TITLE_PLACEHOLDER;
            titleBox.ForeColor = SystemColors.GrayText;
            descriptionBox.Text = DESCRIPTION_PLACEHOLDER;
            descriptionBox.ForeColor = SystemColors.GrayText;

            // Wire up events
            titleBox.GotFocus += TitleBox_GotFocus;
            titleBox.LostFocus += TitleBox_LostFocus;
            descriptionBox.GotFocus += DescriptionBox_GotFocus;
            descriptionBox.LostFocus += DescriptionBox_LostFocus;
            mainTabControl.SelectedIndexChanged += MainTabControl_SelectedIndexChanged;
            tabPageActivityLog.Enter += tabPageActivityLog_Enter;
            tabPageQuiz.Enter += tabPageQuiz_Enter;

            // Initialize NotifyIcon
            notifyIcon = new NotifyIcon(new Container())
            {
                Icon = SystemIcons.Application,
                Text = "CyberAware Bot Reminder",
                Visible = true
            };
        }

        /// <summary>
        /// Initializes the chatbot by displaying ASCII art banner,
        /// welcoming the user, asking for their name,
        /// and explaining chatbot capabilities.
        /// Also attempts to play a greeting sound and logs startup.
        /// </summary>
        private void InitializeChatbot()
        {
            // Ensure the form is shown before doing any long-running operations
            Application.DoEvents();

            // Display ASCII banner directly in chat
            AppendChat("Bot", ASCIIArt.GetBanner());

            // Show welcome message
            AppendChat("Bot", "Welcome to the Cybersecurity Awareness Bot!");

            // Ask for user name
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "What is your name?", "Welcome", "User");

            if (!string.IsNullOrWhiteSpace(input))
            {
                userName = input;
                chatLogic.SetUserName(userName);
                AppendChat("Bot", $"Nice to meet you, {userName}!");
            }
            else
            {
                userName = "User";
                chatLogic.SetUserName(userName);
                AppendChat("Bot", "Okay, I'll just call you 'User' for now.");
            }

            // Explain purpose of the chatbot
            chatHistoryBox.AppendText($"[Bot]: Hello {userName}! I'm here to help you stay safe online.\r\n" +
                          "You can ask me about passwords, phishing, privacy, scams, and more!\r\n" +
                          "Type ' help ' for assistance or start asking questions below.\r\n\r\n");
            ScrollToBottom();

            // Play greeting sound after all initial messages are displayed
            try
            {
                Greeting.PlayGreeting();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not play greeting sound: " + ex.Message);
            }

            LogHelper.Add("Chatbot started.");
        }

        /// <summary>
        /// Returns a random response string based on the given cybersecurity keyword.
        /// Provides educational info or a default fallback if keyword not found.
        /// </summary>
        /// <param name="keyword">The keyword to respond to.</param>
        /// <returns>A chatbot response string related to the keyword.</returns>
        private string GetKeywordResponse(string keyword)
        {
            Dictionary<string, List<string>> responses = new Dictionary<string, List<string>>
            {
                { "password", new List<string> {
                    "Use a strong, unique password for each account.",
                    "Avoid reusing passwords across different websites.",
                "Consider using a password manager."
                }},
                { "scam", new List<string> {
                    "Scams often arrive via email or SMS. Always verify the sender.",
                    "Never click suspicious links.",
                    "Look for bad grammar or urgent requests — common scam signs."
                }},
                { "phishing", new List<string> {
                    "Phishing attempts try to trick you into revealing sensitive info.",
                    "Look out for fake login pages and spoofed emails.",
                    "Always verify links before clicking them."
                }},
                { "privacy", new List<string> {
                    "Review your social media privacy settings regularly.",
                    "Be cautious about the personal info you share online.",
                    "Use encrypted messaging apps for private conversations."
                }},
                { "2fa", new List<string> {
                    "Two-factor authentication adds a second layer of security beyond your password.",
                    "Use an authenticator app or hardware key when possible.",
                    "Enable 2FA on all accounts that support it."
                }},
                { "two-factor", new List<string> {
                    "Two-factor authentication adds a second layer of security beyond your password.",
                    "Use an authenticator app or hardware key when possible.",
                    "Enable 2FA on all accounts that support it."
                }}
            };

            if (responses.ContainsKey(keyword))
            {
                List<string> list = responses[keyword];
                return list[rand.Next(list.Count)];
            }

            return "That's an important topic. Let's talk more about it!";
        }

        /// <summary>
        /// Initializes the full set of quiz questions.
        /// Includes a mix of multiple-choice and true/false questions.
        /// After loading, it restarts the quiz to shuffle questions.
        /// </summary>
        private void InitializeQuiz()
        {
            // 20 quiz questions (4 true/false)
            allQuizQuestions.Add(new QuizQuestion(
                "What should you do if you receive an email asking for your password?",
                new string[] { "Reply with your password", "Delete the email", "Report the email as phishing", "Ignore it" },
                2));
            allQuizQuestions.Add(new QuizQuestion(
                "Which of these is a strong password?",
                new string[] { "password123", "abc", "P@ssw0rd!", "123456" },
                2));
            allQuizQuestions.Add(new QuizQuestion(
                "What is phishing?",
                new string[] { "A type of fish", "A scam that tricks users into revealing sensitive info", "A computer virus", "An antivirus software" },
                1));
            allQuizQuestions.Add(new QuizQuestion(
                "True or False: Public Wi-Fi is always secure.",
                new string[] { "True", "False" },
                1)); // T/F
            allQuizQuestions.Add(new QuizQuestion(
                "What does 2FA stand for?",
                new string[] { "Two-Factor Authentication", "Two Fast Answers", "Third Friendly Approach", "None of the above" },
                0));
            allQuizQuestions.Add(new QuizQuestion(
                "Which of the following is NOT a good practice for password safety?",
                new string[] { "Use unique passwords for each account", "Avoid sharing passwords", "Re-use passwords across sites", "Use a password manager" },
                2));
            allQuizQuestions.Add(new QuizQuestion(
                "What is malware?",
                new string[] { "Software designed to protect your device", "Malicious software designed to harm or exploit systems", "Hardware used for security", "None of the above" },
                1));
            allQuizQuestions.Add(new QuizQuestion(
                "You receive a call from someone claiming to be from your bank. What should you do?",
                new string[] { "Give them your account details", "Hang up and contact your bank directly", "Ask them to send a confirmation email", "None of the above" },
                1));
            allQuizQuestions.Add(new QuizQuestion(
                "Social engineering attacks rely on:",
                new string[] { "Technology flaws", "Human psychology", "Weak passwords", "Slow internet" },
                1));
            allQuizQuestions.Add(new QuizQuestion(
                "What is the best way to back up important data?",
                new string[] { "Store it on your desktop", "Email it to yourself", "Use cloud storage or external drives", "Print it out" },
                2));
            allQuizQuestions.Add(new QuizQuestion(
                "How often should you update your passwords?",
                new string[] { "Every day", "Never", "When there's a breach", "Once a year" },
                2));
            allQuizQuestions.Add(new QuizQuestion(
                "True or False: Antivirus protects against all types of threats.",
                new string[] { "True", "False" },
                1)); // T/F
            allQuizQuestions.Add(new QuizQuestion(
                "What is a firewall?",
                new string[] { "Physical wall", "Software or hardware that blocks unauthorized access", "A browser", "An email filter" },
                1));
            allQuizQuestions.Add(new QuizQuestion(
                "True or False: Phishing emails can look like they're from real companies.",
                new string[] { "True", "False" },
                0)); // T/F
            allQuizQuestions.Add(new QuizQuestion(
                "True or False: Two-factor authentication makes your account more secure.",
                new string[] { "True", "False" },
                0)); // T/F
            allQuizQuestions.Add(new QuizQuestion(
                "What is a brute-force attack?",
                new string[] { "Trying random answers", "Using force to open a laptop", "Automated guessing of passwords", "Hacking via social media" },
                2));
            allQuizQuestions.Add(new QuizQuestion(
                "Where should you store passwords?",
                new string[] { "On sticky notes", "In your head", "Password manager", "Shared document" },
                2));
            allQuizQuestions.Add(new QuizQuestion(
                "What is a suspicious sign in an email?",
                new string[] { "Correct grammar", "Urgent request for personal info", "Clear sender name", "Proper formatting" },
                1));
            allQuizQuestions.Add(new QuizQuestion(
                "What is ransomware?",
                new string[] { "A firewall", "Antivirus", "Malware that locks files until paid", "Browser history" },
                2));
            allQuizQuestions.Add(new QuizQuestion(
                "What should you do if you suspect identity theft?",
                new string[] { "Do nothing", "Change passwords and report it", "Share it online", "Forget about it" },
                1));

            RestartQuiz();
        }

        /// <summary>
        /// Resets and randomizes the quiz question set.
        /// Ensures exactly 2 true/false and 8 other questions are selected and shuffled.
        /// Resets current question index and score, then displays first question.
        /// </summary>
        private void RestartQuiz()
        {
            Random rand = new Random();
            quizQuestions.Clear();
            var trueFalseQuestions = allQuizQuestions.Where(q => q.Options.Length == 2).ToList();
            var otherQuestions = allQuizQuestions.Where(q => q.Options.Length > 2).ToList();

            if (trueFalseQuestions.Count < 2)
            {
                MessageBox.Show("Not enough True/False questions available.", "Quiz Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedTf = trueFalseQuestions.OrderBy(q => rand.Next()).Take(2).ToList();
            var others = otherQuestions
                .Where(q => !selectedTf.Contains(q))
                .OrderBy(q => rand.Next())
                .Take(8)
                .ToList();

            quizQuestions.AddRange(selectedTf);
            quizQuestions.AddRange(others);
            quizQuestions = quizQuestions.OrderBy(q => rand.Next()).ToList();

            currentQuestionIndex = 0;
            score = 0;
            ShowCurrentQuestion();
            scoreLabel.Text = $"Score: {score}/{quizQuestions.Count}";
        }

        /// <summary>
        /// Displays the current quiz question and options on the UI.
        /// Handles quiz completion by showing results, feedback, and restart prompt.
        /// Removes any dynamic labels from previous questions.
        /// </summary>
        private void ShowCurrentQuestion()
        {
            // Remove dynamic labels
            tabPageQuiz.Controls.OfType<Label>().ToList().ForEach(lbl =>
            {
                if (lbl.Tag?.ToString() == "Dynamic")
                    tabPageQuiz.Controls.Remove(lbl);
            });

            if (currentQuestionIndex >= quizQuestions.Count || currentQuestionIndex < 0)
            {
                questionLabel.Text = "Quiz complete!";
                string resultText;
                Color resultColor;

                if (score >= 8)
                {
                    resultText = $"Great job! Final Score: {score}/{quizQuestions.Count}\r\nYou're a cybersecurity pro!";
                    resultColor = Color.Green;
                }
                else if (score >= 5)
                {
                    resultText = $"Good effort! Final Score: {score}/{quizQuestions.Count}\r\nKeep learning!";
                    resultColor = Color.Gold;
                }
                else
                {
                    resultText = $"Final Score: {score}/{quizQuestions.Count}\r\nYou need to study more.";
                    resultColor = Color.Red;
                }

                feedbackLabel.Text = resultText;
                feedbackLabel.ForeColor = resultColor;

                // Update score label one last time
                scoreLabel.Text = $"Score: {score}/{quizQuestions.Count}";

                DialogResult result = MessageBox.Show("Quiz complete! Would you like to restart?", "Quiz Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    RestartQuiz();
                    nextButton.Enabled = true;
                }
                else
                {
                    nextButton.Enabled = false;
                }

                return;
            }

            QuizQuestion q = quizQuestions[currentQuestionIndex];
            questionLabel.Text = q.QuestionText;
            progressLabel.Text = $"Question {currentQuestionIndex + 1} of {quizQuestions.Count}";

            option1Radio.Visible = q.Options.Length > 0;
            option2Radio.Visible = q.Options.Length > 1;
            option3Radio.Visible = q.Options.Length > 2;
            option4Radio.Visible = q.Options.Length > 3;

            option1Radio.Checked = false;
            option2Radio.Checked = false;
            option3Radio.Checked = false;
            option4Radio.Checked = false;

            if (q.Options.Length > 0) option1Radio.Text = q.Options[0];
            if (q.Options.Length > 1) option2Radio.Text = q.Options[1];
            if (q.Options.Length > 2) option3Radio.Text = q.Options[2];
            if (q.Options.Length > 3) option4Radio.Text = q.Options[3];
        }

        /// <summary>
        /// Loads and appends the next page of log entries to the log display box.
        /// Handles scenario when no more logs remain to show.
        /// </summary>
        private void ShowMoreLogs()
        {
            var allLogs = LogHelper.GetAll().OrderByDescending(l => l.Timestamp).ToList();
            int startIndex = logPage * LOG_ENTRIES_PER_PAGE;
            int endIndex = startIndex + LOG_ENTRIES_PER_PAGE;
            if (startIndex >= allLogs.Count)
            {
                logBox.AppendText("No more logs to show.\r\n");
                return;
            }
            for (int i = startIndex; i < Math.Min(endIndex, allLogs.Count); i++)
            {
                logBox.AppendText(allLogs[i].ToString() + "\r\n");
            }
            logPage++;
        }

        /// <summary>
        /// Clears and reloads the first page of log entries in the log display box.
        /// Resets paging state for further log navigation.
        /// </summary>
        private void UpdateLogBox()
        {
            logBox.Clear();
            var allLogs = LogHelper.GetAll().OrderByDescending(l => l.Timestamp).ToList();
            int startIndex = 0;
            int endIndex = Math.Min(startIndex + LOG_ENTRIES_PER_PAGE, allLogs.Count);
            for (int i = startIndex; i < endIndex; i++)
            {
                logBox.AppendText(allLogs[i].ToString() + "\r\n");
            }
            logPage = 1; 
        }

        /// <summary>
        /// Event handler triggered when Activity Log tab is entered.
        /// Resets log page counter and refreshes the log box contents.
        /// </summary>
        private void tabPageActivityLog_Enter(object sender, EventArgs e)
        {
            logPage = 0;
            UpdateLogBox();
        }

        /// <summary>
        /// Handles tab control index changes.
        /// Clears quiz UI if user navigates away from the Quiz tab.
        /// </summary>
        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainTabControl.SelectedTab != tabPageQuiz)
            {
                ClearQuizUI();
            }
        }

        /// <summary>
        /// Clears all quiz UI elements and dynamic feedback labels.
        /// Resets radio buttons and score labels to initial state.
        /// </summary>
        private void ClearQuizUI()
        {
            questionLabel.Text = "";
            feedbackLabel.Text = "";
            scoreLabel.Text = "Score: 0/0";
            tabPageQuiz.Controls.OfType<Label>()
                .Where(lbl => lbl.Tag?.ToString() == "Dynamic")
                .ToList()
                .ForEach(lbl => tabPageQuiz.Controls.Remove(lbl));
            option1Radio.Checked = false;
            option2Radio.Checked = false;
            option3Radio.Checked = false;
            option4Radio.Checked = false;
        }

        private int GetSelectedAnswerIndex()
        {
            if (option1Radio.Checked) return 0;
            if (option2Radio.Checked) return 1;
            if (option3Radio.Checked) return 2;
            if (option4Radio.Checked) return 3;
            return -1;
        }

        /// <summary>
        /// Handles the click event for the 'Next' button in the quiz.
        /// Validates answer selection, updates score, provides feedback,
        /// logs the result, and advances to the next question.
        /// </summary>
        /// <param name="sender">Event sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void nextButton_Click(object sender, EventArgs e)
        {
            int selected = GetSelectedAnswerIndex();
            if (selected == -1)
            {
                MessageBox.Show("Please select an answer.", "Quiz", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QuizQuestion current = quizQuestions[currentQuestionIndex];

            if (selected == current.CorrectOptionIndex)
            {
                score++;
                feedbackLabel.Text = "Correct!";
                feedbackLabel.ForeColor = Color.Green;
            }
            else
            {
                string correctAnswer = current.Options[current.CorrectOptionIndex];
                feedbackLabel.Text = $"Incorrect. Correct answer was: {correctAnswer}";
                feedbackLabel.ForeColor = Color.Red;

                Label dynamicLabel = new Label
                {
                    AutoSize = true,
                    Location = new Point(feedbackLabel.Left, feedbackLabel.Bottom + 5),
                    Text = $"✔️ {correctAnswer}",
                    ForeColor = Color.Green,
                    Tag = "Dynamic"
                };

                tabPageQuiz.Controls.Add(dynamicLabel);

                Timer timer = new Timer();
                timer.Interval = 3000;
                timer.Tick += (s, args) =>
                {
                    tabPageQuiz.Controls.Remove(dynamicLabel);
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();
            }

            LogHelper.Add($"Quiz: Question {currentQuestionIndex + 1} - {(selected == current.CorrectOptionIndex ? "Correct" : "Incorrect")}");
            currentQuestionIndex++;
            ShowCurrentQuestion();
            scoreLabel.Text = $"Score: {score}/{quizQuestions.Count}";
        }

        /// <summary>
        /// Handles GotFocus event for the title text box.
        /// Removes placeholder text and sets text color to default on user focus.
        /// </summary>
        private void TitleBox_GotFocus(object sender, EventArgs e)
        {
            if (titlePlaceholderVisible)
            {
                titleBox.Text = "";
                titleBox.ForeColor = Color.Black;
                titlePlaceholderVisible = false;
            }
        }

        /// <summary>
        /// Handles LostFocus event for the title text box.
        /// Restores placeholder text and gray color if the box is empty.
        /// </summary>
        private void TitleBox_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleBox.Text))
            {
                titleBox.Text = TITLE_PLACEHOLDER;
                titleBox.ForeColor = SystemColors.GrayText;
                titlePlaceholderVisible = true;
            }
        }

        /// <summary>
        /// Handles GotFocus event for the description text box.
        /// Removes placeholder text and resets text color on user focus.
        /// </summary>
        private void DescriptionBox_GotFocus(object sender, EventArgs e)
        {
            if (descriptionPlaceholderVisible)
            {
                descriptionBox.Text = "";
                descriptionBox.ForeColor = Color.Black;
                descriptionPlaceholderVisible = false;
            }
        }

        /// <summary>
        /// Handles LostFocus event for the description text box.
        /// Restores placeholder text and gray color if the box is empty.
        /// </summary>
        private void DescriptionBox_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(descriptionBox.Text))
            {
                descriptionBox.Text = DESCRIPTION_PLACEHOLDER;
                descriptionBox.ForeColor = SystemColors.GrayText;
                descriptionPlaceholderVisible = true;
            }
        }

        /// <summary>
        /// Loads and sorts tasks into the task list box.
        /// Sorts first by completion status, then by reminder time.
        /// </summary>
        private void LoadTasks()
        {
            taskListBox.Items.Clear();
            var sortedTasks = TaskManager.Tasks
                .OrderBy(t => t.IsCompleted)
                .ThenBy(t => t.ReminderTime ?? DateTime.MaxValue)
                .ToList();

            foreach (var task in sortedTasks)
            {
                taskListBox.Items.Add(task);
            }
        }

        /// <summary>
        /// Handles the click event for the send button in the chatbot.
        /// Processes user input, appends chat history, logs conversation,
        /// handles task list keyword detection, and clears input.
        /// </summary>
        private void sendButton_Click(object sender, EventArgs e)
        {
            string userInput = inputBox.Text.Trim();
            if (string.IsNullOrEmpty(userInput)) return;

            chatHistoryBox.AppendText($"[You]: {userInput}\r\n");
            ScrollToBottom();

            // Normal chat processing
            string botResponse = chatLogic.ProcessInput(userInput);
            chatHistoryBox.AppendText($"[Bot]: {botResponse}\r\n\r\n");
            LogHelper.Add($"User: {userInput}");
            LogHelper.Add($"Bot: {botResponse}");

            // Optional: Tasks keyword detection to display current tasks
            if (userInput.ToLower().Contains("tasks") ||
                userInput.ToLower().Contains("show my tasks"))
            {
                StringBuilder sb = new StringBuilder("Here are your current tasks:\r\n");
                var incomplete = TaskManager.Tasks.Where(t => !t.IsCompleted).ToList();
                var complete = TaskManager.Tasks.Where(t => t.IsCompleted).ToList();

                if (incomplete.Count > 0)
                {
                    sb.AppendLine("📌 Incomplete:");
                    foreach (var task in incomplete.Take(10))
                    {
                        sb.AppendLine($" - {task.Title}{(task.ReminderTime.HasValue ? $" (Due: {task.ReminderTime.Value:g})" : "")}");
                    }
                }

                if (complete.Count > 0)
                {
                    sb.AppendLine("\r\n✅ Completed:");
                    foreach (var task in complete.Take(10))
                    {
                        sb.AppendLine($" - {task.Title}");
                    }
                }

                chatHistoryBox.AppendText($"[Bot]: {sb.ToString()}\r\n");
                ScrollToBottom();
            }

            ScrollToBottom();
            inputBox.Clear();
        }

        /// <summary>
        /// Scrolls the chat history box to the bottom to show the latest messages.
        /// </summary>
        private void ScrollToBottom()
        {
            if (chatHistoryBox.TextLength > 0)
            {
                chatHistoryBox.SelectionStart = chatHistoryBox.TextLength;
                chatHistoryBox.ScrollToCaret();
            }
        }

        /// <summary>
        /// Handles the KeyDown event for the input box.
        /// Submits the input when Enter key is pressed, suppressing the key to avoid newline.
        /// </summary>
        private void inputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendButton_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Handles the click event for adding a new task.
        /// Validates input, optionally sets reminder, adds the task, and logs the action.
        /// </summary>
        private void addTaskButton_Click(object sender, EventArgs e)
        {
            string title = titleBox.Text.Trim();
            string description = descriptionBox.Text.Trim();

            if (title == TITLE_PLACEHOLDER || string.IsNullOrWhiteSpace(title) ||
                description == DESCRIPTION_PLACEHOLDER || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Title and description are required.", "Add Task", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime? reminderTime = null;
            if (MessageBox.Show("Set a reminder?", "Add Task", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                reminderTime = dateTimePicker1.Value;
            }

            var task = new TaskItem(title, description, reminderTime);
            TaskManager.Tasks.Add(task);

            if (reminderTime.HasValue)
            {
                reminderManager.SetReminder(task, reminderTime.Value);
                LogHelper.Add($"Reminder set for '{title}' at {reminderTime.Value:g}");
            }

            LogHelper.Add($"Task added: {title}");
            LoadTasks();
        }

        /// <summary>
        /// Handles the click event to mark the selected task as completed.
        /// Updates task status, logs the action, and reloads the task list.
        /// </summary>
        private void completeTaskButton_Click(object sender, EventArgs e)
        {
            if (taskListBox.SelectedItem is TaskItem task)
            {
                task.IsCompleted = true;
                LogHelper.Add($"Task completed: {task.Title}");
                LoadTasks();
            }
        }

        /// <summary>
        /// Handles the click event to delete the selected task.
        /// Removes the task, logs the deletion, and reloads the task list.
        /// </summary>
        private void deleteTaskButton_Click(object sender, EventArgs e)
        {
            if (taskListBox.SelectedItem is TaskItem task)
            {
                TaskManager.Tasks.Remove(task);
                LogHelper.Add($"Task deleted: {task.Title}");
                LoadTasks();
            }
        }

        /// <summary>
        /// Handles the click event to edit the selected task's title and description.
        /// Prompts user for new values, updates the task, logs the changes, and reloads the list.
        /// </summary>
        private void editTaskButton_Click(object sender, EventArgs e)
        {
            if (taskListBox.SelectedItem is TaskItem selectedTask)
            {
                string newTitle = Interaction.InputBox("Edit Title", "Edit Task", selectedTask.Title);
                string newDescription = Interaction.InputBox("Edit Description", "Edit Task", selectedTask.Description);

                if (!string.IsNullOrWhiteSpace(newTitle))
                {
                    selectedTask.Title = newTitle;
                    selectedTask.Description = newDescription;
                    LogHelper.Add($"Task edited: {selectedTask.Title}");
                    LoadTasks();
                }
            }
        }

        /// <summary>
        /// Custom draw event for task list box items.
        /// Colors tasks green if completed, red if overdue reminders, or default black otherwise.
        /// </summary>
        private void taskListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();
            var task = TaskManager.Tasks[e.Index];
            Brush brush = Brushes.Black;

            if (task.IsCompleted)
                brush = Brushes.Green;
            else if (task.ReminderTime.HasValue && task.ReminderTime.Value < DateTime.Now)
                brush = Brushes.Red;

            string text = task.ToString();
            TextFormatFlags flags = TextFormatFlags.WordBreak | TextFormatFlags.VerticalCenter | TextFormatFlags.TextBoxControl;
            Rectangle bounds = e.Bounds;
            TextRenderer.DrawText(e.Graphics, text, e.Font, bounds, ((SolidBrush)brush).Color, flags);
            e.DrawFocusRectangle();
        }

        /// <summary>
        /// Returns a random fallback response for unrecognized chatbot inputs.
        /// </summary>
        /// <returns>A randomly selected fallback response string.</returns>
        private string GetRandomFallback()
        {
            List<string> responses = new List<string>
    {
        "Interesting! Tell me more.",
        "That's good to know.",
        "Cybersecurity is important. Let's talk about it!",
        "Thanks for sharing!"
    };
            return responses[rand.Next(responses.Count)];
        }

        /// <summary>
        /// Form load event handler for chatbot form.
        /// Sets up custom drawing mode and event for the task list box.
        /// </summary>
        private void ChatbotForm_Load(object sender, EventArgs e)
        {
            taskListBox.DrawMode = DrawMode.OwnerDrawFixed;
            taskListBox.ItemHeight = 40;
            taskListBox.DrawItem += taskListBox_DrawItem;
        }

        /// <summary>
        /// Handles the click event for the 'Show More' logs button.
        /// Loads additional logs and scrolls the chat history to bottom.
        /// </summary>
        private void showMoreButton_Click(object sender, EventArgs e)
        {
            ShowMoreLogs();
            ScrollToBottom();
        }

        /// <summary>
        /// Helper method to append a chat message with a speaker label to the chat history box.
        /// Automatically scrolls to the end.
        /// </summary>
        /// <param name="speaker">Speaker name, e.g., "You" or "Bot".</param>
        /// <param name="message">Message text to append.</param>
        private void AppendChat(string speaker, string message)
        {
            chatHistoryBox.AppendText($"[{speaker}]: {message}\r\n\r\n");

            // Scroll to the end automatically
            chatHistoryBox.SelectionStart = chatHistoryBox.TextLength;
            chatHistoryBox.ScrollToCaret();
        }

        /// <summary>
        /// Handles entering the quiz tab page.
        /// Resets and restarts the quiz, enabling the next button.
        /// </summary>
        private void tabPageQuiz_Enter(object sender, EventArgs e)
        {
            RestartQuiz();
            nextButton.Enabled = true;
        }

        /// <summary>
        /// Static manager class holding the global list of tasks.
        /// </summary>
        public static class TaskManager
        {
            /// <summary>
            /// The shared list of TaskItem objects representing the user's tasks.
            /// </summary>
            public static List<TaskItem> Tasks { get; } = new List<TaskItem>();
        }
    }
}
//=========================== END OF FILE ===========================//