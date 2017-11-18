using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5_TrafficLight.drawer;

namespace Lab5_TrafficLight.controller
{
    public class AdditionalTrafficLightController : ITrafficLightController
    {
        public void TurnOn(ChangerLightEvent changerLightEvent)
        {

        }

        public new string GetType()
        {
            return "AdditionalTrafficLightController";
        }

    }
}
