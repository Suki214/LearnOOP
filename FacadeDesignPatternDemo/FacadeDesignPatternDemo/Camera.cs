using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeDesignPatternDemo
{
    public class Camera
    {
        public void TurnOn()
        {
            Console.WriteLine("Turn on Camera");
        }

        public void TurnOff()
        {
            Console.WriteLine("Turn off Camera");
        }

        public void Rotate(int degrees)
        {
            Console.WriteLine("Rotating the camera by {0} degrees.", degrees);
        }
    }
}
