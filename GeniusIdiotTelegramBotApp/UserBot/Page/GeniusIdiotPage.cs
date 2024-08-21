using GeniusIdiotTelegramBotApp.UserBot.Page.PageResults;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace GeniusIdiotTelegramBotApp.UserBot.Page
{
    public class GeniusIdiotPage:IPage
    {
        private GameGeniusIdiot game = null;
        public PageResultBase View(Update update, UserState userState)
        {
            if(game == null)
                game = new GameGeniusIdiot(new UserData(update.Message.From.FirstName));
            var text = GetText();
            var replyMarkup = GetReplyKeyBoard();
            return new PageResultBase(text, replyMarkup)
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
                case "Вернуться на главную страницу":
                    return new StartPage().View(update, userState);
                default:
                    var userAnswer = int.Parse(update.Message.Text);
                    game.AcceptAnswer(userAnswer);
                    return View(update, userState);
            }
        }

        private string GetText() 
        {
            if(game.End())
            {
                return game.CalculateDiagnose();
            }
            else
            {
                var currentQuestion = game.GetNextQuestion();
                var currentNumberQuestion = game.GetQuestionNumberText();
                return $"{currentNumberQuestion} {currentQuestion.Text}";
            }
        }

        private ReplyKeyboardMarkup GetReplyKeyBoard()
        {
            if (game.End()) return new ReplyKeyboardMarkup(new KeyboardButton("Вернуться на главную страницу"));
            else return null;
        }
    }
}