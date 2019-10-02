using System;
using PostageCalculator.Classes;
using System.Collections.Generic;

namespace PostageCalculator
{
    class PostageCalculator
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the weight of package: ");
            int weight = int.Parse(Console.ReadLine());

            Console.Write("(P)ounds or (O)unces)? ");
            if (Console.ReadLine().ToLower() == "p")
            {
                weight = weight * 16;
            }

            Console.Write("What distance will it be traveling? ");
            int distance = int.Parse(Console.ReadLine());

            Console.WriteLine("\nDelivery Method \t\t $ cost");
            Console.WriteLine("---------------------------------------");

            List<IDeliveryDriver> drivers = new List<IDeliveryDriver>();

            drivers.Add(new FirstClass());
            drivers.Add(new SecondClass());
            drivers.Add(new ThirdClass());
            drivers.Add(new FexEd());
            drivers.Add(new SPUFourDayGround());
            drivers.Add(new SPUTwoDayBusiness());
            drivers.Add(new SPUNextDay());

            double totalCost = 0.00;

            foreach(IDeliveryDriver driver in drivers)
            {
                totalCost = driver.CalculateRate(distance, weight);
                Console.WriteLine($"{driver.ToString()}\t {totalCost:C}");
            }

            Console.ReadLine();
        }
    }
}
