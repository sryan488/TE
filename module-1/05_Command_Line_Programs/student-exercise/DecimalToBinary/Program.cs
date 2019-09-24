using System;

namespace DecimalToBinary
{
    class Program
    { //Write a command line program which prompts the user for a series of decimal integer values separated by 
      //spaces. Each decimal integer is displayed along with its equivalent binary value.
      //Please enter in a series of decimal values (separated by spaces): 460 8218 1 31313 987654321
      //460 in binary is 111001100
      //8218 in binary is 10000000011010
      //1 in binary is 1
      //31313 in binary is 111101001010001
      //987654321 in binary is 111010110111100110100010110001
        static void Main(string[] args)
        {
            Console.Write("Please enter a series of decimal values (separated by spaces): ");
            string givenNums = Console.ReadLine();

            string[] strings = givenNums.Split(" ");

            }

        }
    }
}
