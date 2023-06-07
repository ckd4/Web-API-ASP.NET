using Domain.TelegramEventArgs;
using System.Reflection;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ClientTelegramBot
{
    internal static class UpdateEvents
    {
        public static async Task OnStartMessageEvent(object sender, TelegramUpdateEventArgs e)
        {
            if (new string[] { "/start" }.Contains(e.Update.Message!.Text!.ToLower()))
            {
                Console.WriteLine($"[INFO] Triggered 'OnStartMessageEvent' message from chat {e.Update.Message.Chat.Id}");

                ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
                {
                    new KeyboardButton[] { "Привет", "Картинка" },
                    new KeyboardButton[] { "Видео", "Стикер" },
                    new KeyboardButton[] { "Кнопки" },
                });

                Message sentMessage = await e.Client.SendTextMessageAsync(
                    chatId: e.Update.Message.Chat.Id,
                    text: "Здравствуй, " + e.Update.Message.Chat.Username,
                    replyMarkup: replyKeyboardMarkup,
                    cancellationToken: e.CancellationToken);
            }
        }
        public static async Task OnHelloMessageEvent(object sender, TelegramUpdateEventArgs e)
        {
            if (new string[] { "привет", "здравствуй" }.Contains(e.Update.Message!.Text!.ToLower()))
            {
                Console.WriteLine($"[INFO] Triggered 'OnHelloMessageEvent' message from chat {e.Update.Message.Chat.Id}");

                Message sentMessage = await e.Client.SendTextMessageAsync(
                    chatId: e.Update.Message.Chat.Id,
                    text: "Здравствуй, " + e.Update.Message.Chat.Username,
                    cancellationToken: e.CancellationToken);
            }
        }
        public static async Task OnImageMessageEvent(object sender, TelegramUpdateEventArgs e)
        {
            if (new string[] { "картинка" }.Contains(e.Update.Message!.Text!.ToLower()))
            {
                Console.WriteLine($"[INFO] Triggered 'OnImageMessageEvent' message from chat {e.Update.Message.Chat.Id}");

                Message sentMessage = await e.Client.SendPhotoAsync(
                    chatId: e.Update.Message.Chat.Id,
                    photo: InputFile.FromUri("https://2ch.hk/b/src/287201077/16842787235191.jpg"),
                    cancellationToken: e.CancellationToken);
            }
        }
        public static async Task OnVideoMessageEvent(object sender, TelegramUpdateEventArgs e)
        {
            if (new string[] { "видео" }.Contains(e.Update.Message!.Text!.ToLower()))
            {
                Console.WriteLine($"[INFO] Triggered 'OnVideoMessageEvent' message from chat {e.Update.Message.Chat.Id}");

                Message sentMessage = await e.Client.SendVideoAsync(
                    chatId: e.Update.Message.Chat.Id,
                    video: InputFile.FromUri("https://raw.githubusercontent.com/junkofuruto/sources/main/videoplayback.mp4"),
                    cancellationToken: e.CancellationToken);
            }
        }
        public static async Task OnStickerMessageEvent(object sender, TelegramUpdateEventArgs e)
        {
            if (new string[] { "стикер" }.Contains(e.Update.Message!.Text!.ToLower()))
            {
                Console.WriteLine($"[INFO] Triggered 'OnStickerMessageEvent' message from chat {e.Update.Message.Chat.Id}");

                Message sentMessage = await e.Client.SendStickerAsync(
                    chatId: e.Update.Message.Chat.Id,
                    sticker: InputFile.FromUri("https://raw.githubusercontent.com/junkofuruto/sources/main/sticker.webp"),
                    cancellationToken: e.CancellationToken);
            }
        }
        public static async Task OnButtonsMessageEvent(object sender, TelegramUpdateEventArgs e)
        {
            if (new string[] { "кнопки" }.Contains(e.Update.Message!.Text!.ToLower()))
            {
                Console.WriteLine($"[INFO] Triggered 'OnButtonsMessageEvent' message from chat {e.Update.Message.Chat.Id}");

                InlineKeyboardMarkup inlineKeyboard = new[]
                {
                    InlineKeyboardButton.WithCallbackData(text: "Микроконтроллеры", callbackData: "newtagselected:microcontrollers"),
                };

                Message sentMessage = await e.Client.SendTextMessageAsync(
                    chatId: e.Update.Message.Chat.Id,
                    text: "Выбор раздела",
                    replyMarkup: inlineKeyboard,
                    cancellationToken: e.CancellationToken);
            }
        }
    }
}
