using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_TrafficLight.entity
{
    public class StandartTrafficLight : TrafficLight
    {
        public override string GetType()
        {
            return "StandartTrafficLight";
        }
    }
}
