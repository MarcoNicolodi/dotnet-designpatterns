using System;

namespace Command
{
    public class HouseControls : IEletricalComponent
    {
        public bool IsHeatOn { get; set; }
        public bool IsRadioOn { get; set; }

        public void TurnOnHeat()
        {
            Console.WriteLine("House heat is now on");
            IsHeatOn = true;
        }

        public void TurnOffHeat()
        {
            Console.WriteLine("House heat is now off");
            IsHeatOn = false;
        }

        public void TurnOnRadio()
        {
            Console.WriteLine("House radio is now on");
            IsRadioOn = true;
        }

        public void TurnOffRadio()
        {
            Console.WriteLine("House radio is now off");
            IsRadioOn = false;
        }
    }
}