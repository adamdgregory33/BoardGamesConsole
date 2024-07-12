using BoardGamesConsole.Domain.ObjectModel.BoardGames;
using BoardGamesConsole.Interfaces;

namespace BoardGamesConsole.Services;

public class GameCatalogue : IGameCatalogue
{
    public IEnumerable<BoardGame> GetBoardGames()
    {
        return [
            new TicTacToe()
        ];
    }
}
