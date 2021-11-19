using System;
using System.Collections.Generic;
using System.Text;

namespace Tracker
{
    public class Record
    {
        public int id { get; set; }
        public string dateTime { get; set; }
        public double Temp { get; set; }
        public double Hum { get; set; }
        public bool FanOn { get; set; }

        public Record(int id, string dateTime, double temp, double hum)
        {
            this.id = id;
            this.dateTime = dateTime;
            Temp = temp;
            Hum = hum;
            FanOn = false;
            if(temp > 25 || hum > 50)
            {
                FanOn = true;
            }
        }

    }
}
