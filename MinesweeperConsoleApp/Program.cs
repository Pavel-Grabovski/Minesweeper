using Autofac;
using MinesweeperConsoleApp.Commands;

namespace MinesweeperConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {


        var builder = new ContainerBuilder();

        // Регистрация реализаций с именами
        builder.RegisterType<TestCommand>().Named<ITGCommand>("/test");
        builder.RegisterType<StartCommand>().Named<ITGCommand>("/start");
        builder.RegisterType<GetDataCommand>().Named<ITGCommand>("/data");
        var container = builder.Build();

        Console.WriteLine("Start MinesweeperConsoleApp.Main");

        TGChatBot _tgCommandHandler = new(Constants.Token); 

        Console.WriteLine("Bot TG started!");
        Console.Read();
    }
}
