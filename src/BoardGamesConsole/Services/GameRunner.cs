using BoardGamesConsole.Domain.Constants;
using BoardGamesConsole.Domain.ObjectModel.BoardGames;
using BoardGamesConsole.Interfaces;

namespace BoardGamesConsole.Services;

public abstract class GameRunner : IGameRunner
{
    public abstract GameState Run();
    public abstract GameState PlayRound();
    public abstract GameState HasPlayerWon(int player);
    public abstract void PrintBoard();

}
