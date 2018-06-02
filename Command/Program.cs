using System;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            var vehicle = new VehicleControls();
            var carDashboard = new DigitalDashboard(vehicle);
            carDashboard.onHeatOnTouch();
            carDashboard.onHeatOffTouch();
            carDashboard.onRadioOnTouch();
            carDashboard.onRadioOffTouch();

            var house = new HouseControls();
            var houseDashboard = new DigitalDashboard(house);
            houseDashboard.onHeatOnTouch();
            houseDashboard.onHeatOffTouch();
            houseDashboard.onRadioOnTouch();
            houseDashboard.onRadioOffTouch();

            var carAnalogicToggles = new AnalogicToggles(vehicle);
            carAnalogicToggles.onHeatOnTouch();
            carAnalogicToggles.onHeatOffTouch();
            carAnalogicToggles.onRadioOnTouch();
            carAnalogicToggles.onRadioOffTouch();
        }
    }
}
