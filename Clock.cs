using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoobyDoo
{
    internal class Clock
    {
        //time in ms when the clock was created
        private DateTime create_time;
        public Clock() 
        {
            //set create time
            create_time = DateTime.Now;
        }

        public int GetLapTime()
        {
            //time right now - create time
            TimeSpan elapsedTime = DateTime.Now - create_time;
            return (int)elapsedTime.TotalMilliseconds;
        }
    }
}
