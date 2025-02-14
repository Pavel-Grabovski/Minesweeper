using Minesweeper.Shared.Model;

namespace Minesweeper.DB;

public class GameMemoryRepository
{
    private static readonly Dictionary<long, Game> _games = new Dictionary<long, Game>();

    public static void Add(Game game)
    {
        _games[game.UserId] = game;
    }

    public static Game Get(long userId)
    {
        return _games[userId];
    }
}
