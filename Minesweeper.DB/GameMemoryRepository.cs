using Minesweeper.Shared;

namespace Minesweeper.DB;

public class GameMemoryRepository
{
    private static readonly Dictionary<long, Game> _games = new Dictionary<long, Game>();

    public static void Add(long id, Game game)
    {
        _games[id] = game;
    }

    public static Game Get(long userId)
    {
        return _games[userId];
    }
}
