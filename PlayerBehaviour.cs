namespace TicTacToe;

using static Field;
using static Field.Occupation;

public static class PlayerBehaviour
{
    public static void PlayerMove(ref Occupation[] gameField)
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

            if (i is > 10 or < 1)
                continue;

            if (gameField[i - 1] != Empty)
                continue;
            gameField[i - 1] = Player;
            playerTurn = false;
        }
    }
}