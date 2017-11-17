using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab5_TrafficLight.entity
{
    public abstract class TrafficLight
    {
        
        public abstract new string GetType();

        public abstract Point GetPosition();

    }
}
