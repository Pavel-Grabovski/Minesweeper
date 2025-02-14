using Minesweeper.DB;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Game = Minesweeper.Shared.Game;

namespace MinesweeperConsoleApp;

public class TGChatBotHandlerCommand
{
    private readonly TelegramBotClient _tgClient;

    public TGChatBotHandlerCommand(TelegramBotClient tgClient)
    {
        _tgClient = tgClient;
    }

    public async Task Handle(ITelegramBotClient client, Update update, CancellationToken token)
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
}