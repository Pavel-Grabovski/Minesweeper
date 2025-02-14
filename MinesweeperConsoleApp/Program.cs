namespace MinesweeperConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Start MinesweeperConsoleApp.Main");

        TGChatBot _tgCommandHandler = new(Constants.Token); 

        Console.WriteLine("Bot TG started!");
        Console.Read();
    }
}
