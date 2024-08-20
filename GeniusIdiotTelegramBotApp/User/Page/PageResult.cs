using Telegram.Bot.Types.ReplyMarkups;

namespace GeniusIdiotTelegramBotApp.User.Page
{
    public class PageResult
    {
        public string Text;

        public ReplyMarkupBase ReplyMarkup { get; set; }

        public UserState UpdatedUserState { get; set; }

        public PageResult(string text, ReplyMarkupBase replyMarkup) 
        {
            Text = text;    
            ReplyMarkup = replyMarkup;
        }
    }

}