using System;
using static System.Console;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Player.LifePoints = 30;
            game.Player.Position = (15, 10);
            game.Checkpoint();
            game.Player.LifePoints = 75;
            game.Player.Position = (123, 444);
            game.Checkpoint();
            game.Player.LifePoints = 1000;
            game.Player.Position = (4000, 15000);
            game.Checkpoint();
            game.GoBackInTime();
            LogState(game);
            game.GoBackInTime();
            LogState(game);
            game.GoBackInTime();
            LogState(game);
            game.GoBackToTheFuture();
            LogState(game);
            game.GoBackToTheFuture();
            LogState(game);
            game.GoBackToTheFuture();
            LogState(game);
        }

        static void LogState(Game game)
        {

            WriteLine($"LifePoints: {game.Player.LifePoints}");
            WriteLine($"Position: x:{game.Player.Position.x},y:{game.Player.Position.y}");
        }
    }
}
