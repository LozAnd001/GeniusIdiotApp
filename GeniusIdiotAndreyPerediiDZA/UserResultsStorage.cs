using System.Text;

namespace GeniusIdiotAndreyPerediiDZA
{


    public class UserResultsStorage
    {
        public static List<User> GetUserResults()
        {
            
            var results = new List<User>();
            var value = FileProvider.GetValue("userResults.txt");
            var lines = value.Split('\n');
            foreach(var line in lines)
            {
               
                var values = line.Split("#");
                var name = values[0];
                var countRightAnswers = Convert.ToInt32(values[1]);
                var diagnose = values[2];
                var user = new User(name);
                user.Diagnose = diagnose;
                user.CountRightAnswers = countRightAnswers;
                results.Add(user);
            }
            return results;
        }
            

        public static void Save(User user)
        {
            var value = $"{user.Name}#{user.CountRightAnswers}#{user.Diagnose}";
            FileProvider.Append("userResults.txt", value);
        }
       

    }
    
}