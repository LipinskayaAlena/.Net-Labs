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
            throw new NotImplementedException();
        }

        public override void PrepareConsole()
        {
            throw new NotImplementedException();
        }

        public override ConsoleColor GetColor(string nameColor)
        {
            throw new NotImplementedException();
        }

        public override Point GetPosition(string nameColor)
        {
            return new Point(34, 11);
        }
    }
}
