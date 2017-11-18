using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_TrafficLight.controller
{
    public class PedestrianTrafficLightController : ITrafficLightController
    {

        public string GetType()
        {
            return "PedestrianTrafficLightController";
        }
    }
}
