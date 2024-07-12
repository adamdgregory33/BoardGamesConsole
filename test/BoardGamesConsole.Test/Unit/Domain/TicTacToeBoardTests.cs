using BoardGamesConsole.Domain.ObjectModel.Boards;

namespace BoardGamesConsole.Test.Unit.Domain;

public class TicTacToeBoardTests
{
    [Fact]
    public void AssertBoardSize_Is3By3()
    {
        var board = new TicTacToeBoard();

        Assert.Equal(3, board.BoardArray.GetLength(0));
        Assert.Equal(3, board.BoardArray.GetLength(1));
    }
}