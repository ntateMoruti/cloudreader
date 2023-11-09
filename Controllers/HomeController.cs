using CloudReader.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace CloudReader.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string apikey = "fcf47359f06e40787bd541d2b5f9c3f2";
        static HttpClient HttpClient { get; set; }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public ActionResult CloudSearch(string searchStr)
        {
            ViewData["message"] = searchStr;
            if (searchStr.Equals(null))
            {
                ModelState.AddModelError("Error", "This field can't be blank");
                ViewBag.message = "[Empty search]";
                return View();
            }
            else
            {
                HttpWebRequest request = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q=" + searchStr + "&limit=1&units=metric&appid=" + apikey) as HttpWebRequest;
                string apiResponse = "";
                
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    apiResponse = reader.ReadToEnd();
                }
                var rootObject = JsonConvert.DeserializeObject<CurrentWeather>(apiResponse);

                return View(rootObject);
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}