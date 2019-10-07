using System;

namespace RomanNumeralsTDD
{
    public class RomanNumeral
    {
        public string ToRoman(int number)
        {
            #region Handle multiple (2 or 3) single-character numbers

            switch (number)
            {
                case 1:
                    return "I";
                case 5:
                    return "V";
                case 10:
                    return "X";
                case 50:
                    return "L";
                case 100:
                    return "C";
                case 500:
                    return "D";
                case 1000:
                    return "M";
                default:
                    return "";
            }
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