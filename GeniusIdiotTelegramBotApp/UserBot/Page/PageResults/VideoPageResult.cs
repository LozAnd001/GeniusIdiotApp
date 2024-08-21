using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace GeniusIdiotTelegramBotApp.UserBot.Page.PageResults
{
    public class VideoPageResult : PageResultBase
    {
        public InputFile Video { get; set; }
        public VideoPageResult(InputFile video, string text, IReplyMarkup replyMarkup) : base(text, replyMarkup)
        {
            Video = video;
        }
    }

}