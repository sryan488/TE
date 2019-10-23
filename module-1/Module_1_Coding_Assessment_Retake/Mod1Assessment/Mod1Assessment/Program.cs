using System;
using System.Collections.Generic;
using System.IO;

namespace Mod1Assessment
{
    class Program
    {
        static void Main(string[] args)
        {
            List<HotelReservation> reservations = new List<HotelReservation>();

            using (StreamReader stream = new StreamReader("Data\\HotelInput.csv"))
            {
                while (!stream.EndOfStream)
                {
                    string line = stream.ReadLine();
                    string[] array = line.Split(",");
                    HotelReservation newReservation = new HotelReservation(array[0], Int32.Parse(array[1]));
                    reservations.Add(newReservation);
                }
            }
            decimal total = 0M;
            foreach (HotelReservation reservation in reservations)
            {
                total += reservation.EstimatedTotal;
                Console.WriteLine(reservation.ToString());
            }
            Console.WriteLine($"Total for all reservations is: {total}");

            Console.ReadLine();
        }
    }
}
