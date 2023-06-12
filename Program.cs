using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char userInput;
            Random random = new Random();
            List<QuizInformation> qnaList = new List<QuizInformation>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuizInformation>));

            LogicMethods.Deserialize();

            bool exit = false;

            while (!exit)
            {
                UIMethods.DisplayMode();

                userInput = UIMethods.InputKey();
                bool validInput;

                //exits the program
                if (userInput == 'N')
                {
                    exit = true;
                }

                //input questions for the quiz
                if (userInput == 'Y')
                {
                    QuizInformation qna = new QuizInformation();

                    UIMethods.DisplayQuestionInformation();

                    do
                    {
                        qna.Question = UIMethods.InputQuestion();
                        validInput = LogicMethods.SplitQuestion(qna);

                        if (!validInput)
                        {
                            UIMethods.DisplayInvalidQuestion();
                        }
                    }
                    while (!validInput);

                    if (validInput)
                    {
                        qnaList.Add(qna);
                    }

                    LogicMethods.Serialize(qnaList);
                }

                // starts the quiz
                if (userInput == 'Q' && qnaList.Count > 0)
                {
                    int scoreCount = 0;

                    while (qnaList.Count > 0)
                    {
                        // select a random question from the list
                        int index = random.Next(0, qnaList.Count);
                        QuizInformation randomQuestion = qnaList[index];

                        UIMethods.DisplayQuestion(randomQuestion);
                        UIMethods.DisplayAnswers(randomQuestion);
                        string answer = UIMethods.InputAnswer();

                        if (answer == randomQuestion.CorrectAnswer)
                        {
                            UIMethods.DisplayCorrectAnswer();
                            scoreCount++;
                        }
                        else
                        {
                            UIMethods.DisplayIncorrectAnswer(randomQuestion);
                        }

                        // remove the answered question from the qnaList
                        qnaList.RemoveAt(index);

                        UIMethods.InputPressEnterKey();

                        // Check if all questions have been answered
                        if (qnaList.Count == 0)
                        {
                            UIMethods.DisplayScore(scoreCount);
                            UIMethods.InputPressEnterKey();
                            break;
                        }
                    }
                }
                else if (userInput == 'Q' && qnaList.Count == 0)
                {
                    UIMethods.DisplayNoQuestionsAvailable();
                    UIMethods.InputPressEnterKey();
                }
            }

            UIMethods.DisplayExit();
            UIMethods.InputPressEnterKey();
        }
    }
}