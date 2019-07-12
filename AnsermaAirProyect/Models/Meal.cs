using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnsermaAirProyect.Models
{
    public class Meal
    {
           
        public string Type { get; set; }
        public float Amount { get; set; }
        public Boolean HasDrink { get; set; }
        public int Quantity { get; set; }
        public float Weight { get; set; }
        public Boolean IsVegan { get; set; }
    
    }
}