using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5_TrafficLight.drawer;
using Lab5_TrafficLight.controller;

namespace Lab5_TrafficLight.factory
{
    public class TrafficLightFactory : ITrafficLightFactory
    {

        public TrafficLightDrawer Create(ITrafficLightController trafficLight)
        {
            switch (trafficLight.GetType())
            {
                case nameof(StandartTrafficLightController):
                    return new StandartTrafficLight(trafficLight);
                case nameof(AdditionalTrafficLightController):
                    return new AdditionalTrafficLight(trafficLight);
                case nameof(PedestrianTrafficLightController):
                    return new PedestrianTrafficLight(trafficLight);
                default:
                    throw new NotSupportedException();

            }

        }
    }
}
