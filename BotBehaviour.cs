namespace TicTacToe;

using static Field;
using static Field.Occupation;

public static class BotBehaviour
{
    public static void BotMove(ref Occupation[] gameField, int gameDiff)
    {
        int bestMove = default;

        Console.WriteLine("Bot is thinking, what to do...\n");

        switch (gameDiff)
        {
            case 1:
                RandMove(out bestMove);
                break;
            case 2:
            {
                var rnd = new Random();
                if (rnd.Next(1, 3) < 2)
                    RandMove(out bestMove);
                else
                    MiniMaxInit(ref gameField, ref bestMove);
                break;
            }
            case 3:
                MiniMaxInit(ref gameField, ref bestMove);
                break;
        }

        gameField[bestMove] = Bot;
    }

    private static void RandMove(out int bestMove)
    {
        var rnd = new Random();
        bestMove = rnd.Next(1, 9);
        if (GameField[bestMove] != Empty)
            RandMove(out bestMove);
    }

    private static void MiniMaxInit(ref Occupation[] gameField, ref int bestMove)
    {
        var bestScore = int.MinValue;

        for (var i = 0; i < gameField.Length; i++)
            if (gameField[i] == Empty)
            {
                gameField[i] = Bot;
                var score = MiniMax(ref gameField, false);
                gameField[i] = Empty;
                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = i;
                }
            }
    }


    private static int MiniMax(ref Occupation[] gameField, bool isMaximizer)
    {
        var gameOver = GameOverConditions(gameField, ref WhosWon);
        if (gameOver)
            switch (WhosWon)
            {
                case Player:
                    return -1;
                case Bot:
                    return 1;
                default:
                    return 0;
            }


        if (isMaximizer)
        {
            var bestScore = int.MinValue;
            for (var i = 0; i < gameField.Length; i++)
                if (gameField[i] == Empty)
                {
                    gameField[i] = Bot;
                    var score = MiniMax(ref gameField, false);
                    gameField[i] = Empty;
                    bestScore = Math.Max(bestScore, score);
                }

            return bestScore;
        }
        else
        {
            var bestScore = int.MaxValue;
            for (var i = 0; i < gameField.Length; i++)
                if (gameField[i] == Empty)
                {
                    gameField[i] = Player;
                    var score = MiniMax(ref gameField, true);
                    gameField[i] = Empty;
                    bestScore = Math.Min(bestScore, score);
                }

            return bestScore;
        }
    }
}

//TODO Реализовать выбор сложности