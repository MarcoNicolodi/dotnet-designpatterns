namespace Command
{
    public class TurnOffHeatCommand : ICommand
    {
        private IEletricalComponent _receiver;

        public TurnOffHeatCommand(IEletricalComponent receiver)
        {
            _receiver = receiver;
        }
        public void Execute()
        {
            _receiver.TurnOffHeat();
        }
    }
}