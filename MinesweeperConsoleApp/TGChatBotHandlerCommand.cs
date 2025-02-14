using Minesweeper.DB;
using MinesweeperConsoleApp.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using static System.Net.Mime.MediaTypeNames;
using Game = Minesweeper.Shared.Model.Game;

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
                await CreateStartButtons(message.Chat.Id);
        }
        else if (update.Type == UpdateType.CallbackQuery)
        {
            if (update.CallbackQuery is null)
                throw new Exception("CallbackQuery is null");

            string? text = update.CallbackQuery.Data;

            if (text == "/start_game")
            {

                //TODO добавить проверку на начатую игру, если есть - предложить сыграть заного


                GameServices services = new GameServices(update.CallbackQuery.From.Id);

                Game game = services.CreateGame();

                await CreateFieldButtons(update.CallbackQuery.Message.Chat.Id, game.GetFieldArray());
            }

        }
    }

    private async Task CreateStartButtons(long chatId)
    {
        InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup([
                [InlineKeyboardButton.WithCallbackData("Начать играть", "/start_game")],
                [InlineKeyboardButton.WithCallbackData("Правила", "/rules")],
                [InlineKeyboardButton.WithCallbackData("Статистика", "/statistics")]
            ]);

        await _tgClient.SendMessage(chatId, "Выберете действие:", replyMarkup: keyboard);
    }


    private async Task CreateFieldButtons(long chatId, bool[,] field)
    {
        List<List<InlineKeyboardButton>> buttons = new();

        for (int i = 0; i < field.GetLength(0); i++)
        {
            var buttonRow = new List<InlineKeyboardButton>();
            for (int j = 0; j < field.GetLength(1); j++)
            {
                string text = " ";

                if (field[i, j])
                    text = "💣";

                buttonRow.Add(InlineKeyboardButton.WithCallbackData(text, $"/check_{i}_{j}"));
            }
            buttons.Add(buttonRow);
        }

        InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup(buttons);

        await _tgClient.SendMessage(chatId, "Поле", replyMarkup: keyboard);

    }
}