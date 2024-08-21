using Telegram.Bot.Types;

namespace GeniusIdiotTelegramBotApp.UserBot.Page
{
    public class GrammarPage: IPage
    {
        public PageResult Handle(Update update, UserState userState)
        {
            return new PassPage().View(update, userState);
        }

        public PageResult View(Update update, UserState userState)
        {
            return new PassPage().View(update, userState);
        }
        
    }
}