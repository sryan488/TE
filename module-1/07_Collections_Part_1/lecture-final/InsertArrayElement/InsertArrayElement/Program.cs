using System;

namespace InsertArrayElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 2, 4, 6, 8 };

            Console.WriteLine($"Original array: {string.Join(',', array)}");

            // Insert 100 at the beginning
            array = InsertElement(array, 100, -1);
            Console.WriteLine($"Updated array: {string.Join(',', array)}");

            // Insert 200 somewhere in the middle
            array = InsertElement(array, 200, 2);
            Console.WriteLine($"Updated array: {string.Join(',', array)}");

            // Insert 300 at the end
            array = InsertElement(array, 300, 999);
            Console.WriteLine($"Updated array: {string.Join(',', array)}");


            Console.ReadLine();
        }

        static int[] InsertElement(int[] originalArray, int newElement, int afterIndex)
        {
            // If the element is to be inserted at the beginning, a negative index is sent.
            // We'll change any negative index to -1 for consistency.
            if (afterIndex < 0)
            {
                afterIndex = -1;
            }
            // If afterIndex is greater than the length of the array, it will be placed at the end.  
            // We'll make sure the index reflects the proper location.
            if (afterIndex >= originalArray.Length)
            {
                afterIndex = originalArray.Length - 1;
            }

                // Create a new array one larger than the previous one
                int[] newArray = new int[originalArray.Length + 1];

            // Add all elements up to and including afterIndex to the new array
            for (int i = 0; i <= afterIndex && i < originalArray.Length; i++)
            {
                newArray[i] = originalArray[i];
            }

            // Now add the new element to newArray
            newArray[afterIndex + 1] = newElement;

            // Now add on the remainder of the original array
            for (int i = afterIndex + 1; i < originalArray.Length; i++)
            {
                newArray[i + 1] = originalArray[i];
            }

            return newArray;
        }
    }
}
