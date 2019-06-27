using RestServicePrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestServicePrueba.Controllers
{
    public class ValuesController : ApiController
    {
        static List<Meals> meals= new List<Meals>();
        
        public ValuesController()
        {
            meals.Add(new Meals
            {
                Amount = 30000,
                Type = "Italiana",
                HasDrink = true,
                IsVegan = false,
                Quantity = 3,
                Weight = 180
            });
            meals.Add(new Meals
            {
                Amount = 50000,
                Type = "Mexicana",
                HasDrink = false,
                IsVegan = false,
                Quantity = 2,
                Weight = 190
            });
            meals.Add(new Meals
            {
                Amount = 40000,
                Type = "Colombiana",
                HasDrink = true,
                IsVegan = false,
                Quantity = 1,
                Weight = 150
            });
        }

        // GET api/values
        public IEnumerable<Meals> Get()
        {
            return meals;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "valor ingresado "+ id;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
