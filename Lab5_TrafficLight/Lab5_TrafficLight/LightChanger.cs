﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_TrafficLight.controller
{
    public class LightChanger : EventArgs
    {
        public String ColorName {get; set;}
    }
}
