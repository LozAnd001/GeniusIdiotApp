﻿using GeniusIdiotTelegramBotApp.Storage;
using GeniusIdiotTelegramBotApp.UserBot;
using GeniusIdiotTelegramBotApp.UserBot.Page;
using GeniusIdiotTelegramBotApp.UserBot.Page.PageResults;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

class Program
{
    static UserStateStorage storage = new UserStateStorage();

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
        if(update.Message?.Text == null)
        {
            return;
        }
        var telegramUserId = update.Message.From.Id;
        //Console.WriteLine($"update_id = {update.Id}, telemUserId = {telegramUserId}");
        var isExistUserState = storage.TryGet(telegramUserId, out var userState);
        if(!isExistUserState)
        {
            userState = new UserState(new NotStatedPage(), new UserData(update.Message.From.FirstName));
        }
        //Console.WriteLine($"update_id = {update.Id}, userState = {userState}");
        var result = userState!.Page.Handle(update, userState);
        //Console.WriteLine($"update_id = {update.Id}, text = {result.Text}, UpdatedUserState = {result.UpdatedUserState}");
        switch(result)
        {
            case PhotoPageResult photoPageResult:
                await client.SendPhotoAsync(
                    chatId: telegramUserId,
                    photo: photoPageResult.Photo,
                    caption: photoPageResult.Text,
                    replyMarkup: photoPageResult.ReplyMarkup);
                break;
            case VideoPageResult photoPageResult:
                await client.SendVideoAsync(
                    chatId: telegramUserId,
                    video: photoPageResult.Video,
                    caption: photoPageResult.Text,
                    replyMarkup: photoPageResult.ReplyMarkup);
                break;
            case AudioPageResult photoPageResult:
                await client.SendAudioAsync(
                    chatId: telegramUserId,
                    audio: photoPageResult.Audio,
                    caption: photoPageResult.Text,
                    replyMarkup: photoPageResult.ReplyMarkup);
                break;
            default:
                await client.SendTextMessageAsync(
                    chatId: telegramUserId,
                    text: result.Text,
                    replyMarkup: result.ReplyMarkup);
                break;
        }
        storage.AddOrUpdate(telegramUserId, result.UpdatedUserState);
    }

    

    private static async Task HandlePoolingError(ITelegramBotClient client, Exception exception, CancellationToken token)
    {

        Console.WriteLine(exception.Message);
    }
}