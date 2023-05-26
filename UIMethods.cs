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
            Console.WriteLine($"Input a question along with the answers and correct answer to be used for Q{counter} in the quiz.\nPress the (|) key after each input. Press the (*) key after the correct answer.");
            Console.WriteLine("Press the (Enter) key to submit the question.");
            Console.WriteLine("Press the (Esc) key to quit.\n");
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

        public static void QuestionInvalid()
        {
            Console.WriteLine("Invalid input format. Please try again following the listed format above.");
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
