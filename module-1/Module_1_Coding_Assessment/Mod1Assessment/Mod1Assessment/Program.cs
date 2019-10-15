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

            //FlowerShopOrder flowerShopOrder = new FlowerShopOrder("difBouquet", 12);
            //Console.WriteLine(flowerShopOrder.Subtotal);


            //string path = @"..\\..\\..\\..\\FlowerInput.csv";

            List<FlowerShopOrder> orders = new List<FlowerShopOrder>();
            //{
            //    new FlowerShopOrder("Basic", 0),
            //    new FlowerShopOrder("Elite", 12),
            //    new FlowerShopOrder("Elegant", 24),
            //    new FlowerShopOrder("Apology", 48),
            //    new FlowerShopOrder("Nuptial", 18),
            //    new FlowerShopOrder("Bereavement", 12)
            //};
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
                Console.WriteLine(order.ToString());// + " " + order.GrandTotal(true, "20000"));
            }
            Console.WriteLine($"Total for all orders is: {total}");


            Console.ReadLine();
        }
    }

}

