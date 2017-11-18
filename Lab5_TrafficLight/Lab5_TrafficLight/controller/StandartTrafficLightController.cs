using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Lab5_TrafficLight.controller;

namespace Lab5_TrafficLight.controller
{
    public class StandartTrafficLightController : ITrafficLightController
    {
        public const string RED_COLOR = "RED";

        public const string YELLOW_COLOR = "YELLOW";

        public const string GREEN_COLOR = "GREEN";

        private LinkedList<string> lights = new LinkedList<string>(new string[] { RED_COLOR, YELLOW_COLOR, GREEN_COLOR });
        private LinkedListNode<string> current_light;

        private bool isEnabled;
        public void TurnOn(ChangerLightEvent changerLightEvent)
        {
            Timer timer = new Timer(2000);
            isEnabled = true;

            current_light = lights.First;
            timer.Elapsed += (sender, e) => SwitchLight(sender, e, changerLightEvent);
            
            timer.Start();
        }

        private void SwitchLight(object source, ElapsedEventArgs e, ChangerLightEvent changerLightEvent )
        {
            changerLightEvent.SimulateEvent(current_light.Value);
            if(isEnabled && current_light.Next != null)
            {
                current_light = current_light.Next;
            } else if(!isEnabled && current_light.Previous != null)
            {
                current_light = current_light.Previous;
            } else
            {
                isEnabled = !(isEnabled);
            }
        }

        public new string GetType()
        {
            return "StandartTrafficLightController";
        }
    }
}
