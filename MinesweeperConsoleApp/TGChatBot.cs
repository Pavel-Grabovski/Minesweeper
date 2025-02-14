using Minesweeper.DB;
using Minesweeper.Shared;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Game = Minesweeper.Shared.Game;

namespace MinesweeperConsoleApp;

public class TGChatBot
{
    private readonly TelegramBotClient _tgClient;

    public TGChatBot(string token)
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
            if (update.CallbackQuery is null)
                throw new Exception("CallbackQuery is null");

            string? text = update.CallbackQuery.Data;

            if (text == "/start_game")
            {
                GameMemoryRepository.Add(
                    update.CallbackQuery.From.Id, 
                    new Game(update.CallbackQuery.From.Id));
            }

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
