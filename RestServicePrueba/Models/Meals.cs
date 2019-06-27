using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestServicePrueba.Models
{
    public class Meals
    {
        public float Amount { get; set; }
        public string Type { get; set; }
        public bool HasDrink { get; set; }
        public float Weight { get; set; }
        public int Quantity { get; set; }
        public bool IsVegan { get; set; }

    }
}