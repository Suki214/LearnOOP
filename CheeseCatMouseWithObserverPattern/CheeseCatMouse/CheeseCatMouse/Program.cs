using System;
using System.Collections.Generic;

namespace CheeseCatMouse
{
    internal class Program
    {
        private static void Main( string[] args )
        {
            GuardMouse guard = new GuardMouse( "Guard Jack" );

            ThiefMouse thiefJerry = new ThiefMouse("Thief Jerry" ,guard);
            ThiefMouse thiefJohn = new ThiefMouse("Thief John" ,guard);
            ThiefMouse thiefJack = new ThiefMouse("Thief Jack" ,guard);

            var thiefs = new List<ThiefMouse>();
            thiefs.Add(thiefJerry);
            thiefs.Add(thiefJohn);
            thiefs.Add(thiefJack);

            Cat cat = new Cat();

            //cat.Wakeuped += guard.OnCatWakeuped;
            //guard.Shouted += thiefJerry.OnGuardMouseShouted;
            //guard.Shouted += thiefJohn.OnGuardMouseShouted;
            //thiefJerry.Eating(thiefJerry.Name);
            //thiefJohn.Eating(thiefJohn.Name);
            cat.Sleep();
            //guard.Watch();
            cat.Wakeup();

            foreach (ThiefMouse thief in thiefs)
            {
                guard.Attach(thief);
            }
            //guard.Attach(thiefJerry);
            //guard.Attach(thiefJohn);
            //guard.Attach(thiefJack);

            guard.GuardAction = "the cat is wake up!";
            guard.Notify();

            Console.ReadKey();
        }
    }
}