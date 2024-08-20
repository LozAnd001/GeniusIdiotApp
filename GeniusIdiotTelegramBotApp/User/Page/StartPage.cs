using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace GeniusIdiotTelegramBotApp.User.Page
{
    public class StartPage: IPage
    {
        public PageResult View(Update update, UserState userState)
        {
            var text = @"Привет! 👋 Я твой персональный бот-тестировщик по английскому языку! 🚀

Хочешь проверить свои знания? Мы можем работать над грамматикой, словарным запасом, произношением и многим другим. Просто выбери, с чем именно ты хочешь поработать, и я с радостью помогу! Давай сделаем обучение интересным и продуктивным! 🌟";
            var replyMarkup = new ReplyKeyboardMarkup(
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
            return new PageResult(text, replyMarkup)
            {
                UpdatedUserState = new UserState(this, userState.UserData)
            };

        }
    }
}
