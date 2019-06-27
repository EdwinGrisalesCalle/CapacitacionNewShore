using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnsermaAirProyect.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public DateTime departureDateTime { get; set; }
        public string departureStation { get; set; }
        public string arrivalStation { get; set; }
        public List<Passenger> passengers { get; set; }
    }
}