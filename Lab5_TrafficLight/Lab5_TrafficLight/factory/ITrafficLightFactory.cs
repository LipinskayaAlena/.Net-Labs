using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5_TrafficLight.entity;
using Lab5_TrafficLight.controller;

namespace Lab5_TrafficLight.factory
{
    public interface ITrafficLightFactory
    {
        ITrafficLightController Create(TrafficLight trafficLight);
    }
}
