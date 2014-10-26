using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    interface IElevator
    {
        int MaxFloors { get; set; }

        int Goto(int Floor);

        bool Open();

        bool Close();

        void Alarm();

        int Stop();

    }
}
