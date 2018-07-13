using System;

namespace Memento
{
    public class Player
    {
        public int LifePoints { get; set; }
        public (int x, int y) Position { get; set; }

        public IMemento CreateMemento()
        {
            var state = new Player()
            {
                Position = Position,
                LifePoints = LifePoints

            };

            return new PlayerMemento() { State = state };
        }

        public void SetMemento(IMemento memento)
        {

            var state = (Player)memento.State;
            Position = state.Position;
            LifePoints = state.LifePoints;
        }

        public void LogState()
        {
            Console.WriteLine($"LifePoints: {LifePoints}");
            Console.WriteLine($"Position: x:{Position.x},y:{Position.y}");
        }

        class PlayerMemento : IMemento
        {
            public object State { get; set; }
        }
    }
}