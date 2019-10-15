using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class KataPotter
    {
        public double GetCost(int[] books)
        {
            double sum = 0.0;
            double[] priceLevels = { 0, 8.0, 15.2, 21.6, 25.6, 30.0 };

            int[] basket = new int[5];
            for (int i = 0; i < books.Length; i++)
            {
                basket[books[i]]++;
            }

            while (sum > 0)
            {
                int booksInTheSet = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (basket[i] != 0)
                    {
                        basket[i]--;
                        booksInTheSet++;
                    }
                }

                // Its cheaper to get 2 sets of 4 than a set of 5 and a set of 3
                if (booksInTheSet == 5 && sum == 3 && !Contains(basket, 3))
                {
                    sum += priceLevels[4] * 2;
                    break;
                }

                sum += priceLevels[booksInTheSet];
            }

            return sum;
        }

        private bool Contains(int[] basket, int i)
        {
            foreach (int element in basket)
            {
                if (i == element)
                {
                    return true;
                }
            }
            return false;
        }

        private int Sum(int[] summer)
        {
            int sum = 0;
            foreach (int num in summer)
            {
                sum += num;
            }
            return sum;
        }
    }
}
