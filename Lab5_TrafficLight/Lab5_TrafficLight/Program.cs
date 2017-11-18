using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Lab5_TrafficLight;
using Lab5_TrafficLight.factory;
using Lab5_TrafficLight.controller;

namespace Lab5_TrafficLight
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            ITrafficLightFactory factory = new TrafficLightFactory();
            ITrafficLightController[] controllers = { new AdditionalTrafficLightController(), new StandartTrafficLightController(), new PedestrianTrafficLightController() };
            var trafficLights = controllers.Select(tl => factory.Create(tl));

            foreach (var trafficLight in trafficLights) {
                trafficLight.Start();
            }
            

            Console.ReadKey();
        }
        
    }
}
