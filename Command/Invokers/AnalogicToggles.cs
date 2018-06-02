using System;

namespace Command
{
    public class AnalogicToggles
    {
        private ICommand[] _commands = new ICommand[4];
        public AnalogicToggles(IEletricalComponent component)
        {
            _commands[0] = new TurnOnHeatCommand(component);
            _commands[1] = new TurnOffHeatCommand(component);
            _commands[2] = new TurnOnRadioCommand(component);
            _commands[3] = new TurnOffRadioCommand(component);
        }

        public void onHeatOnTouch()
        {
            Console.WriteLine("Turning heat on through a analogic toggle");
            _commands[0].Execute();
        }

        public void onHeatOffTouch()
        {
            Console.WriteLine("Turning heat off through a analogc toggle");
            _commands[1].Execute();
        }

        public void onRadioOnTouch()
        {
            Console.WriteLine("Turning radio on through a analogic toggle");
            _commands[2].Execute();
        }

        public void onRadioOffTouch()
        {
            Console.WriteLine("Turning radio off through a analogic toggle");
            _commands[3].Execute();
        }
    }
}