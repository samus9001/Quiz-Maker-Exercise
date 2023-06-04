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
            Console.WriteLine("Press the (Q) key to start the quiz.\n");
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
        public static void Question()
        {
            Console.WriteLine($"Input a question along with the answers and the correct answer.\n\nPress the (|) key after each input. Press the (*) key after the correct answer.\n");
            Console.WriteLine("Press the (Enter) key to submit the question.\n");
        }

        /// <summary>
        /// stores the user input for the question
        /// </summary>
        /// <returns></returns>b 
        public static string InputQuestion()
        {
            string questionUserInput = Console.ReadLine();
            return questionUserInput;
        }

        public static void InvalidQuestion()
        {
            Console.WriteLine("\nInvalid input format. Please try again.\n");
        }

        /// <summary>
        /// sets the UI message to display the question to the user
        /// </summary>
        /// <param name="randomQuestion"></param>
        public static void DisplayQuestion(Questions randomQuestion)
        {
            Console.WriteLine(randomQuestion.Question);
        }

        /// <summary>
        /// sets the UI message to display the available answers
        /// </summary>
        public static void DisplayAnswers(Questions randomQuestion)
        {
            for (int i = 0; i < randomQuestion.Answers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {randomQuestion.Answers[i]}");
            }
        }

        /// <summary>
        /// sets the UI message to prompt the user to input their answer
        /// </summary>
        public static string InputAnswer()
        {
            Console.WriteLine("\nInput your answer (number):");
            string userAnswer = Console.ReadKey().ToString();
            return userAnswer;
        }

        /// <summary>
        /// sets the UI message to display that the answer is correct
        /// </summary>
        /// <param name="userAnswer"></param>
        /// <param name="randomQuestion"></param>
        /// <param name="scoreCount"></param>
        public static void CorrectAnswer()
        {
            Console.WriteLine("\nThat is the correct answer!");
        }

        /// <summary>
        /// sets the UI message to display that the answer is incorrect
        /// </summary>
        /// <param name="randomQuestion"></param>
        public static void IncorrectAnswer(Questions randomQuestion)
        {
            Console.WriteLine($"\nThat is incorrect! The correct answer is {randomQuestion.CorrectAnswer}");
        }

        /// <summary>
        /// sets the UI message to prompt the user to input any key
        /// </summary>
        public static void PressAnyKey()
        {
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }

        /// <summary>
        /// sets the UI message to display the score once all questions have been answered
        /// </summary>
        /// <param name="scoreCount"></param>
        public static void DisplayScore(int scoreCount)
        {
            Console.WriteLine("All questions have been answered.");
            Console.WriteLine($"Your final score is {scoreCount}!");
            Console.WriteLine("You can add more questions to the quiz or play again on the menu.");
        }

        /// <summary>
        /// clears the screen after the user input
        /// </summary>
        public static void ClearScreen()
        {
            Console.Clear();
        }
    }
}
