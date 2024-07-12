using BoardGamesConsole.Domain.ObjectModel.BoardGames;
using BoardGamesConsole.Domain.ObjectModel.Boards;

namespace BoardGamesConsole.Test.Unit.Domain;

public class TicTacToeTests
{
    [Fact]
    public void AssertNumberOfPlayers_IsTwo()
    {
        var ticTacToe = new TicTacToe();

        Assert.Equal(2, ticTacToe.NumberOfPlayers);
    }

    [Fact]
    public void AssertBoardType_IsTicTacToeBoard()
    {
        var ticTacToe = new TicTacToe();

        Assert.IsType<TicTacToeBoard>(ticTacToe.Board);
    }
}
