namespace Command
{
    public class TurnOnHeatCommand : IUndoableCommand
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

        public void Undo()
        {
            _receiver.TurnOffHeat();
        }
    }
}