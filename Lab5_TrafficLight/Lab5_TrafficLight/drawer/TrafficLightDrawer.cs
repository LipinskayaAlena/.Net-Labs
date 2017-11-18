using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Lab5_TrafficLight.controller;

namespace Lab5_TrafficLight.drawer
{
    public abstract class TrafficLightDrawer : ITrafficLightDrawer
    {
        public ConsoleColor defaultColor = ConsoleColor.Gray;

        public ITrafficLightController controller;

        public static readonly object ConsoleLocker = new object();

        public TrafficLightDrawer(ITrafficLightController controller)
        {
            this.controller = controller;
        }

        public abstract Point GetPosition(string nameColor);

        public abstract ConsoleColor GetColor(string nameColor);

        public abstract void Draw(object sender, EventArgs e);

        public abstract void PrepareConsole();

        public void Start()
        {
            ChangerLightEvent changer = new ChangerLightEvent();
            changer.Event += new EventHandler(Draw);
           
            controller.TurnOn(changer);
            
        }
    }
}
