using MinesweeperConsoleApp.Attributes;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MinesweeperConsoleApp.Commands;

[Trigger("/start")]
public class StartCommand : ITGCommand
{
    public async Task Execute(Update update, ITelegramBotClient bot)
    {
        await bot.SendMessage(update.Message.Chat.Id, "Welcome to Your Bot");
    }
}
