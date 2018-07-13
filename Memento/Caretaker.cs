using System.Collections.Generic;

namespace Memento
{
    public class Game
    {
        private readonly Stack<IMemento> _undoStack = new Stack<IMemento>();
        private readonly Stack<IMemento> _redoStack = new Stack<IMemento>();
        public readonly Player Player = new Player();
        public Game()
        {
            Player.LifePoints = 15;
            Player.Position = (1, 3);
        }

        public void Checkpoint()
        {
            var memento = Player.CreateMemento();
            _undoStack.Push(memento);
        }

        public void GoBackInTime()
        {
            if (_undoStack.Count > 0)
            {
                var memento = _undoStack.Pop();
                _redoStack.Push(memento);
                Player.SetMemento(memento);
            }
        }

        public void GoBackToTheFuture()
        {
            if (_redoStack.Count > 0)
            {
                var memento = _redoStack.Pop();
                _undoStack.Push(memento);
                Player.SetMemento(memento);
            }
        }

    }
}