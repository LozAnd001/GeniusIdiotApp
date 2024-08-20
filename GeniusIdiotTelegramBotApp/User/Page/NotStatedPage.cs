using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace GeniusIdiotTelegramBotApp.User.Page
{
    public class NotStatedPage : IPage
    {
        public PageResult View(Update update, UserState userState)
        {
            return new StartPage().View(update, userState);
        }
    }
}
