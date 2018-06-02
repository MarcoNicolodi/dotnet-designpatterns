namespace Command
{
    public class TurnOnRadioCommand : ICommand
    {
        private IEletricalComponent _receiver;

        public TurnOnRadioCommand(IEletricalComponent receiver)
        {
            _receiver = receiver;
        }
        public void Execute()
        {
            _receiver.TurnOnRadio();
        }
    }
}