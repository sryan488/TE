using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator.Classes
{
    class Car : IVehicle
    {
        public bool HasTrailer { get; }

        public Car(bool hasTrailer)
        {
            this.HasTrailer = hasTrailer;
        }

        public double CalculateToll(int distance)
        {
            double toll = distance * 0.020;
            if (HasTrailer == true)
            {
                return toll + 1.00;
            }
            else
            {
                return toll;
            }
        }
        public override string ToString()
        {
            if (HasTrailer == true)
            {
                return "Car (with Trailor)";
            }
            else
            {
                return "Car\t\t  ";
            }
        }
    }
}
