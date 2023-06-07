using Domain;
using Domain.TelegramEventArgs;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ClientTelegramBot
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Events.TextMessage += UpdateEvents.OnStartMessageEvent;
            Events.TextMessage += UpdateEvents.OnHelloMessageEvent;
            Events.TextMessage += UpdateEvents.OnImageMessageEvent;
            Events.TextMessage += UpdateEvents.OnVideoMessageEvent;
            Events.TextMessage += UpdateEvents.OnStickerMessageEvent;
            Events.TextMessage += UpdateEvents.OnButtonsMessageEvent;
            Events.Error += ErrorEvents.OnDefaultErrorEvent;

            var client = new TelegramBotClient("6134900809:AAEUwrgJh0TNtZSHYA_27yDjrFzt1AtKvr8");
            client.StartReceiving(HandleUpdateAsync, HandleErrorAsync);
            Console.ReadLine();
        }

        public async static Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            TelegramUpdateEventArgs e = new TelegramUpdateEventArgs(client, update, cancellationToken);
            if (e.Update.Message?.Text != null) await Events.InvokeTextMessageEvent(client, e);
            else if (e.Update.InlineQuery?.Query != null) await Events.InvokeInlineQueryEvent(client, e);
        }

        public async static Task HandleErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken cancellationToken)
        {
            TelegramErrorEventArgs e = new TelegramErrorEventArgs(client, exception, cancellationToken);
            await Events.InvokeError(client, e);
        }
    }
}