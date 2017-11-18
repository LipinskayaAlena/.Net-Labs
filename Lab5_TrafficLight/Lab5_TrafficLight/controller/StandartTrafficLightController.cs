using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5_TrafficLight.controller;

namespace Lab5_TrafficLight.controller
{
    public class StandartTrafficLightController : ITrafficLightController
    {
        public const string RED_COLOR = "RED";

        public const string YELLOW_COLOR = "YELLOW";

        public const string GREEN_COLOR = "GREEN";
        
        public void TurnOn(ChangerLightEvent changerLightEvent)
        {
            changerLightEvent.SimulateEvent("RED");

            changerLightEvent.SimulateEvent("YELLOW");

            changerLightEvent.SimulateEvent("GREEN");
        }

        public new string GetType()
        {
            return "StandartTrafficLightController";
        }
    }
}
