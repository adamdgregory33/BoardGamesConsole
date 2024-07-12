using BoardGamesConsole.Domain.ObjectModel.Boards;
using BoardGamesConsole.Services;

namespace BoardGamesConsole.Test.Unit.Service;

public class TicTacToeRunnerTests
{

    [Fact]
    public void GivenFullBoard_HasSpaceToPlay_ReturnsFalse()
    {
        var board = new TicTacToeBoard()
        {
            BoardArray = new string[,] 
            {  
                { "x", "x", "x" },
                { "x", "x", "x" },
                { "x", "x", "x" }
            }
        };
        
        Assert.False(TicTacToeRunner.HasSpaceToPlay(board));
    }

    [Fact]
    public void GivenNonFullBoard_HasSpaceToPlay_ReturnsTrue()
    {
        var board = new TicTacToeBoard()
        {
            BoardArray = new string[,] 
            {  
                { "x", "", "x" },
                { "x", "x", "x" },
                { "x", "x", "x" }
            }
        };
        
        Assert.True(TicTacToeRunner.HasSpaceToPlay(board));
    }

    [Theory]
    [MemberData(nameof(WinConditionsData))]
    public void GivenWinConditions_IsWinnerOnBoard_ReturnsTrue(TicTacToeBoard board)
    {       
        Assert.True(TicTacToeRunner.IsWinnerOnBoard(board));
    }

    [Theory]
    [MemberData(nameof(NoWinConditionData))]
    public void GivenNoWinConditions_IsWinnerOnBoard_ReturnsFalse(TicTacToeBoard board)
    {       
        Assert.False(TicTacToeRunner.IsWinnerOnBoard(board));
    }

    [Fact]
    public void GiveDraw_IsWinnerOnBoard_ReturnsFalse()
    {       
        var board = new TicTacToeBoard()
        {
            BoardArray = new string[,] 
            {  
                { "x", "o", "x" },
                { "o", "x", "o" },
                { "o", "x", "o" }
            }
        };
        Assert.False(TicTacToeRunner.IsWinnerOnBoard(board));
    }

    #region TestData

    public static TheoryData<TicTacToeBoard> WinConditionsData =
    [
        new()
        {
            BoardArray = new string[,] 
            {  
                { "x", "x", "x" },
                { "", "", "" },
                { "", "", "" }
            }
        },
        new ()
        {
            BoardArray = new string[,] 
            {  
                { "", "", "" },
                { "x", "x", "x" },
                { "", "", "" }
            }
        },
        new ()
        {
            BoardArray = new string[,] 
            {  
                { "", "", "" },
                { "", "", "" },
                { "x", "x", "x" }
            }
        },
        new ()
        {
            BoardArray = new string[,] 
            {  
                { "x", "", "" },
                { "x", "", "" },
                { "x", "", "" }
            }
        },
        new ()
        {
            BoardArray = new string[,] 
            {  
                { "", "x", "" },
                { "", "x", "" },
                { "", "x", "" }
            }
        },
        new ()
        {
            BoardArray = new string[,] 
            {  
                { "", "", "x" },
                { "", "", "x" },
                { "", "", "x" }
            }
        },
        new ()
        {
            BoardArray = new string[,] 
            {  
                { "x", "", "" },
                { "", "x", "" },
                { "", "", "x" }
            }
        },
        new ()
        {
            BoardArray = new string[,] 
            {  
                { "", "", "x" },
                { "", "x", "" },
                { "x", "", "" }
            }
        }
    ];

    public static TheoryData<TicTacToeBoard> NoWinConditionData =
    [
        new()
        {
            BoardArray = new string[,] 
            {  
                { "x", "x", "o" },
                { "", "", "" },
                { "", "", "" }
            }
        },
        new ()
        {
            BoardArray = new string[,] 
            {  
                { "", "", "" },
                { "x", "o", "x" },
                { "", "", "" }
            }
        },
        new ()
        {
            BoardArray = new string[,] 
            {  
                { "", "", "" },
                { "", "", "" },
                { "o", "x", "x" }
            }
        },
        new ()
        {
            BoardArray = new string[,] 
            {  
                { "x", "", "" },
                { "o", "", "" },
                { "x", "", "" }
            }
        },
        new ()
        {
            BoardArray = new string[,] 
            {  
                { "", "x", "" },
                { "", "o", "" },
                { "", "x", "" }
            }
        },
        new ()
        {
            BoardArray = new string[,] 
            {  
                { "", "", "x" },
                { "", "", "x" },
                { "", "", "o" }
            }
        },
        new ()
        {
            BoardArray = new string[,] 
            {  
                { "x", "", "" },
                { "", "x", "" },
                { "", "", "o" }
            }
        },
        new ()
        {
            BoardArray = new string[,] 
            {  
                { "", "", "x" },
                { "", "o", "" },
                { "x", "", "" }
            }
        },
        new ()
        {
            BoardArray = new string[,] 
            {  
                { "", "", "x" },
                { "", "", "" },
                { "x", "", "" }
            }
        },
        new ()
        {
            BoardArray = new string[,] 
            {  
                { "", "x", "x" },
                { "x", "", "" },
                { "x", "", "x" }
            }
        },
        new ()
        {
            BoardArray = new string[,] 
            {  
                { "", "", "" },
                { "", "", "" },
                { "", "", "" }
            }
        },
        new ()
        {
            BoardArray = new string[,] 
            {  
                { "x", "o", "x" },
                { "o", "x", "o" },
                { "o", "x", "o" }
            }
        }
    ];

    #endregion
}

