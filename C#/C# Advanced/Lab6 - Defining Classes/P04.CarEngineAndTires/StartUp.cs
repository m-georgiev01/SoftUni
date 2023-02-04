﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            var tires = new Tire[4]
            {
                new Tire(1, 2.5),
                new Tire(1, 2.1),
                new Tire(2, 0.5),
                new Tire(2, 2.5),
            };

            Engine engine = new(560, 6300);

            Car car = new("Lamborghini", "Urus", 2010, 250, 9, engine, tires);
        }
    }
}
