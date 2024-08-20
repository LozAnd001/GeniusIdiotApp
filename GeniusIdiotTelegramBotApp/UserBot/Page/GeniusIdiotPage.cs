using Telegram.Bot.Types;

namespace GeniusIdiotTelegramBotApp.UserBot.Page
{
    public class GeniusIdiotPage:IPage
    {
        private GameGeniusIdiot game = null;
        public PageResult View(Update update, UserState userState)
        {
            if(game == null)
                game = new GameGeniusIdiot(new UserData(update.Message.From.FirstName));  
        }

        public PageResult Handle(Update update, UserState userState)
        {
            throw new NotImplementedException();
        }

        
    }
}