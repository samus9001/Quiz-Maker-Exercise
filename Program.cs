using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Questions qna = new Questions();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Questions>));

            var path = @"C:\QuestionsList.xml";
            List<Questions> qnaList = new List<Questions>();

            using (FileStream file = File.OpenRead(path))
            {
                qnaList = serializer.Deserialize(file) as List<Questions>;
            }

            UIMethods.Question();
            qna.Question = UIMethods.QuestionInput();

            UIMethods.Answers();
            qna.Answers.AddRange(UIMethods.AnswersInput());
            //qna.Answers.ForEach(Console.WriteLine); // prints the list

            UIMethods.CorrectAnswer();
            qna.CorrectAnswer = UIMethods.CorrectAnswerInput();

            qnaList.Add(qna);

            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, qnaList);
            }
        }
    }
}