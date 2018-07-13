using System;

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
            game.Player.LogState();
            game.GoBackToTheFuture();
            game.Player.LogState();
            game.GoBackInTime();
            game.GoBackInTime();
            game.GoBackInTime();
            game.Player.LogState();
            game.GoBackToTheFuture();
            game.Player.LogState();
        }
    }
}
