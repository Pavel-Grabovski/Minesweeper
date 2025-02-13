using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace MinesweeperConsoleApp;

public class TGChatBotService
{
    private readonly TelegramBotClient _tgClient;
    public TGChatBotService(string token)
    {
        _tgClient = new(token);
        _tgClient.StartReceiving(HandleUpdate, HandleError);
    }

    private async Task HandleUpdate(ITelegramBotClient client, Update update, CancellationToken token)
    {

        if (update.Type == UpdateType.Message)
        {
            Message? message = update.Message;

            if (message?.Text == "/start")
                await CreateStartButtons(message);
        }
        else if (update.Type == UpdateType.CallbackQuery)
        {
            Message? message = update.CallbackQuery?.Message;

        }
    }

    private async Task CreateStartButtons(Message message)
    {
        var keyboard = new InlineKeyboardMarkup([
                [InlineKeyboardButton.WithCallbackData("Начать играть", "/start_game")],
                [InlineKeyboardButton.WithCallbackData("Правила", "/rules")],
                [InlineKeyboardButton.WithCallbackData("Статистика", "/statistics")]
            ]);

        await _tgClient.SendMessage(message.Chat.Id, "Выберете действие:", replyMarkup: keyboard);
    }

    private async Task HandleError(ITelegramBotClient client, Exception exception, HandleErrorSource source, CancellationToken token)
    {
        Console.WriteLine(exception.Message);
    }
}
