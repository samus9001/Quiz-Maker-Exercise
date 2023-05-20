using System;

namespace QuizMaker
{
    public class UIMethods
    {
        /// <summary>
        /// sets the UI message for inputting the question
        /// </summary>
        public static void Question()
        {
            Console.WriteLine("Enter the question");
        }

        /// <summary>
        /// sets the UI message for inputting the answers to the question
        /// </summary>
        public static void Answers()
        {
            Console.WriteLine("\nEnter the answers seperated by a comma for the question");
        }

        /// <summary>
        /// sets the UI message for inputting the correct answer to the question
        /// </summary>
        public static void CorrectAnswer()
        {
            Console.WriteLine("\nEnter the correct answer for the question");
        }

        /// <summary>
        /// stores the user input for the question
        /// </summary>
        /// <returns></returns>
        public static string QuestionInput()
        {
            string questionUserInput = Console.ReadLine();
            return questionUserInput;
        }

        /// <summary>
        /// stores the user input for the answers
        /// </summary>
        /// <returns></returns>
        public static string[] AnswersInput()
        {
            string answersUserInput = Console.ReadLine();
            string[] answersArray = answersUserInput.Split(',');
            return answersArray;
        }

        /// <summary>
        /// stores the user input for the correct answer
        /// </summary>
        /// <returns></returns>
        public static string CorrectAnswerInput()
        {
            string correctAnswerUserInput = Console.ReadLine();
            return correctAnswerUserInput;
        }
    }


}
