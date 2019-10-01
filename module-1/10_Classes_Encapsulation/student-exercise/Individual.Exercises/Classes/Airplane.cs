using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class Airplane
    {
        public string PlaneNumber { get; }
        public int BookedFirstClassSeats { get; private set; }
        public int AvailableFirstClassSeats
        {
            get
            {
                return TotalFirstClassSeats - BookedFirstClassSeats;
            }
        }       
        public int TotalFirstClassSeats {get; }
        public int BookedCoachSeats { get; private set; }
        public int AvailableCoachSeats
        {
            get
            {
                return TotalCoachSeats - BookedCoachSeats;
            }
        }
        public int TotalCoachSeats { get; }

        public Airplane(string planeNumber, int totalFirstClassSeats, int totalCoachSets)
        {
            this.PlaneNumber = planeNumber;
            this.TotalFirstClassSeats = totalFirstClassSeats;
            this.TotalCoachSeats = totalCoachSets;
        }
        public bool ReserveSeats(bool forFirstClass, int totalNumberOfSeats)
        {
            if (forFirstClass &&  totalNumberOfSeats <= AvailableFirstClassSeats)
            {
                BookedFirstClassSeats = totalNumberOfSeats + BookedFirstClassSeats;
                return true;
            }
            if (!forFirstClass && totalNumberOfSeats <= AvailableCoachSeats)
            {
                BookedCoachSeats = totalNumberOfSeats + BookedCoachSeats;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
