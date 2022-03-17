namespace TicTacToe;
using static Field;
using static Field.Occupation;

public class Bot
{
    private static Random rnd = new();
    
    public static void BotMove(Occupation[] gameField)
    {
        var botTurn = true;
        Console.WriteLine("Bot is thinking, what to do...\n");

        Thread.Sleep(1000);

        while (botTurn)
        {
            var botPreMove = rnd.Next(0, 9);
            if (gameField[botPreMove] != Empty)
                continue;
            gameField[botPreMove] = Occupation.Bot;
            botTurn = false;
        }
        
    }
}