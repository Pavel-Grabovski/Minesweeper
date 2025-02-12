using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace MinesweeperConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Start MinesweeperConsoleApp!");
        TelegramBotClient tgClient = new(Constants.Key);
        tgClient.StartReceiving(HandleUpdate, HandleError);
        Console.WriteLine("Bot TG started!");
        Console.Read();
    }

    private static async Task HandleError(ITelegramBotClient client, Exception exception, HandleErrorSource source, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    private static async Task HandleUpdate(ITelegramBotClient client, Update update, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
