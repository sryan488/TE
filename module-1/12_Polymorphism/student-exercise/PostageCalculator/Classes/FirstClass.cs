using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    public class FirstClass : IDeliveryDriver
    {
        public double CalculateRate(int distance, double weight)
        {
            if (weight > 0 && weight <= 2)
            {
                double rate = 0.035 * distance;
                return rate;
            }
            else if (weight > 2 && weight <= 8)
            {
                double rate = 0.040 * distance;
                return rate;
            }
            else if (weight > 8 && weight < 16)
            {
                double rate = 0.047 * distance;
                return rate;
            }
            else if (weight >= 16 && weight <= 48)
            {
                double rate = 0.195 * distance;
                return rate;
            }
            else if (weight > 48 && weight <= 128)
            {
                double rate = 0.450 * distance;
                return rate;
            }
            else if (weight > 128)
            {
                double rate = 0.500 * distance;
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
            return "Postal Service (1st Class)";
        }
    }
}
