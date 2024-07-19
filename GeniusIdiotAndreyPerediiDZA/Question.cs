namespace GeniusIdiotAndreyPerediiDZA
{
    public class Question
    {
        public string Text { get; set; }
        public int Answer { get; set; }
        public Question(string text, int answer) 
        { 
            Answer = answer;
            Text = text;
        }
    }
}