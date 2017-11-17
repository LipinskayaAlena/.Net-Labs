using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5_TrafficLight.entity;

namespace Lab5_TrafficLight.factory
{
    public interface ITrafficLightFactory
    {
        TrafficLight Create(TrafficLight trafficLight);
    }
}
