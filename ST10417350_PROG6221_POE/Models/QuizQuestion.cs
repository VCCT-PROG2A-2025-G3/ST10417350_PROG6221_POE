using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10417350_PROG6221_POE.Models
{
    public class QuizQuestion
    {
        public string QuestionText { get; }
        public string[] Options { get; }
        public int CorrectOptionIndex { get; }

        public QuizQuestion(string questionText, string[] options, int correctOptionIndex)
        {
            QuestionText = questionText;
            Options = options;
            CorrectOptionIndex = correctOptionIndex;
        }

        public override string ToString()
        {
            return QuestionText;
        }
    }
}