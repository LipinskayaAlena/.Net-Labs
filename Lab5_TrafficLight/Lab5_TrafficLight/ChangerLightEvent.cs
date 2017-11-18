using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_TrafficLight.controller
{
    public class ChangerLightEvent
    {

        public event EventHandler Event;

        protected virtual void OnEvent(EventArgs args)
        {
            if (Event != null)
                Event(this, args);
        }

        public void SimulateEvent(String color)
        {
            LightChanger args = new LightChanger();
            args.ColorName = color;
            
            OnEvent(args);
        }
    }
}
