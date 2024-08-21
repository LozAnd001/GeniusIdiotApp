using Telegram.Bot.Types.ReplyMarkups;

namespace GeniusIdiotTelegramBotApp.UserBot.Page.PageResults
{
    public class PageResultBase
    {
        public string Text;

        public IReplyMarkup ReplyMarkup { get; set; }

        public UserState UpdatedUserState { get; set; }

        public PageResultBase(string text, IReplyMarkup replyMarkup)
        {
            Text = text;
            ReplyMarkup = replyMarkup;
        }
    }

}