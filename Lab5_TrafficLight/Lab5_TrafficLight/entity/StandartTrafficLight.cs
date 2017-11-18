using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5_TrafficLight.controller;

namespace Lab5_TrafficLight.entity
{
    public class StandartTrafficLight : TrafficLightDrawer
    {
        public StandartTrafficLight(ITrafficLightController controller) : base(controller) { }

        public override Point GetPosition()
        {
            return new Point(30, 3);
        }
    }
}
