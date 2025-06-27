Cybersecurity Awareness Chatbot – PROG6221 POE Part 3
-----------------------------------------------------

ST10417350_PROG6221_POE
Student Name: Connor Manuel
Student Number: ST10417350
Module: PROG6221 – Programming 2A

Description:
------------
This project is the final implementation of the Cybersecurity Awareness Chatbot as part of The IIE's 
PROG6221 Programming 2A Portfolio of Evidence (PoE), Part 3.

The application has been developed using Windows Forms in .NET Framework and builds upon Parts 1 and 2 
by adding a full graphical user interface with multiple tabs, including:

- Chatbot interaction with sentiment detection and keyword recognition
- Educational quiz system with real-time feedback
- Task management with optional reminders
- Activity logging of all interactions
- Voice greeting on startup
- ASCII art banner display
- Integration with GitHub for CI via Actions

Key Features:
-------------
1. Chatbot Tab:
   - Users can type questions or statements about cybersecurity topics such as:
     * Password safety
     * Phishing
     * Scams & fraud
     * Privacy settings
     * Two-factor authentication (2FA)
   - The chatbot recognises sentiment and responds accordingly.
   - It also provides random tips or fun facts when users type "tip" or "fact".
   - A voice greeting plays when the app starts, and an ASCII banner appears in the chat history.

2. Quiz Tab:
   - Interactive quiz with 20+ pre-defined cybersecurity questions
   - Randomly selects 10 questions per session (mix of True/False and Multiple Choice)
   - Provides instant feedback after each question
   - Displays final score and allows restarting the quiz

3. Tasks Tab:
   - Add tasks with title, description, and optional reminder time
   - Mark tasks as complete
   - Edit or delete existing tasks
   - View incomplete and completed tasks separately

4. Activity Log Tab:
   - Logs every interaction with the chatbot
   - Tracks task creation/completion and quiz attempts
   - Shows last 10 entries by default with a "Show More" option

Folder Structure:
-----------------
- Models/               : Contains data models like TaskItem.cs, QuizQuestion.cs
- Utils/                : Includes helper logic: ChatLogic.cs, SentimentHelper.cs, NLPHelper.cs
- Properties/            : Holds application properties and icon
- Assets/               : Stores the WAV greeting file (AI_Greeting_For_Project.wav)
- .github/workflows/    : Contains the GitHub Actions CI workflow file (ci.yml)
- ChatbotForm.cs        : Main GUI logic and tab handling
- Program.cs            : Entry point of the application
- README.txt            : This file

Getting Started:
----------------
Prerequisites:
- Visual Studio 2022 or newer
- .NET Framework 4.7.2+
- Ensure the 'Assets' folder exists and contains the audio file: AI_Greeting_For_Project.wav

GitHub Integration:
-------------------
- Repository is public and accessible
- GitHub Actions CI workflow added and passing

Video Presentation:
--------------------
[https://youtu.be/5DFpB1QNoIA]

The video includes:
- Code walkthrough focusing on Part 3 implementation
- Live demo showing all features working together
- Explanation of how the chatbot recognises phrases and provides intelligent replies
- Duration: Less than 10 minutes

Technologies Used:
------------------
- C#
- .NET Framework
- Windows Forms GUI
- GitHub Actions for CI
- SoundPlayer for audio greeting
- RichTextBox for chat history and ASCII display
- Timer for reminders
- StringBuilder for dynamic responses
- Random for varied replies and quizzes

How to Use:
-----------
Chatbot Tab:
Type any question related to cybersecurity. The chatbot will respond based on:
- Detected sentiment 
- Recognised keywords 
- Manual requests 

Quiz Tab:
Click "Start Quiz" to begin. You'll be shown 10 randomly selected questions from a pool of 20+. 
You get immediate feedback after each question and a final score at the end.

Tasks Tab:
Add new tasks with titles, descriptions, and optional reminders. You can:
- Mark them as complete
- Edit or delete existing ones

Activity Log Tab:
View logs of:
- Chatbot interactions
- Task additions and completions
- Quiz attempts
Use the "Show More" button to load additional logs.
