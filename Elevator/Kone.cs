using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    class Kone : IElevator
    {
        private int currentFloor;
        private int maxfloors;
        private bool isOpen;
        private bool alarmOn;

        public Kone(int maxFloor)
        {
            MaxFloors = maxFloor;
            CurrentFloor = 1;
            IsOpen = false;
            AlarmOn = false; 

        }


        public bool AlarmOn
        {
            get
            {
                return alarmOn;
            }
            set
            {
                alarmOn = value;
            }
        }

        public bool IsOpen
        {
            get
            {
                return isOpen;
            }
            set
            {
                isOpen = value;
            }
        }

        public int CurrentFloor
        {
            get
            {
                return currentFloor;
            }
            set
            {
                currentFloor = value;
            }
        }

        public int MaxFloors
        {
            get
            {
                return maxfloors;
            }
            set
            {
                maxfloors = value;
            }
        }

        public int Goto(int Floor)
        {
            if ((Floor < 1) || Floor > MaxFloors)
            {
                return -1;
            }
            else
            {
                this.Close(); 
                CurrentFloor = Floor;
                return CurrentFloor;
            }
        }

        public bool Open()
        {
            IsOpen = true;
            return true;
        }

        public bool Close()
        {
            IsOpen = false;
            return true; 
        }

        public void Alarm()
        {
            AlarmOn = true;
        }

        public int Stop()
        {
            return CurrentFloor; 
        }
    }
}
