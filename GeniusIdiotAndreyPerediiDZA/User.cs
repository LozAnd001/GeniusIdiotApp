namespace GeniusIdiotAndreyPerediiDZA
{
    partial class Program
    {
        public class User
        {
            public string Name;
            public int CountRightAnswers;
            public string Diagnose;
            public User(string name) 
            {
                Name = name;
                Diagnose = "Неизвестно";
                CountRightAnswers = 0;
            }
            public void AcceptRightAnswer()
            {
                CountRightAnswers++;
            }
        }
    }
}