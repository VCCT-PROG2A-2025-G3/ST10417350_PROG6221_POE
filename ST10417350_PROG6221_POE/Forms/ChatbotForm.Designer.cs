namespace ST10417350_PROG6221_POE
{
    partial class ChatbotForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabPageChatBot = new System.Windows.Forms.TabPage();
            this.sendButton = new System.Windows.Forms.Button();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.chatHistoryBox = new System.Windows.Forms.RichTextBox();
            this.asciiBox = new System.Windows.Forms.TextBox();
            this.tabPageQuiz = new System.Windows.Forms.TabPage();
            this.progressLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.feedbackLabel = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.option4Radio = new System.Windows.Forms.RadioButton();
            this.option3Radio = new System.Windows.Forms.RadioButton();
            this.option2Radio = new System.Windows.Forms.RadioButton();
            this.option1Radio = new System.Windows.Forms.RadioButton();
            this.questionLabel = new System.Windows.Forms.Label();
            this.tabPageTasks = new System.Windows.Forms.TabPage();
            this.editTaskButton = new System.Windows.Forms.Button();
            this.deleteTaskButton = new System.Windows.Forms.Button();
            this.completeTaskButton = new System.Windows.Forms.Button();
            this.addTaskButton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.taskListBox = new System.Windows.Forms.ListBox();
            this.tabPageActivityLog = new System.Windows.Forms.TabPage();
            this.showMoreButton = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.mainTabControl.SuspendLayout();
            this.tabPageChatBot.SuspendLayout();
            this.tabPageQuiz.SuspendLayout();
            this.tabPageTasks.SuspendLayout();
            this.tabPageActivityLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabPageChatBot);
            this.mainTabControl.Controls.Add(this.tabPageQuiz);
            this.mainTabControl.Controls.Add(this.tabPageTasks);
            this.mainTabControl.Controls.Add(this.tabPageActivityLog);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(800, 451);
            this.mainTabControl.TabIndex = 0;
            // 
            // tabPageChatBot
            // 
            this.tabPageChatBot.Controls.Add(this.sendButton);
            this.tabPageChatBot.Controls.Add(this.inputBox);
            this.tabPageChatBot.Controls.Add(this.chatHistoryBox);
            this.tabPageChatBot.Controls.Add(this.asciiBox);
            this.tabPageChatBot.Location = new System.Drawing.Point(4, 22);
            this.tabPageChatBot.Name = "tabPageChatBot";
            this.tabPageChatBot.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChatBot.Size = new System.Drawing.Size(792, 425);
            this.tabPageChatBot.TabIndex = 0;
            this.tabPageChatBot.Text = "Chatbot";
            this.tabPageChatBot.UseVisualStyleBackColor = true;
            // 
            // sendButton
            // 
            this.sendButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sendButton.Location = new System.Drawing.Point(3, 379);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(786, 23);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // inputBox
            // 
            this.inputBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.inputBox.Location = new System.Drawing.Point(3, 402);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(786, 20);
            this.inputBox.TabIndex = 2;
            this.inputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputBox_KeyDown);
            // 
            // chatHistoryBox
            // 
            this.chatHistoryBox.Location = new System.Drawing.Point(3, 34);
            this.chatHistoryBox.Name = "chatHistoryBox";
            this.chatHistoryBox.ReadOnly = true;
            this.chatHistoryBox.Size = new System.Drawing.Size(786, 338);
            this.chatHistoryBox.TabIndex = 1;
            this.chatHistoryBox.Text = "";
            // 
            // asciiBox
            // 
            this.asciiBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.asciiBox.Location = new System.Drawing.Point(3, 3);
            this.asciiBox.Multiline = true;
            this.asciiBox.Name = "asciiBox";
            this.asciiBox.ReadOnly = true;
            this.asciiBox.Size = new System.Drawing.Size(786, 25);
            this.asciiBox.TabIndex = 0;
            this.asciiBox.Text = "Cyber Security Awareness Bot";
            // 
            // tabPageQuiz
            // 
            this.tabPageQuiz.Controls.Add(this.progressLabel);
            this.tabPageQuiz.Controls.Add(this.scoreLabel);
            this.tabPageQuiz.Controls.Add(this.feedbackLabel);
            this.tabPageQuiz.Controls.Add(this.nextButton);
            this.tabPageQuiz.Controls.Add(this.option4Radio);
            this.tabPageQuiz.Controls.Add(this.option3Radio);
            this.tabPageQuiz.Controls.Add(this.option2Radio);
            this.tabPageQuiz.Controls.Add(this.option1Radio);
            this.tabPageQuiz.Controls.Add(this.questionLabel);
            this.tabPageQuiz.Location = new System.Drawing.Point(4, 22);
            this.tabPageQuiz.Name = "tabPageQuiz";
            this.tabPageQuiz.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageQuiz.Size = new System.Drawing.Size(792, 425);
            this.tabPageQuiz.TabIndex = 1;
            this.tabPageQuiz.Text = "Quiz";
            this.tabPageQuiz.UseVisualStyleBackColor = true;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(8, 382);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(92, 13);
            this.progressLabel.TabIndex = 8;
            this.progressLabel.Text = "Question Number ";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Location = new System.Drawing.Point(726, 3);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(58, 13);
            this.scoreLabel.TabIndex = 7;
            this.scoreLabel.Text = "Score: 0/0";
            // 
            // feedbackLabel
            // 
            this.feedbackLabel.AutoSize = true;
            this.feedbackLabel.Location = new System.Drawing.Point(29, 320);
            this.feedbackLabel.Name = "feedbackLabel";
            this.feedbackLabel.Size = new System.Drawing.Size(0, 13);
            this.feedbackLabel.TabIndex = 6;
            // 
            // nextButton
            // 
            this.nextButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.nextButton.Location = new System.Drawing.Point(3, 399);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(786, 23);
            this.nextButton.TabIndex = 5;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // option4Radio
            // 
            this.option4Radio.AutoSize = true;
            this.option4Radio.Location = new System.Drawing.Point(32, 269);
            this.option4Radio.Name = "option4Radio";
            this.option4Radio.Size = new System.Drawing.Size(65, 17);
            this.option4Radio.TabIndex = 4;
            this.option4Radio.TabStop = true;
            this.option4Radio.Text = "Option 4";
            this.option4Radio.UseVisualStyleBackColor = true;
            // 
            // option3Radio
            // 
            this.option3Radio.AutoSize = true;
            this.option3Radio.Location = new System.Drawing.Point(32, 212);
            this.option3Radio.Name = "option3Radio";
            this.option3Radio.Size = new System.Drawing.Size(65, 17);
            this.option3Radio.TabIndex = 3;
            this.option3Radio.TabStop = true;
            this.option3Radio.Text = "Option 3";
            this.option3Radio.UseVisualStyleBackColor = true;
            // 
            // option2Radio
            // 
            this.option2Radio.AutoSize = true;
            this.option2Radio.Location = new System.Drawing.Point(32, 156);
            this.option2Radio.Name = "option2Radio";
            this.option2Radio.Size = new System.Drawing.Size(65, 17);
            this.option2Radio.TabIndex = 2;
            this.option2Radio.TabStop = true;
            this.option2Radio.Text = "Option 2";
            this.option2Radio.UseVisualStyleBackColor = true;
            // 
            // option1Radio
            // 
            this.option1Radio.AutoSize = true;
            this.option1Radio.Location = new System.Drawing.Point(32, 99);
            this.option1Radio.Name = "option1Radio";
            this.option1Radio.Size = new System.Drawing.Size(65, 17);
            this.option1Radio.TabIndex = 1;
            this.option1Radio.TabStop = true;
            this.option1Radio.Text = "Option 1";
            this.option1Radio.UseVisualStyleBackColor = true;
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.questionLabel.Location = new System.Drawing.Point(3, 3);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(114, 13);
            this.questionLabel.TabIndex = 0;
            this.questionLabel.Text = "Question will go here...";
            // 
            // tabPageTasks
            // 
            this.tabPageTasks.Controls.Add(this.editTaskButton);
            this.tabPageTasks.Controls.Add(this.deleteTaskButton);
            this.tabPageTasks.Controls.Add(this.completeTaskButton);
            this.tabPageTasks.Controls.Add(this.addTaskButton);
            this.tabPageTasks.Controls.Add(this.dateTimePicker1);
            this.tabPageTasks.Controls.Add(this.descriptionBox);
            this.tabPageTasks.Controls.Add(this.titleBox);
            this.tabPageTasks.Controls.Add(this.taskListBox);
            this.tabPageTasks.Location = new System.Drawing.Point(4, 22);
            this.tabPageTasks.Name = "tabPageTasks";
            this.tabPageTasks.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTasks.Size = new System.Drawing.Size(792, 425);
            this.tabPageTasks.TabIndex = 2;
            this.tabPageTasks.Text = "Tasks";
            this.tabPageTasks.UseVisualStyleBackColor = true;
            // 
            // editTaskButton
            // 
            this.editTaskButton.Location = new System.Drawing.Point(0, 398);
            this.editTaskButton.Name = "editTaskButton";
            this.editTaskButton.Size = new System.Drawing.Size(270, 23);
            this.editTaskButton.TabIndex = 7;
            this.editTaskButton.Text = "Edit Task";
            this.editTaskButton.UseVisualStyleBackColor = true;
            this.editTaskButton.Click += new System.EventHandler(this.editTaskButton_Click);
            // 
            // deleteTaskButton
            // 
            this.deleteTaskButton.Location = new System.Drawing.Point(474, 398);
            this.deleteTaskButton.Name = "deleteTaskButton";
            this.deleteTaskButton.Size = new System.Drawing.Size(93, 23);
            this.deleteTaskButton.TabIndex = 6;
            this.deleteTaskButton.Text = "Delete Task";
            this.deleteTaskButton.UseVisualStyleBackColor = true;
            this.deleteTaskButton.Click += new System.EventHandler(this.deleteTaskButton_Click);
            // 
            // completeTaskButton
            // 
            this.completeTaskButton.Location = new System.Drawing.Point(375, 398);
            this.completeTaskButton.Name = "completeTaskButton";
            this.completeTaskButton.Size = new System.Drawing.Size(93, 23);
            this.completeTaskButton.TabIndex = 5;
            this.completeTaskButton.Text = "Complete Task";
            this.completeTaskButton.UseVisualStyleBackColor = true;
            this.completeTaskButton.Click += new System.EventHandler(this.completeTaskButton_Click);
            // 
            // addTaskButton
            // 
            this.addTaskButton.Location = new System.Drawing.Point(276, 398);
            this.addTaskButton.Name = "addTaskButton";
            this.addTaskButton.Size = new System.Drawing.Size(93, 23);
            this.addTaskButton.TabIndex = 4;
            this.addTaskButton.Text = "Add Task";
            this.addTaskButton.UseVisualStyleBackColor = true;
            this.addTaskButton.Click += new System.EventHandler(this.addTaskButton_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(573, 1);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(276, 26);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionBox.Size = new System.Drawing.Size(291, 366);
            this.descriptionBox.TabIndex = 2;
            this.descriptionBox.Text = "Task Description";
            // 
            // titleBox
            // 
            this.titleBox.Location = new System.Drawing.Point(276, 0);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(291, 20);
            this.titleBox.TabIndex = 1;
            this.titleBox.Text = "Task Title";
            // 
            // taskListBox
            // 
            this.taskListBox.FormattingEnabled = true;
            this.taskListBox.Location = new System.Drawing.Point(0, 1);
            this.taskListBox.Name = "taskListBox";
            this.taskListBox.Size = new System.Drawing.Size(270, 420);
            this.taskListBox.TabIndex = 0;
            // 
            // tabPageActivityLog
            // 
            this.tabPageActivityLog.Controls.Add(this.showMoreButton);
            this.tabPageActivityLog.Controls.Add(this.logBox);
            this.tabPageActivityLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageActivityLog.Name = "tabPageActivityLog";
            this.tabPageActivityLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageActivityLog.Size = new System.Drawing.Size(792, 425);
            this.tabPageActivityLog.TabIndex = 3;
            this.tabPageActivityLog.Text = "Activity Log";
            this.tabPageActivityLog.UseVisualStyleBackColor = true;
            // 
            // showMoreButton
            // 
            this.showMoreButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.showMoreButton.Location = new System.Drawing.Point(3, 399);
            this.showMoreButton.Name = "showMoreButton";
            this.showMoreButton.Size = new System.Drawing.Size(786, 23);
            this.showMoreButton.TabIndex = 1;
            this.showMoreButton.Text = "Show More";
            this.showMoreButton.UseVisualStyleBackColor = true;
            this.showMoreButton.Click += new System.EventHandler(this.showMoreButton_Click);
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(3, 3);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(786, 390);
            this.logBox.TabIndex = 0;
            this.logBox.Text = "";
            // 
            // ChatbotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.mainTabControl);
            this.Name = "ChatbotForm";
            this.Text = "Cybersecurity Awareness Chatbot";
            this.Load += new System.EventHandler(this.ChatbotForm_Load);
            this.mainTabControl.ResumeLayout(false);
            this.tabPageChatBot.ResumeLayout(false);
            this.tabPageChatBot.PerformLayout();
            this.tabPageQuiz.ResumeLayout(false);
            this.tabPageQuiz.PerformLayout();
            this.tabPageTasks.ResumeLayout(false);
            this.tabPageTasks.PerformLayout();
            this.tabPageActivityLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabPageChatBot;
        private System.Windows.Forms.TextBox asciiBox;
        private System.Windows.Forms.RichTextBox chatHistoryBox;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TabPage tabPageQuiz;
        private System.Windows.Forms.TabPage tabPageTasks;
        private System.Windows.Forms.TabPage tabPageActivityLog;
        private System.Windows.Forms.ListBox taskListBox;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.Button deleteTaskButton;
        private System.Windows.Forms.Button completeTaskButton;
        private System.Windows.Forms.Button addTaskButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label feedbackLabel;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.RadioButton option4Radio;
        private System.Windows.Forms.RadioButton option3Radio;
        private System.Windows.Forms.RadioButton option2Radio;
        private System.Windows.Forms.RadioButton option1Radio;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.Button showMoreButton;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Button editTaskButton;
    }
}