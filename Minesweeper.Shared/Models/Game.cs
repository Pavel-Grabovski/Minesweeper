namespace Minesweeper.Shared;

public class Game
{
    public Guid Id { get; }

    private readonly long _userId;

    public Game(long userId)
    {
        _userId = userId;
        Id = Guid.NewGuid();
    }
}
