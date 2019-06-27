using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnsermaAirProyect.Models
{
    public class Service
    {
        public int Id { get; set; }
        public float price { get; set; }
        public int passengerId { get; set; }
        public Passenger passenger { get; set; }
    }
}