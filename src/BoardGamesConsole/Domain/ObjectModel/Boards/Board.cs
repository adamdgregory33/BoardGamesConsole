namespace BoardGamesConsole.Domain.ObjectModel.Boards;

public abstract class Board
{
    public abstract string[,] BoardArray { get; set; }

    public abstract void Print();
}