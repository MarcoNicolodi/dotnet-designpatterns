namespace Command
{
    public interface IEletricalComponent
    {
        bool IsHeatOn { get; set; }
        bool IsRadioOn { get; set; }
        void TurnOnHeat();
        void TurnOffHeat();
        void TurnOnRadio();
        void TurnOffRadio();

    }
}