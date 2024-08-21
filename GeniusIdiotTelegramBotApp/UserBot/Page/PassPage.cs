using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace GeniusIdiotTelegramBotApp.UserBot.Page
{
    public class PassPage: IPage
    {
        public PageResult View(Update update, UserState userState)
        {
            var text = GetText();
            var replyMarkup = GetReplyKeyBoard();
            return new PageResult(text, replyMarkup)
            {
                UpdatedUserState = new UserState(this, userState.UserData)
            };

        }

        public PageResult Handle(Update update, UserState userState)
        {
            if (update.Message == null)
                return new PageResult("Нажмите на кнопки", GetReplyKeyBoard());
            switch (update.Message.Text)
            {
                case "На главную страницу":
                    return new StartPage().View(update, userState);
                default:
                    return null;

            }
        }

        private static string GetText()
        {
            return "Этот раздел еще не готов. Перейдите на предыдущую страницу";
        }

        private static ReplyKeyboardMarkup GetReplyKeyBoard()
        {
            return new ReplyKeyboardMarkup(
                [
                    new KeyboardButton("Назад"),
                    new KeyboardButton("На главную страницу")
                ])
                { 
                    ResizeKeyboard = true
                };
        }

      
    }
}