namespace TicTacToe;
using static Field;
using static Field.Occupation;

public static class BotBehaviour
{
    public static void BotMove(ref Occupation[] gameField)
    {
        int bestMove = default;
        
        Console.WriteLine("Bot is thinking, what to do...\n");

        Thread.Sleep(1000);
        var bestScore = int.MinValue;
        
        for (var i = 0; i < gameField.Length; i++)
        {
            if (gameField[i] == Empty)
            {
                gameField[i] = Bot;
                // var bestScore = int.MinValue;
                var score = MiniMax(ref gameField, 0, false);
                gameField[i] = Empty;
                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = i;
                    //break;
                }
            }
        }
        
        gameField[bestMove] = Bot;
    }
    
    
    private static int MiniMax(ref Occupation[] gameField, int depth, bool isMaximizer)
    {
        var gameOver = GameOverConditions(gameField, ref WhosWon);
        if (gameOver)
        {
            switch (WhosWon)
            {
                case Player:
                    return -1;
                case Bot:
                    return 1;
                default:
                    return 0;
            }
        }
        
        
        if (isMaximizer)
        {
            var bestScore = int.MinValue;
            for (var i = 0; i < gameField.Length; i++)
            {
                if (gameField[i] == Empty)
                {
                    gameField[i] = Bot;
                    var score = MiniMax(ref gameField, depth + 1, false);
                    gameField[i] = Empty;
                    bestScore = Math.Max(bestScore, score);
                }
            }
            return bestScore;
        }
        else
        {
            var bestScore = int.MaxValue;
            for (var i = 0; i < gameField.Length; i++)
            {
                if (gameField[i] == Empty)
                {
                    gameField[i] = Player;
                    var score = MiniMax(ref gameField, depth + 1, true);
                    gameField[i] = Empty;
                    bestScore = Math.Min(bestScore, score);
                }
            }
            return bestScore;
        }
    }
}