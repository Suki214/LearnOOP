using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeDesignPatternDemo
{
    public class SecurityFacade
    {
        private static Camera camera1, camera2;
        private static Light light1, light2, light3;
        private static Alarm alarm1, alarm2;

        static SecurityFacade()
        {
            camera1 = new Camera();
            camera2 = new Camera();
            light1 = new Light();
            light2 = new Light();
            light3 = new Light();
            alarm1 = new Alarm();
            alarm2 = new Alarm();
        }
        public void Active()
        {
            camera1.TurnOn();
            camera2.TurnOn();
            light1.TurnOn();
            light2.TurnOn();
            light3.TurnOn();
            alarm1.Activate();
            alarm2.Activate();
        }

        public void Deactive()
        {
            camera1.TurnOff();
            camera2.TurnOff();
            light1.TurnOff();
            light2.TurnOff();
            light3.TurnOff();
            alarm1.Deactivate();
            alarm2.Deactivate();
        }
    }
}
