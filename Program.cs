using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QuizInformation qna = new QuizInformation();
            char userInput;
            bool validInput = true;
            string answer;
            Random random = new Random();
            int scoreCount = 0;

            XmlSerializer serializer = new XmlSerializer(typeof(List<QuizInformation>));
            var path = @"C:\QuestionsList.xml";
            List<QuizInformation> qnaList = new List<QuizInformation>();

            using (FileStream file = File.OpenRead(path))
            {
                if (File.Exists(path) && new FileInfo(path).Length > 0)
                {
                    qnaList = serializer.Deserialize(file) as List<QuizInformation>;
                }
            }

            while (true) // loops until the 'N' key is pressed on the Mode prompt
            {
                UIMethods.DisplayMode();

                userInput = UIMethods.InputKey();

                if (userInput == 'Y')
                {
                    UIMethods.DisplayQuestionInformation();

                    while (true) // loops until the validInput variable is true
                    {
                        if (!validInput)
                        {
                            UIMethods.DisplayInvalidQuestion();
                        }

                        qna.Question = UIMethods.InputQuestion();
                        validInput = LogicMethods.QuestionSplit(qna);

                        if (validInput)
                        {
                            break;
                        }
                    }

                    qnaList.Add(qna);

                    using (FileStream file = File.Create(path))
                    {
                        serializer.Serialize(file, qnaList);
                    }
                }

                if (userInput == 'Q' && qnaList.Count > 0)
                {
                    while (qnaList.Count > 0)
                    {
                        // select a random question from the list
                        int index = random.Next(0, qnaList.Count);
                        QuizInformation randomQuestion = qnaList[index];

                        UIMethods.DisplayQuestion(randomQuestion);
                        UIMethods.DisplayAnswers(randomQuestion);
                        answer = UIMethods.InputAnswer();

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

                if (userInput == 'N')
                {
                    return;
                }
            }
        }
    }
}