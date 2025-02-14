using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace MinesweeperConsoleApp;

public class TGChatBot
{
    private readonly TelegramBotClient _tgClient;
    private readonly TGChatBotHandlerCommand _handlerCommand;


    public TGChatBot(string token)
    {
        _tgClient = new(token);
        _tgClient.StartReceiving(HandleUpdate, HandleError);
        _handlerCommand = new TGChatBotHandlerCommand(_tgClient);
    }

    private async Task HandleUpdate(ITelegramBotClient client, Update update, CancellationToken token)
    {
        await _handlerCommand.Handle(client, update, token);
    }

    private async Task HandleError(ITelegramBotClient client, Exception exception, HandleErrorSource source, CancellationToken token)
    {
        Console.WriteLine(exception.Message);
    }
}
