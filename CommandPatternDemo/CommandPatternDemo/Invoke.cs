using System;

namespace CommandPatternDemo
{
    internal class Invoke
    {
        private Command c;

        public Invoke(Command c)
        {
            this.c = c;
        }

        internal void ExecuteCommand()
        {            
            c.Action();
        }
    }
}