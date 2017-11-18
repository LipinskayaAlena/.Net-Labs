using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Lab5_TrafficLight.controller
{
    public class PedestrianTrafficLightController : ITrafficLightController
    {
        public const string GREEN_COLOR = "GREEN";
        public const string RED_COLOR = "RED";

        private bool isEnabled;

        public void TurnOn(ChangerLightEvent changerLightEvent)
        {
            Timer timer = new Timer(6000);
            timer.Elapsed += (sender, e) => SwitchLight(sender, e, changerLightEvent);
            isEnabled = true;
            timer.Start();
        }

        private void SwitchLight(object source, ElapsedEventArgs e, ChangerLightEvent changerLightEvent)
        {
            if (isEnabled)
                changerLightEvent.SimulateEvent(RED_COLOR);
            else
                changerLightEvent.SimulateEvent(GREEN_COLOR);
            isEnabled = !(isEnabled);
        }

        public new string GetType()
        {
            return "PedestrianTrafficLightController";
        }
    }
}
