namespace CommandPatternDemo
{
    internal class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver r) : base(r) { }

        internal override void Action()
        {
            receiver.Run1000Meters();
        }
    }
}