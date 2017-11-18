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
            ITrafficLightController[] controllers = { new StandartTrafficLightController(), new PedestrianTrafficLightController(), new AdditionalTrafficLightController() };
            var trafficLights = controllers.Select(tl => factory.Create(tl));

            foreach (var trafficLight in trafficLights) {
                trafficLight.Start();
            }
            


            //Console.BackgroundColor = ConsoleColor.Red;//30 3
            //Point start = new Point(30, 3);
            //for(int i = 0; i < 3; i++)
            //{
            //    Console.SetCursorPosition(start.X, start.Y);
            //    Console.WriteLine("   ");
            //    start.Y++;
            //}

            //Console.BackgroundColor = ConsoleColor.Yellow;//30 6
            //for (int i = 0; i < 3; i++)
            //{
            //    Console.SetCursorPosition(start.X, start.Y);
            //    Console.WriteLine("   ");
            //    start.Y++;
            //}

            //Console.BackgroundColor = ConsoleColor.Green;//30 9
            //for (int i = 0; i < 3; i++)
            //{
            //    Console.SetCursorPosition(start.X, start.Y);
            //    Console.WriteLine("   ");
            //    start.Y++;
            //}


            //Console.BackgroundColor = ConsoleColor.Red;//35 11
            //Point pointAdditional = new Point(35, 11);
            //Console.SetCursorPosition(pointAdditional.X, pointAdditional.Y);
            //Console.WriteLine("-->");


            //Point pointPedestrian = new Point(40, 15);
            //Console.SetCursorPosition(pointPedestrian.X, pointPedestrian.Y);
            //Console.WriteLine("*");

            //pointPedestrian.X -= 35;
            //Console.SetCursorPosition(pointPedestrian.X, pointPedestrian.Y);
            //Console.WriteLine("*");

            Console.ReadKey();
        }
        
    }
}
