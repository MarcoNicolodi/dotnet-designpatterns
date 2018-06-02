namespace Command
{
    public class TurnOnHeatCommand : ICommand
    {
        private IEletricalComponent _receiver;

        public TurnOnHeatCommand(IEletricalComponent receiver)
        {
            _receiver = receiver;

        }
        public void Execute()
        {
            _receiver.TurnOnHeat();
        }
    }
}