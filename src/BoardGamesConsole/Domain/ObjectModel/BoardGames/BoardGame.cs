
using BoardGamesConsole.Domain.ObjectModel.Boards;

namespace BoardGamesConsole.Domain.ObjectModel.BoardGames;

public abstract class BoardGame
{
    public abstract int NumberOfPlayers { get; set; }
    public abstract Board Board { get; set; }
}
