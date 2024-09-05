using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace GeniusIdiot.Common
{
    public interface IConvert
    {
        string Serialize<T>(T item);
        T Deserialize<T>(string data);

    }

    public class JsonConverter : IConvert
    {
        public string Serialize<T>(T item)
        {
            return JsonConvert.SerializeObject(item);
        }

        public T Deserialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        } 
    }

    public class XMLConverter : IConvert
    {
        public string Serialize<T>(T item)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var textWriter =  new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, item);
                return textWriter.ToString();
            }
        }

        public T Deserialize<T>(string data)
        {
            throw new NotImplementedException();
        }
    }

    public static class QuestionStorage
    {
        private static string fileName = "questions.json";
        private static IConvert converter = new JsonConverter();
        public static List<Question> GetAll()
        {

            var questions = new List<Question>();
            if (FileProvider.Exists(fileName))
            {
                var value = FileProvider.GetValue(fileName);
                questions = converter.Deserialize<List<Question>>(value);
            }
            else
            {
                questions.Add(new Question("Сколько будет два плюс два умноженное на два?", 6));
                questions.Add(new Question("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?", 9));
                questions.Add(new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25));
                questions.Add(new Question("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?", 60));
                questions.Add(new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2));
                SaveQuestions(questions);
            }
            return questions;
        }

        private static void SaveQuestions(List<Question> questions)
        {
            var jsonData = converter.Serialize(questions);
            FileProvider.Replace(fileName, jsonData);
        }

        public static void Add(Question newQuestion)
        {
            var questions = GetAll();
            questions.Add(newQuestion);
            SaveQuestions(questions);
        }

        public static void Remove(Question removeQuestion)
        {
            var questions = GetAll();
            for(int i = 0; i < questions.Count;++i)
            {
                if (questions[i].Text == removeQuestion.Text)
                {
                    questions.RemoveAt(i);
                    break;
                }
            }
            FileProvider.Clear(fileName);
            SaveQuestions(questions);
        }
    } 
}