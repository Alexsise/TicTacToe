namespace TicTacToe;

public static class Program
{
    public static void Main()
    {
        Random rnd = new();
        const bool gameOver = false;
        var gameField = new[] {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '};
        var whosWon = ' ';
        
        while (!gameOver)
        {
            var playerTurn = true;
            while (playerTurn)
            {
                Console.Write("Choose an unoccupied field: ");
                int i = Convert.ToInt16(Console.ReadLine());
                if (gameField[i-1] != ' ')
                    continue;
                gameField[i-1] = 'X';
                playerTurn = false;
            }

            var ll = GameOverConditions(gameField, ref whosWon);
            if (ll)
            {
                break;
            }
            
            var botTurn = true;
            Console.WriteLine("Bot is thinking, what to do...");
            
            Thread.Sleep(1000);
            
            while (botTurn)
            {
                var botPreMove = rnd.Next(0, 9);
                if (gameField[botPreMove] != ' ')
                    continue;
                gameField[botPreMove] = 'O';
                botTurn = false;
            }
            if (GameOverConditions(gameField, ref whosWon))
            {
                break;
            }
            
            Thread.Sleep(1000);
        }
        
        switch (whosWon)
        {
            case ' ':
                Console.WriteLine("Tie!");
                break;
            case 'O':
                Console.WriteLine("Bot won!");
                break;
            case 'X':
                Console.WriteLine("You won");
                break;
        }
    }
    private static bool GameOverConditions(char[] gameField, ref char whosWon)
    {
        whosWon = ' ';
        for (var i = 0; i < 9; i += 3)
        {
            if (gameField[i] == ' ') continue;
            if (gameField[i] != gameField[i + 1] || gameField[i + 1] != gameField[i + 2]) continue;
            whosWon = gameField[i];
            FieldRender(gameField);
            return true;
        }

        for (var i = 0; i < 3; i++)
        {
            if (gameField[i] == ' ') continue;
            if (gameField[i] != gameField[i + 3] || gameField[i + 3] != gameField[i + 6]) continue;
            whosWon = gameField[i];
            FieldRender(gameField);
            return true;
        }
        
        if (gameField[4] != ' ' &&
            (gameField[6] == gameField[4] || gameField[4] == gameField[2]) &&
            (gameField[0] == gameField[4] || gameField[4] == gameField[5]))
        {
            whosWon = gameField[4];
            FieldRender(gameField);
            return true;
        }

        byte occupiedSpaceCount = 0;
        foreach (var el in gameField)
        {
            if (el is 'X' or 'O')
                occupiedSpaceCount++;
        }
        
        FieldRender(gameField);
        return occupiedSpaceCount == 9;
    }

    private static void FieldRender(char[] gameField)
    {
        Console.WriteLine($" {gameField[6]} | {gameField[7]} | {gameField[8]} \n" +
                          "---+---+---\n" +
                          $" {gameField[3]} | {gameField[4]} | {gameField[5]} \n" +
                          "---+---+---\n" +
                          $" {gameField[0]} | {gameField[1]} | {gameField[2]} \n");
    }
    
    
}
// X - player
// O - bot