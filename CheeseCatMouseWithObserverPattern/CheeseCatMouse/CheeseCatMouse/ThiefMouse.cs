using System;

namespace CheeseCatMouse
{
    public class ThiefMouse : Mouse
    {
        private Cheese cheese = new Cheese( "MilkCheese" );
        //public ThiefMouse( string name ) : base( name ) {}

        private string myName;
        private GuardMouse myGuard;

        public ThiefMouse(string name, GuardMouse guard)
        {
            myName = name;
            myGuard = guard;
        }
        //public void Eating( string name )
        //{
        //    Console.WriteLine( "{0}: I am eating {1}", name, cheese.Type );
        //}

        //public void OnGuardMouseShouted( object obj, EventArgs e )
        //{
        //    GuardMouse guard = obj as GuardMouse;
        //    if( guard == null )
        //    {
        //        return;
        //    }
        //    Run();
        //}

        internal void Update()
        {
            Console.WriteLine("{0} {1} Run!!!",myGuard.GuardAction, myName);
        }
    }
}