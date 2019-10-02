using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    public class SPUNextDay :IDeliveryDriver
    {
        public double CalculateRate(int distance, double weight)
        {
            weight = weight / 16;
            double rate = (weight * 0.075) * distance;
            return rate;
        }

        public override string ToString()
        {
            return "SPU (Next Day)\t\t";
        }
    }
}
