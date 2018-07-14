namespace Command
{
    public class TurnOnRadioCommand : IUndoableCommand
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

        public void Undo()
        {
            _receiver.TurnOnRadio();
        }
    }
}