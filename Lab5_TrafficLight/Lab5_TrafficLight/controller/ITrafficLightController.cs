using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab5_TrafficLight.controller
{
    public interface ITrafficLightController
    {
        void TurnOn(ChangerLightEvent changerLightEvent);
        String GetType();
    }
}
