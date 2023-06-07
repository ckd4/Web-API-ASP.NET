using Domain.TelegramEventArgs;
using Telegram.Bot.Exceptions;

namespace ClientTelegramBot
{
    internal static class ErrorEvents
    {
        public static Task OnDefaultErrorEvent(object sender, TelegramErrorEventArgs e)
        {
            var ErrorMessage = e.Exception switch
            {
                ApiRequestException apiRequestException
                    => $"[ERR] {apiRequestException.ErrorCode} - {apiRequestException.Message}",
                _ => e.Exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}
