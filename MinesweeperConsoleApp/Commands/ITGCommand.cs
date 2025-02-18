using Telegram.Bot;
using Telegram.Bot.Types;

namespace MinesweeperConsoleApp.Commands;

public interface ITGCommand
{
    public Task Execute(Update update, ITelegramBotClient bot);
}
