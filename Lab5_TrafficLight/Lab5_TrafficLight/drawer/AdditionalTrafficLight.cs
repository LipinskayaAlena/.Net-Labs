using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5_TrafficLight.controller;

namespace Lab5_TrafficLight.drawer
{
    public class AdditionalTrafficLight : TrafficLightDrawer
    {
        public AdditionalTrafficLight(ITrafficLightController controller) : base(controller) { }

        public override void Draw(object sender, EventArgs e)
        {
            PrepareConsole();
            lock (ConsoleLocker)
            {
                String color = ((LightChanger)e).ColorName;
                Point point = GetPosition(color);
                Console.BackgroundColor = GetColor(color);

                Console.SetCursorPosition(point.X, point.Y);
            
                Console.WriteLine("-->");
            }
        }

        public override void PrepareConsole() { }
        

        public override ConsoleColor GetColor(string nameColor)
        {
            switch(nameColor)
            {
                case AdditionalTrafficLightController.GREEN_COLOR:
                    return ConsoleColor.Green;
                case AdditionalTrafficLightController.RED_COLOR:
                    return ConsoleColor.Red;
                default:
                    throw new ArgumentException();
            }
        }

        public override Point GetPosition(string nameColor)
        {
            if(nameColor.Equals(AdditionalTrafficLightController.GREEN_COLOR) || nameColor.Equals(AdditionalTrafficLightController.RED_COLOR))
                return new Point(34, 11);
            throw new ArgumentException();
        }
    }
}
