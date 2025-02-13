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
        Message? message = update.Message;

        long chatId = message!.Chat.Id;
        string? text = message.Text;

        await client.SendMessage(chatId, message.Text);

        if (update.Type == UpdateType.Message)
        {
            if (message?.Type == MessageType.Text)
            {
                await tgClient.SendMessage(message.Chat.Id, "Ответ на команду!");

                if(message.Text == "/start")
                {
                    await CreateStartButtons(message);
                }
            }
            else
            {
                await tgClient.SendMessage(message.Chat.Id, "Пожалуйста, введите команду");
            }
        }
    }

    private static async Task CreateStartButtons(Message? message)
    {
        List<List<KeyboardButton>> keyboard = new List<List<KeyboardButton>>
        {
            new List<KeyboardButton>
            {
                new KeyboardButton { Text = "Начать играть" },
            },
            new List<KeyboardButton>
            {
                new KeyboardButton { Text = "Правила" }
            },
            new List<KeyboardButton>
            {
                new KeyboardButton { Text = "Настройки" }
            }
        };

        var replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboard);

        await tgClient.SendMessage(message.Chat.Id, "Выберете действие:", replyMarkup: replyKeyboardMarkup);
    }

    private static async Task HandleError(ITelegramBotClient client, Exception exception, HandleErrorSource source, CancellationToken token)
    {
        Console.WriteLine(exception.Message);
    }
}
