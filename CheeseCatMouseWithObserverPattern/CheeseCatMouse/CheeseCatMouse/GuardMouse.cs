using System;
using System.Collections.Generic;

namespace CheeseCatMouse
{
    public class GuardMouse : Mouse
    {
        // public GuardMouse( string name ) : base( name ) {}
        private string myName;
        public GuardMouse(string name)
        {
            myName = name;
        }

        private IList<ThiefMouse> thiefs = new List<ThiefMouse>();
        private string action;

        public void Attach(ThiefMouse thief)
        {
            thiefs.Add(thief);
        }

        public void Notify()
        {
            foreach (ThiefMouse thief in thiefs)
            {
                thief.Update();
            }
        }

        public string GuardAction
        {
            get
            {
                return action;
            }
            set
            {
                action = value;
            }
        }
        //public void Watch()
        //{
        //    Console.WriteLine( "{0}: The cat is now sleeping, eat hurry up....", this.Name );
        //}

        //public void Shout()
        //{
        //    Console.WriteLine( "{0}: The Cat is wake up!!!", this.Name );
        //    if( Shouted == null )
        //    {
        //        return;
        //    }
        //    Shouted( this, null );
        //}

        //public event EventHandler Shouted;

        //public void OnCatWakeuped( object obj, EventArgs e )
        //{
        //    Cat cat = obj as Cat;
        //    if( cat == null )
        //    {
        //        return;
        //    }
        //    Shout();
        //    Run();
        //}
    }
}