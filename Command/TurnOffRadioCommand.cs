namespace Command
{
    public class TurnOffRadioCommand : ICommand
    {
        private IEletricalComponent _receiver;

        public TurnOffRadioCommand(IEletricalComponent receiver)
        {
            _receiver = receiver;
        }
        public void Execute()
        {
            _receiver.TurnOffRadio();
        }
    }
}