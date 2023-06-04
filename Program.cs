using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Questions>));
            var path = @"C:\QuestionsList.xml";
            List<Questions> qnaList = new List<Questions>();

            using (FileStream file = File.OpenRead(path))
            {
                if (File.Exists(path) && new FileInfo(path).Length > 0)
                {
                    qnaList = serializer.Deserialize(file) as List<Questions>;
                }
            }

            while (true) // loops until any key except 'Y' is pressed on the Mode prompt
            {
                UIMethods.ClearScreen();
                UIMethods.Mode();

                Questions qna = new Questions();
                char userInput = UIMethods.Input();
                bool validInput = true;
                int scoreCount = 0;

                if (userInput == 'Y')
                {
                    UIMethods.ClearScreen();
                    UIMethods.Question();

                    while (true) // loops until the validInput variable is true
                    {
                        if (!validInput)
                        {
                            UIMethods.InvalidQuestion();
                        }

                        qna.Question = UIMethods.InputQuestion();
                        validInput = LogicMethods.QuestionSplit(qna);

                        if (validInput)
                        {
                            break;
                        }
                    }
                }
                if (userInput == 'Q')
                {
                    UIMethods.ClearScreen();

                    if (qnaList.Count > 0)
                    {
                        // select a random question from the list
                        Random random = new Random();
                        int index = random.Next(0, qnaList.Count);
                        Questions randomQuestion = qnaList[index];

                        UIMethods.DisplayQuestion(randomQuestion);
                        UIMethods.DisplayAnswers(randomQuestion);
                        UIMethods.InputAnswer();

                        if (UIMethods.InputAnswer() == randomQuestion.CorrectAnswer)  //TODO: this is never triggered as the input is a number
                        {
                            UIMethods.CorrectAnswer();
                            scoreCount++;
                        }
                        else
                        {
                            UIMethods.IncorrectAnswer(randomQuestion);
                        }

                        // remove the answered question from the qnaList
                        qnaList.RemoveAt(index);

                        UIMethods.PressAnyKey();

                        // Check if all questions have been answered
                        if (qnaList.Count == 0)
                        {
                            UIMethods.DisplayScore(scoreCount);
                            UIMethods.PressAnyKey();
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No questions available. Please add questions before starting the quiz."); //TODO: replace this with an if statement that prevents quiz starting if qnaList.Count is 0
                        UIMethods.PressAnyKey();
                        break;
                    }
                }
                if (userInput == 'N')
                {
                    return;
                }

                qnaList.Add(qna);

                using (FileStream file = File.Create(path))
                {
                    serializer.Serialize(file, qnaList);
                }
            }
        }
    }
}