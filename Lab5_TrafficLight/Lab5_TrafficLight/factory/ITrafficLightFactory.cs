﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5_TrafficLight.drawer;
using Lab5_TrafficLight.controller;

namespace Lab5_TrafficLight.factory
{
    public interface ITrafficLightFactory
    {
        TrafficLightDrawer Create(ITrafficLightController trafficLight);
    }
}
