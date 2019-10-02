using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    public class ThirdClass : IDeliveryDriver
    {
        public double CalculateRate(int distance, double weight)
        {
            if (weight > 0 && weight <= 2)
            {
                double rate = 0.0020 * distance;
                return rate;
            }
            else if (weight > 2 && weight <= 8)
            {
                double rate = 0.0022 * distance;
                return rate;
            }
            else if (weight > 8 && weight < 16)
            {
                double rate = 0.0024 * distance;
                return rate;
            }
            else if (weight >= 16 && weight <= 48)
            {
                double rate = 0.0150 * distance;
                return rate;
            }
            else if (weight > 48 && weight <= 128)
            {
                double rate = 0.0160 * distance;
                return rate;
            }
            else if (weight > 128)
            {
                double rate = 0.0170 * distance;
                return rate;
            }
            else
            {
                Console.WriteLine("Invalid weight total");
                return 0.00;
            }
        }
        public override string ToString()
        {
            return "Postal Service (3rd Class)";
        }
    }
}
