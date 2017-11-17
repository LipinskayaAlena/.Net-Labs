using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5_TrafficLight.entity;
using Lab5_TrafficLight.controller;

namespace Lab5_TrafficLight.factory
{
    public class TrafficLightFactory : ITrafficLightFactory
    {

        public ITrafficLightController Create(TrafficLight trafficLight)
        {
            switch (trafficLight.GetType())
            {
                case nameof(StandartTrafficLight):
                    return new StandartTrafficLightController();
                case nameof(AdditionalTrafficLight):
                    return new AdditionalTrafficLightController();
                case nameof(PedestrianTrafficLight):
                    return new PedestrianTrafficLightController();
                default:
                    throw new NotSupportedException();

            }

        }
    }
}
