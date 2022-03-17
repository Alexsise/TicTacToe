namespace TicTacToe;

using static Field;
using static Field.Occupation;


public static class Program
{
    private const bool GameOver = false;
    public static void Main()
    {
        
        while (!GameOver)
        {
            Player.PlayerMove(GameField);
            if (GameOverConditions(GameField, ref WhosWon))
                break;

            Bot.BotMove(GameField);
            if (GameOverConditions(GameField, ref Field.WhosWon))
                break;
            
            Thread.Sleep(1000);
        }

        if (WhosWon == Empty)
            Console.WriteLine("Tie!");
        else if (Field.WhosWon == Occupation.Bot)
            Console.WriteLine("Bot won!");
        else if (Field.WhosWon == Occupation.Player) Console.WriteLine("You won");
    }

    
    
    
}
// X - player
// O - bot