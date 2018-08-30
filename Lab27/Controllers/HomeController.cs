using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Lab27.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HttpWebRequest apiRequest =
            WebRequest.CreateHttp("https://forecast.weather.gov/MapClick.php?lat=38.4247341&lon=-86.9624086&FcstType=json");
            apiRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";

            HttpWebResponse apiResponse = (HttpWebResponse)apiRequest.GetResponse();
            if (apiResponse.StatusCode == HttpStatusCode.OK)// if we got a status ==200 
            {
                // get the data and then parse it 
                StreamReader responseData = new StreamReader(apiResponse.GetResponseStream());

                string weather = responseData.ReadToEnd();// reads the data from the response 

                // ToDo: parse the Json data
                JObject jsonWeather = JObject.Parse(weather);

                ViewBag.weatherText = jsonWeather["data"]["text"];
                ViewBag.weather = jsonWeather["data"]["weather"];
            }

            return View();
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