using BoardGamesConsole.Domain.Constants;
using BoardGamesConsole.Domain.ObjectModel.BoardGames;
using BoardGamesConsole.Interfaces;

namespace BoardGamesConsole.Services;

public class Menu : IMenu
{
    private readonly List<GameState> _results = [];
    public void Startup()
    {
        Console.Clear();
        Console.WriteLine("####################################");
        Console.WriteLine("Console Board Games");
        Console.WriteLine("####################################" + Environment.NewLine);
        Console.WriteLine("You will be playing TicTacToe");

        var finished = false;

        while (!finished)
        {
            var game = new TicTacToe();
            var gameRunner = new TicTacToeRunner(game);
            var result = gameRunner.Run();
            _results.Add(result);


            Console.WriteLine("Would you like to play again? (y, else quits)");
            var input = Console.ReadLine();
            if(!string.Equals(input, "y", StringComparison.OrdinalIgnoreCase))
            {
                finished = true;
            }
            Console.WriteLine();
        }
        DisplayLeaderBoard();
    }

    public void DisplayLeaderBoard()
    {
        Console.WriteLine("Drawn games: "+_results.Count(x => x == GameState.Draw));
        Console.WriteLine("Player1 Won games: "+_results.Count(x => x == GameState.Player1Win));
        Console.WriteLine("Player2 Won games: "+_results.Count(x => x == GameState.Player2Win));
    }
}
