using System;
using System.Collections.Generic;
using System.Text;

namespace Mod1Assessment
{
    public class HotelReservation
    {
        public string Name { get; }
        public int NumberOfNights { get; }
        public decimal EstimatedTotal
        {
            get
            {
                return 59.99M * NumberOfNights;
            }
        }

        // Create parameters to be used
        public HotelReservation(string name, int numberOfNights)
        {
            this.Name = name;
            this.NumberOfNights = numberOfNights;
        }

        public decimal AdditionalFees(bool requiresCleaning, bool usedMinibar)
        { decimal additionalFees = 0M;

            if (usedMinibar == true)
            {
                additionalFees = 12.99M;
                if(requiresCleaning == true)
                {
                    additionalFees = additionalFees + (34.99M * 2);
                }
            }
            else if (requiresCleaning == true)
            {
                additionalFees = 34.99M;
            }
            else if (usedMinibar == true)
            {
                additionalFees = 12.99M;   
            }
            else
            {
                additionalFees = 0M;
            }
                return additionalFees;
        }
        public override string ToString()
        {
            return $"RESERVATION - {Name} - {EstimatedTotal}";
        }
    }
}
