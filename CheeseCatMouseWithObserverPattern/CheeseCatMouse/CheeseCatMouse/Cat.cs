using System;

namespace CheeseCatMouse
{
    public class Cat
    {
        public string Name { get; set; }

        public void Sleep()
        {
            Console.WriteLine( "Cat: ZZZ~~~~~" );
        }

        public void Wakeup()
        {
            Console.WriteLine( "Cat: What a nice dream, it's time to get up~~~" );
            if( Wakeuped == null )
            {
                return;
            }
            Wakeuped( this, new EventArgs() );
        }

        public event EventHandler Wakeuped;
    }
}