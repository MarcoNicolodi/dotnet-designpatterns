using System;

namespace Command
{
    public class VehicleControls : IEletricalComponent
    {
        public bool IsHeatOn { get; set; }
        public bool IsRadioOn { get; set; }

        public void TurnOnHeat()
        {
            Console.WriteLine("Car heat is now on");
            IsHeatOn = true;
        }

        public void TurnOffHeat()
        {
            Console.WriteLine("Car heat is now off");
            IsHeatOn = false;
        }

        public void TurnOnRadio()
        {
            Console.WriteLine("Car radio is now on");
            IsRadioOn = true;
        }

        public void TurnOffRadio()
        {
            Console.WriteLine("Car radio is now off");
            IsRadioOn = false;
        }
    }
}