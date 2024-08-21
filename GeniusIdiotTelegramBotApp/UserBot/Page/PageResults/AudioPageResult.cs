using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace GeniusIdiotTelegramBotApp.UserBot.Page.PageResults
{
    public class AudioPageResult : PageResultBase
    {
        public InputFile Audio { get; set; }
        public AudioPageResult(InputFile audio, string text, IReplyMarkup replyMarkup) : base(text, replyMarkup)
        {
            Audio = audio;
        }
    }


}