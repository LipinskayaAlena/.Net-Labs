using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5_TrafficLight.controller;

namespace Lab5_TrafficLight.entity
{
    public class PedestrianTrafficLight : TrafficLightDrawer
    {
        public PedestrianTrafficLight(ITrafficLightController controller) : base(controller) { }

        public override Point GetPosition()
        {
            return new Point(40, 15);
        }
    }
}
