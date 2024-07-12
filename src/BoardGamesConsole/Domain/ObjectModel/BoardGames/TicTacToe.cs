using BoardGamesConsole.Domain.ObjectModel.Boards;

namespace BoardGamesConsole.Domain.ObjectModel.BoardGames;

public class TicTacToe : BoardGame
{
    public override int NumberOfPlayers { get; set; } = 2;
    public override Board Board { get; set; }
    public int Winner { get; set; } = -1;

    public TicTacToe()
    {
        NumberOfPlayers = 2;
        Board = new TicTacToeBoard();
    }
}
