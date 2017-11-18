using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5_TrafficLight.controller;

namespace Lab5_TrafficLight.drawer
{
    public class PedestrianTrafficLight : TrafficLightDrawer
    {
        public PedestrianTrafficLight(ITrafficLightController controller) : base(controller) { }

        public override void Draw(object sender, EventArgs e)
        {
            
            lock (ConsoleLocker)
            {
                PrepareConsole();
                String color = ((LightChanger)e).ColorName;
                Point point = GetPosition(color);
                Console.BackgroundColor = GetColor(color);
                Console.SetCursorPosition(point.X, point.Y);
                Console.WriteLine("*");

                Console.SetCursorPosition(point.X - 35, point.Y);
                Console.WriteLine("*");

            }
        }

        public override void PrepareConsole()
        {
            Console.CursorVisible = false;
        }

        public override ConsoleColor GetColor(string nameColor)
        {
            switch (nameColor)
            {
                case PedestrianTrafficLightController.RED_COLOR:
                    return ConsoleColor.Red;
                case PedestrianTrafficLightController.GREEN_COLOR:
                    return ConsoleColor.Green;
                default:
                    throw new ArgumentException();
            }

        }

        public override Point GetPosition(string nameColor)
        {
            return new Point(40, 15);
        }
    }
}
