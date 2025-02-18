using MinesweeperConsoleApp.Attributes;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MinesweeperConsoleApp.Commands;

[Trigger("/date")]
public class GetDataCommand : ITGCommand
{
    public async Task Execute(Update update, ITelegramBotClient bot)
    {
        await bot.SendMessage(update.Message.Chat.Id, $"Date Time : {DateTime.Now.ToString("D")}");
    }
}