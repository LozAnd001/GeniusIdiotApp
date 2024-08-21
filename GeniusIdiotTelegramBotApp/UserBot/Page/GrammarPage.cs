using GeniusIdiotTelegramBotApp.UserBot.Page.PageResults;
using Telegram.Bot.Types;

namespace GeniusIdiotTelegramBotApp.UserBot.Page
{
    public class GrammarPage: IPage
    {
        public PageResultBase Handle(Update update, UserState userState)
        {
            return new PassPage().View(update, userState);
        }

        public PageResultBase View(Update update, UserState userState)
        {
            return new PassPage().View(update, userState);
        }
        
    }
}