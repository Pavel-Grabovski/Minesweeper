namespace MinesweeperConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Start MinesweeperConsoleApp.Main");

        TGChatBotService _tgClient = new(Constants.Token); 

        Console.WriteLine("Bot TG started!");
        Console.Read();
    }
}
