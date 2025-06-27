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
    /// Represents a quiz question with multiple answer options and the index of the correct option.
    /// </summary>
    public class QuizQuestion
    {
        /// <summary>
        /// The text of the quiz question.
        /// </summary>
        public string QuestionText { get; }

        /// <summary>
        /// Array of answer options for the question.
        /// </summary>
        public string[] Options { get; }

        /// <summary>
        /// The zero-based index of the correct option in the Options array.
        /// </summary>
        public int CorrectOptionIndex { get; }

        /// <summary>
        /// Constructs a new QuizQuestion with specified text, options, and correct answer index.
        /// </summary>
        /// <param name="questionText">The text of the question.</param>
        /// <param name="options">An array of possible answer options.</param>
        /// <param name="correctOptionIndex">The index of the correct answer in the options array.</param>
        public QuizQuestion(string questionText, string[] options, int correctOptionIndex)
        {
            QuestionText = questionText;
            Options = options;
            CorrectOptionIndex = correctOptionIndex;
        }

        /// <summary>
        /// Returns the question text as the string representation of the object.
        /// </summary>
        /// <returns>The question text.</returns>
        public override string ToString()
        {
            return QuestionText;
        }
    }
}
//=========================== END OF FILE ===========================//