using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldDB.Models
{
    public class Country
    {
        // TODO: The country table has some NULLable columns. We have to define these with C# nullable data types.
        //      These are the ones below that contain ? (int?, double?, decimal?) These data types have a Value
        //      property (int, double, decimal), and a HasValue(bool) property. They can also be compared to null.
        public string Code { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string Region { get; set; }
        public double SurfaceArea { get; set; }
        public int? IndependenceYear { get; set; }
        public int? Population { get; set; }
        public double? LifeExpectancy { get; set; } //<-- nullable property, it can have a value that is a double or NULL if there is no value
        public decimal? GNP { get; set; } //<-- nullable property, it can have a value that is a decimal or NULL if there is no value
        public decimal? GNPOld { get; set; } //<-- nullable property, it can have a value that is a decimal or NULL if there is no value
        public string LocalName { get; set; }
        public string GovernmentForm { get; set; }
        public string HeadOfState { get; set; }
        public int? CapitalId { get; set; } //<-- nullable property, it can have a value that is a int or NULL if there is no value
        public string CapitalName { get; set; }
        public string Code2 { get; set; }

        public override string ToString()
        {
            return $"{Code,-4} {Name,-40} {Continent,-30}";
            //return Code.PadRight(5) + Name.PadRight(20) + Continent.PadRight(30) + SurfaceArea.ToString("N2").PadRight(10) + Population.ToString("N0").PadRight(15) + GovernmentForm.PadRight(30);
        }
        public static string GetHeader()
        {
            return $@"{"Code",-4} {"Name",-40} {"Continent",-30}
{"----",-4} {"----",-40} {"---------",-30}";

        }
    }
}
