using MinesweeperConsoleApp.Attributes;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MinesweeperConsoleApp.Commands;

[Trigger("/test")]
public class TestCommand : ITGCommand
{
    public async Task Execute(Update update, ITelegramBotClient bot)
    {
        await bot.SendMessage(update.Message.Chat.Id, "Welcome to Your Bot");
    }
}