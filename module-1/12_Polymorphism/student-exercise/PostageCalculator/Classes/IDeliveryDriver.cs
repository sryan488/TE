using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    interface IDeliveryDriver
    {
        double CalculateRate(int distance, double weight);
    }
}
