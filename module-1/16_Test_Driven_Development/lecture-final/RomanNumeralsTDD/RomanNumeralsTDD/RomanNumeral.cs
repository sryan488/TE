﻿using System;

namespace RomanNumeralsTDD
{
    public class RomanNumeral
    {
        public string ToRoman(int number)
        {
            #region Handle multiple (2 or 3) single-character numbers



            string result = "";
            if (number < 5)
            {
                for (int i = 1; i <= number; i++)
                {
                    result += "I";
                }
            }
            else if (number < 10)
            {
                for (int i = 5; i <= number; i += 5)
                {
                    result += "V";
                }
            }
            else if (number < 50)
            {
                for (int i = 10; i <= number; i += 10)
                {
                    result += "X";
                }
            }
            else if (number < 100)
            {
                for (int i = 50; i <= number; i += 50)
                {
                    result += "L";
                }
            }
            else if (number < 500)
            {
                for (int i = 100; i <= number; i += 100)
                {
                    result += "C";
                }
            }
            else if (number < 1000)
            {
                for (int i = 500; i <= number; i += 500)
                {
                    result += "D";
                }
            }
            else  // number >= 1000
            {
                for (int i = 1000; i <= number; i += 1000)
                {
                    result += "M";
                }
            }

            return result;
            #endregion

            #region Satisfy all single-character numbers

            //switch (number)
            //{
            //    case 1:
            //        return "I";
            //    case 5:
            //        return "V";
            //    case 10:
            //        return "X";
            //    case 50:
            //        return "L";
            //    case 100:
            //        return "C";
            //    case 500:
            //        return "D";
            //    case 1000:
            //        return "M";
            //    default:
            //        return "";
            //}
            #endregion

            #region Satisfy 1 and 5
            //if (number == 5)
            //{
            //    return "V";
            //}
            //return "I";
            #endregion

            #region V1: Return value for 1
            //return "I";
            #endregion

        }
    }
}