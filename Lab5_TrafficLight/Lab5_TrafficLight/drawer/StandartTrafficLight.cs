using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5_TrafficLight.controller;

namespace Lab5_TrafficLight.drawer
{
    public class StandartTrafficLight : TrafficLightDrawer
    {
        public StandartTrafficLight(ITrafficLightController controller) : base(controller) { }

        public override Point GetPosition(string nameColor)
        {
            switch (nameColor)
            {
                case (StandartTrafficLightController.RED_COLOR):
                    return new Point(30, 3);
                case (StandartTrafficLightController.YELLOW_COLOR):
                    return new Point(30, 6);
                case (StandartTrafficLightController.GREEN_COLOR):
                    return new Point(30, 9);
                default:
                    throw new ArgumentException();
            }
        }

        public override ConsoleColor GetColor(string nameColor)
        {
            switch (nameColor)
            {
                case (StandartTrafficLightController.RED_COLOR):
                    return ConsoleColor.Red;
                case (StandartTrafficLightController.YELLOW_COLOR):
                    return ConsoleColor.Yellow;
                case (StandartTrafficLightController.GREEN_COLOR):
                    return ConsoleColor.Green;
                default:
                    throw new ArgumentException();
            }
        }

        public override void Draw(object sender, EventArgs e)
        {
            PrepareConsole();
            String color = ((LightChanger) e).ColorName;

            Point point = GetPosition(color);
            Console.BackgroundColor = GetColor(color);

            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(point.X, point.Y);
                Console.WriteLine("   ");
                point.Y++;
            }
        }

        public override void PrepareConsole()
        {
            Point[] points = new Point[] { GetPosition(StandartTrafficLightController.RED_COLOR),
                GetPosition(StandartTrafficLightController.YELLOW_COLOR),
                GetPosition(StandartTrafficLightController.GREEN_COLOR) };
            Console.BackgroundColor = defaultColor;
            
            points.ToList().ForEach(point =>
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.SetCursorPosition(point.X, point.Y);
                    Console.WriteLine("   ");
                    point.Y++;
                }
            });
                
            
        }
    }
}
