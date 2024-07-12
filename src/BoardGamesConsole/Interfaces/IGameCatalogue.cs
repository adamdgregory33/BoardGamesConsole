using BoardGamesConsole.Domain.ObjectModel.BoardGames;

namespace BoardGamesConsole.Interfaces;

public interface IGameCatalogue
{
    public IEnumerable<BoardGame> GetBoardGames();
}
