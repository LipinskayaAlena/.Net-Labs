using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Lab5_TrafficLight.entity;
using Lab5_TrafficLight.factory;

namespace Lab5_TrafficLight
{
    public class Program
    {
        static void Main(string[] args)
        {
            ITrafficLightFactory factory = new TrafficLightFactory();
            TrafficLight[] trafficLights = { new StandartTrafficLight(), new PedestrianTrafficLight(), new AdditionalTrafficLight() };
            var trafficLight = trafficLights.Select(tl => factory.Create(tl));

            /*Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(25, 0);
            Console.WriteLine(" ");

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(25, 1);
            Console.WriteLine(" ");

            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(25, 2);
            Console.WriteLine(" ");*/

            Console.ReadKey();
        }
        
    }
}
