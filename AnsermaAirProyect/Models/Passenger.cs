using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnsermaAirProyect.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public int flightId { get; set; }
        public Flight flight { get; set; }
        public List<Service> service { get; set; }
    }
}