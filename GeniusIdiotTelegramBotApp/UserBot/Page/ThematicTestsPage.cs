using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace GeniusIdiotTelegramBotApp.UserBot.Page
{
    public class ThematicTestsPage : IPage
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
                case "Тест на определения уровня английского языка":
                    return new PassPage().View(update, userState);
                case "Оксфордский тест":
                    return new PassPage().View(update, userState);
                case "IELTS тест":
                    return new PassPage().View(update, userState);
                case "Тест для самых маленьких":
                    return new PassPage().View(update, userState);
                case "Тест “Гений-Идиот”":
                    return new GeniusIdiotPage().View(update, userState);
                case "Назад":
                    return new StartPage().View(update, userState);
                default:
                    return null;

            }
        }

        private static string GetText()
        {
            return "Выберите тест, который хотите пройти";
        }

        private ReplyKeyboardMarkup GetReplyKeyBoard()
        {
            return new ReplyKeyboardMarkup(
                   [
                       [
                        new KeyboardButton("Тест на определения уровня английского языка")
                    ],
                    [
                        new KeyboardButton("Оксфордский тест")
                    ],
                    [
                        new KeyboardButton("IELTS тест")
                    ],
                    [
                        new KeyboardButton("Тест для самых маленьких")
                    ],
                    [
                        new KeyboardButton("Тест “Гений-Идиот”")
                    ],
                    [
                        new KeyboardButton("Назад")
                    ]
                   ])
            {
                ResizeKeyboard = true
            };
        }
    }
    
}