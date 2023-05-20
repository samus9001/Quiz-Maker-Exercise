using System.Collections.Generic;
using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Questions qna = new Questions();

            UIMethods.Question();
            qna.Question = UIMethods.QuestionInput();

            UIMethods.Answers();
            qna.Answers.AddRange(UIMethods.AnswersInput());
            //qna.Answers.ForEach(Console.WriteLine); // prints the list

            UIMethods.CorrectAnswer();
            qna.CorrectAnswer = UIMethods.CorrectAnswerInput();

            List<Questions> questionList = new List<Questions>();
            questionList.Add(qna);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Questions>));

            var path = @"C:\QuestionsList.xml";
            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, questionList);
            }

        }
    }
}