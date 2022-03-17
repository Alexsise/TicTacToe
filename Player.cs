namespace TicTacToe;
using static Field;
using static Field.Occupation;

public class Player
{
    public static void PlayerMove(Occupation[] gameField)
    {
        var playerTurn = true;
        while (playerTurn)
        {
            Console.Write("Choose an unoccupied field: ");
            int i;
            try
            {
                i = Convert.ToInt16(Console.ReadLine());
            }
            catch
            {
                continue;
            }

            if (gameField[i - 1] != Empty)
                continue;
            gameField[i - 1] = Occupation.Player;
            playerTurn = false;
        }
    }
    
    
}