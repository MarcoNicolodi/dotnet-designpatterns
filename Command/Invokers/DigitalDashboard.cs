using System;

namespace Command
{
    public class DigitalDashboard
    {
        private IUndoableCommand[] _commands = new IUndoableCommand[2];

        public DigitalDashboard(IEletricalComponent component)
        {
            _commands[0] = new TurnOnHeatCommand(component);
            _commands[1] = new TurnOnRadioCommand(component);
        }

        public void onHeatOnTouch()
        {
            Console.WriteLine("Turning heat on through a digital dashboard");
            _commands[0].Execute();
        }

        public void onHeatOffTouch()
        {
            Console.WriteLine("Turning heat off through a digital dashboard");
            _commands[0].Undo();
        }

        public void onRadioOnTouch()
        {
            Console.WriteLine("Turning radio on through a digital dashboard");
            _commands[1].Execute();
        }

        public void onRadioOffTouch()
        {
            Console.WriteLine("Turning radio off through a digital dashboard");
            _commands[1].Undo();
        }
    }
}