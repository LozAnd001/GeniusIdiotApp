using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeniusIdiotTelegramBotApp.UserBot.Page.PageResults;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using static System.Net.Mime.MediaTypeNames;

namespace GeniusIdiotTelegramBotApp.UserBot.Page
{
    public class StartPage: IPage
    {
        

        public PageResultBase View(Update update, UserState userState)
        {
            var text = GetText();
            var replyMarkup = GetReplyKeyBoard();
            var photoUrl = "https://disk.yandex.ru/i/4dW-iFD-SbUODw";
            return new PhotoPageResult(InputFile.FromUri(photoUrl), text, replyMarkup)
            {
                UpdatedUserState = new UserState(this, userState.UserData)
            };

        }

        public PageResultBase Handle(Update update, UserState userState)
        {
            if (update.Message == null)
                return new PageResultBase("Нажмите на кнопки", GetReplyKeyBoard());
            switch(update.Message.Text)
            {
                case "Тематические тесты":
                    return new ThematicTestsPage().View(update, userState);
                case "Грамматика":
                    return new PassPage().View(update, userState);
                case "Лексика":
                    return new PassPage().View(update, userState);
                case "Говорение":
                    return new PassPage().View(update, userState);
                case "Аудирование":
                    return new PassPage().View(update, userState);
                case "Письмо":
                    return new PassPage().View(update, userState);
                case "Посмотреть предыдущие результаты":
                    return new PassPage().View(update, userState);
                case "Выбрать язык бота":
                    return new PassPage().View(update, userState);
                default:
                    return null;

            }
            
        }
        private static string GetText()
        {
            return @"Привет! 👋 Я твой персональный бот-тестировщик по английскому языку! 🚀

Хочешь проверить свои знания? Мы можем работать над грамматикой, словарным запасом, произношением и многим другим. Просто выбери, с чем именно ты хочешь поработать, и я с радостью помогу! Давай сделаем обучение интересным и продуктивным! 🌟";
        }

        private static IReplyMarkup GetReplyKeyBoard()
            {
                return new ReplyKeyboardMarkup(
                    [
                        [
                        new KeyboardButton("Тематические тесты")
                    ],
                    [
                        new KeyboardButton("Грамматика")
                    ],
                    [
                        new KeyboardButton("Лексика")
                    ],
                    [
                        new KeyboardButton("Говорение")
                    ],
                    [
                        new KeyboardButton("Аудирование")
                    ],
                    [
                        new KeyboardButton("Письмо")
                    ],
                    [
                        new KeyboardButton("Посмотреть предыдущие результаты")
                    ],
                    [
                        new KeyboardButton("Выбрать язык бота")
                    ]
                    ])
                {
                    ResizeKeyboard = true
                };
            }

        
    }
}
