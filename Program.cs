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

            while (true) // loops until the Escape key is pressed on the question input
            {
                counter++;

                Questions qna = new Questions();

                UIMethods.Question(counter);

                ConsoleKeyInfo cki = Console.ReadKey(true);

                if (cki.Key == ConsoleKey.Escape)
                {
                    return;
                }

                qna.Question = UIMethods.QuestionInput();

                LogicMethods.QuestionSplit(qna, counter);

                //UIMethods.ClearScreen();

                qnaList.Add(qna);

                using (FileStream file = File.Create(path))
                {
                    serializer.Serialize(file, qnaList);
                }
            }
        }
    }
}