using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeniusIdiotTelegramBotApp.UserBot.Page.PageResults;
using Telegram.Bot.Types;

namespace GeniusIdiotTelegramBotApp.UserBot.Page
{
    public class NotStatedPage : IPage
    {
        public PageResultBase Handle(Update update, UserState userState)
        {
            return new StartPage().View(update, userState);
        }

        public PageResultBase View(Update update, UserState userState)
        {
            return null;
        }
    }
}
