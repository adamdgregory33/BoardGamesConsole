// See https://aka.ms/new-console-template for more information
using BoardGamesConsole.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var menu = new Menu();
        menu.Startup();
    }
}