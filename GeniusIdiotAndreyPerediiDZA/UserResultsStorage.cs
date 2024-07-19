using System.Text;

namespace GeniusIdiotAndreyPerediiDZA
{
    partial class Program
    {
        public class UserResultsStorage
        {
            public static List<User> GetUserResults()
            {
                var reader = new StreamReader("userResults.txt", Encoding.UTF8);
                var results = new List<User>();
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split("#");
                    var name = values[0];
                    var countRightAnswers = Convert.ToInt32(values[1]);
                    var diagnose = values[2];
                    var user = new User(name);
                    user.Diagnose = diagnose;
                    user.CountRightAnswers = countRightAnswers;
                    results.Add(user);
                }
                reader.Close();
                return results;
            }
            

            public static void Save(User user)
            {
                var value = $"{user.Name}#{user.CountRightAnswers}#{user.Diagnose}";
                AppendToFile("userResults.txt", value);
            }
            public static void AppendToFile(string fileName, string value)
            {
                var writer = new StreamWriter(fileName, true, Encoding.UTF8);
                writer.WriteLine(value);
                writer.Close();

            }

        }
    }
}