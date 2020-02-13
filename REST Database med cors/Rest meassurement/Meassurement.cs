using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockExam3WebApi.Models
{
    public class Meassurement
    {
        public int Id { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int Temperature { get; set; }
        public DateTime TimeStamp { get; set; }

        public Meassurement()
        {
            
        }

        public Meassurement(int id, int pressure, int humidity, int temperature, DateTime timeStamp)
        {
            Id = id;
            Pressure = pressure;
            Humidity = humidity;
            Temperature = temperature;
            TimeStamp = timeStamp;
        }
    }
}
