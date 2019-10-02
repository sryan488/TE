using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator.Classes
{
    class Truck : IVehicle
    {
        public int NumberOfAxles { get; }

        public Truck(int numberOfAxles)
        {
            this.NumberOfAxles = numberOfAxles;
        }

        public double CalculateToll(int distance)
        {
            if (NumberOfAxles == 4)
            {
                return (0.040 * distance);
            }
            if (NumberOfAxles == 6)
            {
                return (0.045 * distance);
            }
            else
            {
                return (0.048 * distance);
            }
        }
        public override string ToString()
        {
            return "Truck ("+NumberOfAxles +" Axels)   ";
        }
    }
}

