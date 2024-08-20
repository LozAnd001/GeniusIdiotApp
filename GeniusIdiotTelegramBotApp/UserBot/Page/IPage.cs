using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace GeniusIdiotTelegramBotApp.UserBot.Page
{
    public interface IPage
    {
        PageResult View(Update update, UserState userState);

        PageResult Handle(Update update, UserState userState);
        
    }
}
