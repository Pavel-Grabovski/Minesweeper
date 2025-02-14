namespace Minesweeper.Shared.Model;

public class Game
{
    public Guid Id { get; }

    private readonly long _userId;

    private readonly Field _field;

    public Game(long userId)
    {
        _userId = userId;
        Id = Guid.NewGuid();

        _field = new Field();
    }

    public Field GetField() => _field;
}
