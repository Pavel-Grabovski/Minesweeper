using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace MinesweeperConsoleApp;

internal class Program
{
    private static TelegramBotClient tgClient;
    static void Main(string[] args)
    {
        Console.WriteLine("Start MinesweeperConsoleApp!");
        tgClient = new(Constants.Token);
        tgClient.StartReceiving(HandleUpdate, HandleError);
        Console.WriteLine("Bot TG started!");
        Console.Read();
    }



    private static async Task HandleUpdate(ITelegramBotClient client, Update update, CancellationToken token)
    {

        if(update.Type == UpdateType.Message)
        {
            Message? message = update.Message;

            if (message?.Text == "/start")
                await CreateStartButtons(message);
        }
        else if(update.Type == UpdateType.CallbackQuery)
        {
            Message? message = update.CallbackQuery?.Message;

        }
    }

    private static async Task CreateStartButtons(Message message)
    {
        var keyboard = new InlineKeyboardMarkup([
                [InlineKeyboardButton.WithCallbackData("Начать играть", "/start_game")],
                [InlineKeyboardButton.WithCallbackData("Правила", "/rules")],
                [InlineKeyboardButton.WithCallbackData("Статистика", "/statistics")]
            ]);

        await tgClient.SendMessage(message.Chat.Id, "Выберете действие:", replyMarkup: keyboard);
    }

    private static async Task HandleError(ITelegramBotClient client, Exception exception, HandleErrorSource source, CancellationToken token)
    {
        Console.WriteLine(exception.Message);
    }
}
