using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Mod1Assessment
{
    public class FlowerShopOrder
    {
        public string BouquetType { get; }
        public int NumberOfRoses { get; }
        public decimal Subtotal
        {
            get
            {
                return 19.99M + (2.99M * NumberOfRoses);
            }
        }

        // Creating parameters to be used
        public FlowerShopOrder(string bouquetType, int numberOfRoses)
        {
            this.BouquetType = bouquetType;
            this.NumberOfRoses = numberOfRoses;
        }

        public decimal GrandTotal(bool sameDayDelivery, string zipCode)
        {
            decimal deliveryFee = 0M;

            if ((zipCode.CompareTo("20000") >= 0) && (zipCode.CompareTo("29999") <= 0))
            {
                deliveryFee = 3.99M;
                if (sameDayDelivery == true)
                {
                    deliveryFee = deliveryFee + 5.99M;
                }
            }
            else if ((zipCode.CompareTo("30000") >= 0) && (zipCode.CompareTo("39999") <= 0))
            {
                deliveryFee = 6.99M;
                if (sameDayDelivery == true)
                {
                    deliveryFee = deliveryFee + 5.99M;
                }
            }
            else if ((zipCode.CompareTo("10000") >= 0) && (zipCode.CompareTo("19999") <= 0))
            {
                deliveryFee = 0.00M;
            }
            else
            {
                deliveryFee = 19.99M;
            }
            return deliveryFee;

        }
        public override string ToString()
        {
            return $"ORDER - {BouquetType} - {NumberOfRoses} roses - {Subtotal}";
        }

    }
}
