using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    public class SPUTwoDayBusiness :IDeliveryDriver
    {
        public double CalculateRate(int distance, double weight)
        {
            weight = weight / 16;
            double rate = (weight * 0.050) * distance;
            return rate;
        }

        public override string ToString()
        {
            return "SPU (2-Day Business)\t";
        }
    }
}
