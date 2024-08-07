using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

class Program
{
    static async Task Main(string[] args)
    {
        var telegramBotClient = new TelegramBotClient("7325936984:AAHkxwlIXZ9v6qJP0CbRgF4KNRp2CBYRubg");
        var user = await telegramBotClient.GetMeAsync();
        Console.WriteLine($"Начали слушать апдейты с {user.Username}");
        telegramBotClient.StartReceiving(updateHandler: HandleUpdate, pollingErrorHandler: HandlePoolingError);
        Console.ReadLine();
    }

    private static async Task HandleUpdate(ITelegramBotClient client, Update update, CancellationToken token)
    {
        if(update.Message?.Text != null)
        {
            var charId = update.Message.Chat.Id;
            var text = update.Message.Text;
            var messageId = update.Message.MessageId;
            await client.SendTextMessageAsync(chatId: charId, $"Вы прислали: \n {text}");
            await client.SendTextMessageAsync(chatId: charId, 
                text:$"Вы прислали: \n {text}",
                replyToMessageId:messageId);
            await client.SendTextMessageAsync(chatId: charId,
                replyMarkup: new ReplyKeyboardMarkup(new KeyboardButton("Кнопка 1")),
                text: $"Вы прислали: \n {text}"
                );
        }
    }
    private static async Task HandlePoolingError(ITelegramBotClient client, Exception exception, CancellationToken token)
    {

        Console.WriteLine(exception.Message);
    }
}