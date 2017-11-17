using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_TrafficLight.entity
{
    public class PedestrianTrafficLight : TrafficLight
    {
        public override string GetType()
        {
            return "PedestrianTrafficLight";
        }

        public override Point GetPosition()
        {
            return new Point(40, 15);
        }
    }
}
