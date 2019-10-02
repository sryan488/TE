using System;
using System.Collections.Generic;
using TollBoothCalculator.Classes;

namespace TollBoothCalculator
{
    public class TollCalculator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nVehicle\t   Distance Traveled\t$ cost");
            Console.WriteLine("---------------------------------------");

            List<IVehicle> vehicles = new List<IVehicle>();

            vehicles.Add(new Car(false));

            vehicles.Add(new Car(true));

            vehicles.Add(new Tank());

            vehicles.Add(new Truck(4));

            vehicles.Add(new Truck(6));

            vehicles.Add(new Truck(8));

            Random rand = new Random();

            int totalMiles = 0;
            double totalTolls = 0;
            foreach (IVehicle vehicle in vehicles)
            {
                int distance = rand.Next(10, 240);
                double toll = vehicle.CalculateToll(distance);
                totalMiles += distance;
                totalTolls += toll;
                Console.WriteLine($"{vehicle}   {distance}     \t{toll:C}");
            }
            Console.WriteLine("");
            Console.WriteLine($"Total Miles Traveled: {totalMiles}");
            Console.WriteLine($"Total Tollboth Revenue: {totalTolls:C}");

            Console.ReadLine();
        }
    }
}
