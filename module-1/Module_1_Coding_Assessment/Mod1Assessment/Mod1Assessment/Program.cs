using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mod1Assessment
{
    class Program
    {
        static void Main(string[] args)
        {
            // This list only holds the Flower Shop Order data
            List<FlowerShopOrder> orders = new List<FlowerShopOrder>();

            using (StreamReader stream = new StreamReader("Data\\FlowerInput.csv"))
            {
                while (!stream.EndOfStream)
                { 
                    string line = stream.ReadLine();
                    string[] parts = line.Split(",");
                    FlowerShopOrder newOrder = new FlowerShopOrder(parts[0], Int32.Parse(parts[1]));
                    orders.Add(newOrder);
                }
            }
            decimal total = 0M;
            foreach (FlowerShopOrder order in orders)
            {
                total += order.Subtotal;
                Console.WriteLine(order.ToString());
            }
            Console.WriteLine($"Total for all orders is: {total}");

            Console.ReadLine();
        }
    }
}

