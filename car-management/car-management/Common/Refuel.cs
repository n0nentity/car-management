using System;

namespace car_management.Common
{
    public class Refuel
    {
        public DateTime Date { get; set; }

        public UInt64 Kilometers { get; set; }

        public double CostPerLiter { get; set; }

        public double Liter { get; set; }
    }
}