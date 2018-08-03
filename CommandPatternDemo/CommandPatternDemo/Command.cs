using System;

namespace CommandPatternDemo
{
    internal abstract class Command
    {
        protected Receiver receiver;
        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }
        internal abstract void Action();
    }
}