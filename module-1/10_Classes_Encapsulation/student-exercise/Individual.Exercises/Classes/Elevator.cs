using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class Elevator
    {
       public int CurrentLevel { get; private set; }
       public int NumberOfLevels { get; }
       public bool DoorIsOpen { get; private set; }

        public Elevator(int numberOfLevels)
        {
            this.NumberOfLevels = numberOfLevels;
            CurrentLevel = 1;
        }
        public void OpenDoor()
        {
            DoorIsOpen = true;
        }
        public void CloseDoor()
        {
            DoorIsOpen = false;
        }
        public void GoUp(int desiredFloor)
        {
            if (DoorIsOpen == false)
            {
                if (desiredFloor > CurrentLevel && desiredFloor <= NumberOfLevels)
                {
                    CurrentLevel = desiredFloor;
                }
            }
        }
        public void GoDown(int desiredFloor)
        {
            if (DoorIsOpen == false)
            {
                if (desiredFloor < CurrentLevel && desiredFloor >= 1)
                {
                    CurrentLevel = desiredFloor;
                }
            }
        }

    }

}
