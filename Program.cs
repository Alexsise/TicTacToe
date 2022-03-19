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
            PlayerBehaviour.PlayerMove(ref GameField);
            Console.Clear();
            FieldRender(GameField);
            if (GameOverConditions(GameField, ref WhosWon))
                break;
        
            
            BotBehaviour.BotMove(ref GameField);
            Console.Clear();
            FieldRender(GameField);
            if (GameOverConditions(GameField, ref WhosWon))
                break;
            
            // Thread.Sleep(500);
        }

        var str = WhosWon switch
        {
            Empty => "Tie!",
            Bot => "Bot won!",
            Player => "You won",
            _ => "unimplemented error"
        };
        Console.WriteLine(str);
        Thread.Sleep(1000);
        Console.ReadKey();
    }

    
    
    
}
// X - player
// O - bot