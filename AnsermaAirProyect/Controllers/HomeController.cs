using AnsermaAirProyect.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AnsermaAirProyect.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public string GetMeals()
        {

            RestSharp.RestClient client = new RestClient("https://localhost:44361");


            RestSharp.RestRequest request = new RestRequest
            {

                Resource = "Api/Values",
                Method = RestSharp.Method.GET
            };

            var response = client.Execute(request);

            return response.Content;

        } 
        public ActionResult Index()
        {
            var meal = (JsonConvert.DeserializeObject<IEnumerable<Meal>>(GetMeals()));
            return View(meal);


            //ViewBag.Comidas = JsonConvert.DeserializeObject(GetMealsJson());
            //return View(JsonConvert.DeserializeObject<IEnumerable<Meal>>(GetMealsJson()));
            //var meal =(JsonConvert.DeserializeObject<IEnumerable<Meal>>(GetMeals()));
            //var meal =(JsonConvert.DeserializeObject<IEnumerable<Meal>>(GetMeals()));

        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}