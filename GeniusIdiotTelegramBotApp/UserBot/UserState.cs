using GeniusIdiotTelegramBotApp.UserBot.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusIdiotTelegramBotApp.UserBot
{
    public record class UserState(IPage Page, UserData UserData)
    {
    }
}
