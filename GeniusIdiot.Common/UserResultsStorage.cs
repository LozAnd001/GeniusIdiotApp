using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace GeniusIdiot.Common
{
    public class UserResultsStorage
    {
        private static string fileName = "userResults.json";

        public static List<User> GetUserResults()
        {
            if (FileProvider.Exists(fileName)) 
            {
                return new List<User>();
            }
            var fileData = FileProvider.GetValue(fileName);
            var userResults = JsonConvert.DeserializeObject<List<User>>(fileData);
            return userResults;
        }

        public static void Append(User user)
        {
            var userResults = GetUserResults();
            userResults.Add(user);
            Save(userResults);
        }
        static void Save(List<User> userResults)
        {
            var jsonData = JsonConvert.SerializeObject(userResults, Formatting.Indented);
            FileProvider.Replace(fileName, jsonData);
        }

    }
}