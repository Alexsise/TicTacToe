namespace TicTacToe;
using static Field.Occupation;
public static class Field
{
    public static Occupation[] GameField = {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty};
    public static Occupation WhosWon;
    
    public enum Occupation
    {
        Empty = ' ', 
        Player = 'X', 
        Bot = 'O'
        
    }
    
    internal static bool GameOverConditions(Occupation[] gameField, ref Occupation whosWon)
    {
        whosWon = Empty;
        for (var i = 0; i < 7; i += 3)
        {
            if (gameField[i] == Empty) continue;
            if (gameField[i] != gameField[i + 1] || gameField[i + 1] != gameField[i + 2]) continue;
            whosWon = gameField[i];
            return true;
        }

        for (var i = 0; i < 3; i++)
        {
            if (gameField[i] == Empty) continue;
            if (gameField[i] != gameField[i + 3] || gameField[i + 3] != gameField[i + 6]) continue;
            whosWon = gameField[i];
            return true;
        }
        
        if (gameField[4] != Empty)
        {
            if (gameField[6] == gameField[4] && gameField[4] == gameField[2] ||
                gameField[0] == gameField[4] && gameField[4] == gameField[5])
            {
                whosWon = gameField[4];
                return true;
            }
        }

        byte occupiedSpaceCount = 0;
        foreach (var el in gameField)
        {
            if (el is Player or Bot)
                occupiedSpaceCount++;
        }
        
        
        return occupiedSpaceCount == 9;
    }

    public static void FieldRender(Occupation[] gameField)
    {
        Console.WriteLine($" {(char)gameField[6]} | {(char)gameField[7]} | {(char)gameField[8]} \n" +
                          "---+---+---\n" +
                          $" {(char)gameField[3]} | {(char)gameField[4]} | {(char)gameField[5]} \n" +
                          "---+---+---\n" +
                          $" {(char)gameField[0]} | {(char)gameField[1]} | {(char)gameField[2]} \n");
    }
}