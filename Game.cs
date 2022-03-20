namespace TicTacToe;

using static Field.Occupation;
using static Field;

public static class Game
{
    private const bool GameOver = false;

    public static void GameInit(int gameDiff)
    {
        while (!GameOver)
        {
            Console.Clear();
            FieldRender(GameField);
            PlayerBehaviour.PlayerMove(ref GameField);
            Console.Clear();
            FieldRender(GameField);
            if (GameOverConditions(GameField, ref WhosWon))
                break;

            BotBehaviour.BotMove(ref GameField, gameDiff);
            Console.Clear();
            FieldRender(GameField);
            if (GameOverConditions(GameField, ref WhosWon))
                break;
        }

        var str = WhosWon switch
        {
            Empty => "Tie!",
            Bot => "Bot won!",
            Player => "You won",
            _ => "unimplemented error"
        };
        Console.WriteLine(str);

        for (var i = 0; i < GameField.Length; i++) GameField[i] = Empty;

        Thread.Sleep(1000);
    }
}