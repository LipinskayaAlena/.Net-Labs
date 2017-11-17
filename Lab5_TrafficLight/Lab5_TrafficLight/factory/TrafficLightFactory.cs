using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5_TrafficLight.entity;

namespace Lab5_TrafficLight.factory
{
    public class TrafficLightFactory : ITrafficLightFactory
    {

        public TrafficLight Create(TrafficLight trafficLight)
        {
            switch (trafficLight.GetType())
            {
                case nameof(StandartTrafficLight):
                    return new StandartTrafficLight();
                case nameof(AdditionalTrafficLight):
                    return new AdditionalTrafficLight();
                case nameof(PedestrianTrafficLight):
                    return new PedestrianTrafficLight();
                default:
                    throw new NotSupportedException();

            }

        }
    }
}
