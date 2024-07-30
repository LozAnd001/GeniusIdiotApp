using System;
using System.Collections.Generic;


namespace GeniusIdiot.Common
{
    public class UserResultsStorage
    {
        private static string fileName = "userResults.txt";

        public static List<User> GetUserResults()
        {
            
            var results = new List<User>();
            var value = FileProvider.GetValue(fileName);
            var lines = value.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                var values = line.Split('#');
                var name = values[0];
                var countRightAnswers = Convert.ToInt32(values[1]);
                var diagnose = values[2];
                var user = new User(name)
                {
                    Diagnose = diagnose,
                    CountRightAnswers = countRightAnswers
                };
                results.Add(user);
            }
            return results;
        }

        public static void Save(User user)
        {
            var value = $"{user.Name}#{user.CountRightAnswers}#{user.Diagnose}";
            FileProvider.Append(fileName, value);
        }
    }
}