using BoardGamesConsole.Domain.Constants;
using BoardGamesConsole.Domain.ObjectModel.BoardGames;
using BoardGamesConsole.Domain.ObjectModel.Boards;
using BoardGamesConsole.Interfaces;

namespace BoardGamesConsole.Services;

public class TicTacToeRunner(BoardGame game) : GameRunner, IGameRunner
{
    private readonly BoardGame _boardGame = game;
    private int _round = 0;
    private GameState _gameState = GameState.Running;

    public override void PrintBoard()
    {
        _boardGame.Board.Print();
    }

    public override GameState Run()
    {
        while (_gameState == GameState.Running)
        {
            PlayRound();
        }

        PrintBoard();
        
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("The game has ended!");
        Console.WriteLine();
        GenerateWinMessage();
        Console.WriteLine();

        return _gameState;
    }

    public override GameState PlayRound()
    {
        _round++;
        PrintBoard();
        PlayRoundForPlayer(1);
        _gameState = HasPlayerWon(1);

        if (_gameState != GameState.Running)
        {
            return _gameState;
        }

        PrintBoard();
        PlayRoundForPlayer(2);
        _gameState = HasPlayerWon(2);

        return _gameState;
    }

    private void GenerateWinMessage()
    {
        switch(_gameState)
        {
            case GameState.Draw:
                Console.WriteLine("The game ended in a draw! Better luck next time");
                break;
            case GameState.Player1Win:
                Console.WriteLine("Player 1 Won! Congratulations!");
                break;            
            case GameState.Player2Win:
                Console.WriteLine("Player 2 Won! Congratulations!");
                break;
            default:
                Console.WriteLine("Something went wrong... press Ctrl+C to exit");
                break;
        }
    }

    public override GameState HasPlayerWon(int player)
    {
        if (_round < 3)
        {
            return GameState.Running;
        }
        var hasPlayerWon = IsWinnerOnBoard(_boardGame.Board as TicTacToeBoard);
        if (hasPlayerWon)
        {
            return player == 1 ? GameState.Player1Win : GameState.Player2Win;
        }
        else
        {
            var hasSpaceToPlay = HasSpaceToPlay(_boardGame.Board as TicTacToeBoard);
            if (!hasSpaceToPlay)
            {
                return GameState.Draw;
            }
        }
        return GameState.Running;
    }

    public static bool IsWinnerOnBoard(TicTacToeBoard board)
    {
        bool row1 = !string.IsNullOrWhiteSpace(board.BoardArray[0, 0]) &&  board.BoardArray[0, 0] == board.BoardArray[0, 1] && board.BoardArray[0, 1] == board.BoardArray[0, 2];
        bool row2 = !string.IsNullOrWhiteSpace(board.BoardArray[1, 0]) &&  board.BoardArray[1, 0] == board.BoardArray[1, 1] && board.BoardArray[1, 1] == board.BoardArray[1, 2];
        bool row3 = !string.IsNullOrWhiteSpace(board.BoardArray[2, 0]) &&  board.BoardArray[2, 0] == board.BoardArray[2, 1] && board.BoardArray[2, 1] == board.BoardArray[2, 2];
        bool col1 = !string.IsNullOrWhiteSpace(board.BoardArray[0, 0]) &&  board.BoardArray[0, 0] == board.BoardArray[1, 0] && board.BoardArray[1, 0] == board.BoardArray[2, 0];
        bool col2 = !string.IsNullOrWhiteSpace(board.BoardArray[0, 1]) &&  board.BoardArray[0, 1] == board.BoardArray[1, 1] && board.BoardArray[1, 1] == board.BoardArray[2, 1];
        bool col3 = !string.IsNullOrWhiteSpace(board.BoardArray[0, 2]) &&  board.BoardArray[0, 2] == board.BoardArray[1, 2] && board.BoardArray[1, 2] == board.BoardArray[2, 2];
        bool diagDown = !string.IsNullOrWhiteSpace(board.BoardArray[0, 0]) &&  board.BoardArray[0, 0] == board.BoardArray[1, 1] && board.BoardArray[1, 1] == board.BoardArray[2, 2];
        bool diagUp = !string.IsNullOrWhiteSpace(board.BoardArray[0, 2]) &&  board.BoardArray[0, 2] == board.BoardArray[1, 1] && board.BoardArray[1, 1] == board.BoardArray[2, 0];

        if(row1 || row2 || row3 || col1 || col2 || col3 || diagDown || diagUp)
        {
            return true;
        }
        return false;
    }

    public static bool HasSpaceToPlay(TicTacToeBoard board)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (string.IsNullOrWhiteSpace(board.BoardArray[i, j]))
                {
                    return true;
                }
            }
        }
        return false;
    }


    private void PlayRoundForPlayer(int player)
    {
        var isValidChoice = false;
        while (!isValidChoice)
        {
            isValidChoice = true;
            Console.WriteLine("Player " + player + ":");
            Console.WriteLine("Please enter the co-ordinates (0,0 being top left most, 2,2 bottom right most)");
            Console.WriteLine("In the format: x,y");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                PrintInvalidInput();
                isValidChoice = false;
                continue;
            }
            var coordinates = input.Split(',');
            if (coordinates.Length < 2)
            {
                PrintInvalidInput();
                isValidChoice = false;
                continue;
            }

            if (!int.TryParse(coordinates[0], out int x) || x < 0 || x >= 3)
            {
                PrintInvalidInput();
                isValidChoice = false;
                continue;
            }
            if (!int.TryParse(coordinates[1], out int y) || y < 0 || y >= 3)
            {
                PrintInvalidInput();
                isValidChoice = false;
                continue;
            }
            if (_boardGame.Board.BoardArray[x, y] != null)
            {
                PrintInvalidInput();
                isValidChoice = false;
                continue;
            }
            _boardGame.Board.BoardArray[x, y] = player == 1 ? "x" : "o";
        }
    }

    private static void PrintInvalidInput() => Console.WriteLine("Please enter a valid input." + Environment.NewLine);

}
