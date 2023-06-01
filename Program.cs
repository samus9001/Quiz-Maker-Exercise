using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = 0; // used for UI question information
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

                counter++;

                if (userInput == 'Y')
                {
                    UIMethods.ClearScreen();
                    UIMethods.Question(counter);
                }
                else if (userInput != 'Y')
                {
                    return;
                }

                while (true) // loops until the validInput variable is true
                {
                    if (!validInput)
                    {
                        UIMethods.QuestionInvalid();
                    }

                    qna.Question = UIMethods.QuestionInput();
                    validInput = LogicMethods.QuestionSplit(qna, counter);

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
        }
    }
}