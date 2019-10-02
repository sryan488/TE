using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    public class SPUFourDayGround : IDeliveryDriver
    {
        public double CalculateRate(int distance, double weight)
        {
            weight = weight / 16;
            double rate = (weight * 0.0050) * distance;
            return rate;
        }

            public override string ToString()
        {
            return "SPU (4-Day Ground)\t";
        }
    }
}
