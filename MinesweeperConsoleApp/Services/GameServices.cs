using Minesweeper.DB;
using Game = Minesweeper.Shared.Model.Game;

namespace MinesweeperConsoleApp.Services;

public class GameServices
{
    private long _userId;
    public GameServices(long userId)
    {
        _userId = userId;
    }

    public Game CreateGame()
    {
        Game game = new Game(_userId);

        GameMemoryRepository.Add(game);

        return game;
    }
}
