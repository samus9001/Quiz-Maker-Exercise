using System.Diagnostics;

namespace QuizMaker
{
    public class UIMethods
    {
        /// <summary>
        /// sets the UI message for inputting the question
        /// </summary>
        /// <param name="counter"></param>
        public static void Question(int counter)
        {
            Console.WriteLine($"Input a question to be used for Q{counter} in the quiz. Press the (Enter) key to submit.");
            Console.WriteLine("Press the Escape (Esc) key to quit\n");
        }

        /// <summary>
        /// sets the UI message for inputting the answers to the question
        /// </summary>
        /// <param name="counter"></param>
        public static void Answers(int counter)
        {
            Console.WriteLine($"\n\nInput the answers seperated by the (,) key to be used for Q{counter} in the quiz. Press the (Enter) key to submit.\n");
        }

        /// <summary>
        /// sets the UI message for inputting the correct answer to the question
        /// </summary>
        /// <param name="counter"></param>
        public static void CorrectAnswer(int counter)
        {
            Console.WriteLine($"\n\nInput the correct answer to be used for Q{counter} in the quiz. Press the (Enter) key to submit.\n");
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

        /// <summary>
        /// clears the screen after the user has input the correct answer for a question
        /// </summary>
        public static void ClearScreen()
        {
            Console.Clear();
        }
    }
}
