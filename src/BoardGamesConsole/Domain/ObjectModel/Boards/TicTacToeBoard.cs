namespace BoardGamesConsole.Domain.ObjectModel.Boards;

public class TicTacToeBoard : Board
{
    public override string[,] BoardArray { get; set; } = new string[3, 3];
    public override void Print()
    {
        Console.WriteLine();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                var toDisplay = BoardArray[i, j];
                toDisplay ??= " ";
                Console.Write(" " + toDisplay+" ");
                if (j < 2)
                {
                    Console.Write("|");
                }
            }
            Console.WriteLine();
            if (i < 2)
            {
                Console.WriteLine("-----------");
            }
        }
        Console.WriteLine();
    }
}