using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldDB.Models
{
    public class Language
    {        
        public string Name { get; set; }
        public bool IsOfficial { get; set; }
        public double Percentage { get; set; }
        public string CountryCode { get; set; }

        public override string ToString()
        {
            return $"{CountryCode, -4} {Name,-30} {(IsOfficial ? "Official" : "Unofficial"), 11} {(Percentage / 100.00), 7:P} ";
        }
        public static string GetHeader()
        {
            return $@"{"Code",-4} {"Name",-30} {"Official",11} {"%", 7}
{"----",-4} {"----",-30} {"--------",11} {"------",7}";
        }
    }
}
