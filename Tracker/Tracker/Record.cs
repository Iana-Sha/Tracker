using System;
using System.Collections.Generic;
using System.Text;

namespace Tracker
{
    public class Record
    {
        //"[{\"hum\":43.0,\"id\":322,\"temp\":26.0,\"time\":\"Wed, 15 Dec 2021 22:07:53 GMT\"}]\n"
        
public int id { get; set; }
        public string time { get; set; }
        public double temp { get; set; }
        public double hum { get; set; }
        public bool FanOn { get; set; }

        public Record(double hum, int id, double temp, string dateTime)
        {
            this.id = id;
            this.time = dateTime;
            this.temp = temp;
            this.hum = hum;
            FanOn = false;
            if(temp > 25 || hum > 50)
            {
                FanOn = true;
            }
        }

    }
}
