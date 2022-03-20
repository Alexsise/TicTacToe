namespace TicTacToe;

using static Game;

public static class Program
{
    public static void Main()
    {
        MainMenu();
    }

    private static void MainMenu()
    {
        Console.Clear();

        Console.WriteLine(
            "Tic-tac-toe is a paper-and-pencil game for two players who take turns marking the spaces in a three-by-three grid with X or O.\n" +
            "The player who succeeds in placing three of their marks in a horizontal, vertical, or diagonal row is the winner.\n" +
            "It is a solved game, with a forced draw assuming best play from both players.\n");

        Console.Write("1)Easy\n" +
                      "2)Medium\n" +
                      "3)Hard\n" +
                      "Choose you difficulty: ");

        int gameDiff = default;

        try
        {
            gameDiff = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            MainMenu();
        }

        if (gameDiff is >= 4 or <= 0)
            MainMenu();

        GameInit(gameDiff);

        Restart();
    }

    private static void Restart()
    {
        try
        {
            Console.Write("Type \"r\" or \"R\" to restart: ");
            if (Console.ReadLine()![0] is 'r' or 'R')
                MainMenu();
        }
        catch
        {
            Restart();
        }
    }
}
// X - player
// O - bot