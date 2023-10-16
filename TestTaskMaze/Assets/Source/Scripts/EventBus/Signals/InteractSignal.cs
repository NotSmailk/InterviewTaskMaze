namespace Assets.Source.Scripts.Signals
{
    public class InteractSignal : ISignal
    {
        public bool interact;

        public InteractSignal(bool interact)
        {
            this.interact = interact;
        }
    }
}
