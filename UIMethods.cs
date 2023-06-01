namespace QuizMaker
{
    public class UIMethods
    {

        /// <summary>
        /// sets the UI message for what the user would like to do
        /// </summary>
        public static void Mode()
        {
            Console.WriteLine("Press the (Y) key to input a question.\n");
            Console.WriteLine("Press the (N) key to exit.\n");
        }

        /// <summary>
        /// checks the input key
        /// </summary>
        /// <returns></returns>
        public static char Input()
        {
            char userInput = Char.ToUpper(Console.ReadKey().KeyChar);
            return userInput;
        }

        /// <summary>
        /// sets the UI message for inputting the question
        /// </summary>
        /// <param name="counter"></param>
        public static void Question(int counter)
        {
            Console.WriteLine($"Input a question along with the answers and the correct answer to be used for Q{counter} in the quiz.\n\nPress the (|) key after each input. Press the (*) key after the correct answer.\n");
            Console.WriteLine("Press the (Enter) key to submit the question.\n");
        }

        /// <summary>
        /// stores the user input for the question
        /// </summary>
        /// <returns></returns>b 
        public static string QuestionInput()
        {
            string questionUserInput = Console.ReadLine();
            return questionUserInput;
        }

        public static void QuestionInvalid()
        {
            Console.WriteLine("\nInvalid input format. Please try again.\n");
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
