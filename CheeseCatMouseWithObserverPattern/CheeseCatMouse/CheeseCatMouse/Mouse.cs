using System;

namespace CheeseCatMouse
{
    public class Mouse
    {
        private string myName;

        public string Name
        {
            get
            {
                return myName;
            }
            set
            {
                myName = value;
            }
        }

        //public Mouse( string name )
        //{
        //    myName = name;
        //}

        public void Run()
        {
            Console.WriteLine( "{0} Run,run, run.......", myName );
        }
    }
}