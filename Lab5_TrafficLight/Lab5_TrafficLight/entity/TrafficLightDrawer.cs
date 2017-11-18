using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Lab5_TrafficLight.controller;

namespace Lab5_TrafficLight.entity
{
    public abstract class TrafficLightDrawer : ITrafficLightDrawer
    {
        public ITrafficLightController controller;

        public TrafficLightDrawer(ITrafficLightController controller)
        {
            this.controller = controller;
        }

        public abstract Point GetPosition();

        public void Start()
        {
            
        }
    }
}
