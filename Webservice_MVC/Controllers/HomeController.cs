using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Webservice_MVC.Models;

namespace Webservice_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<ActionResult> GetAlbums()
        {
            List<Album> AlbumInfo = new List<Album>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetDepartments using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("albums");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {

                    var ObjResponse = Res.Content.ReadAsStringAsync().Result;
                    AlbumInfo = JsonConvert.DeserializeObject<List<Album>>(ObjResponse);

                }
                //returning the student list to view  
                return View(AlbumInfo);
            }
        }
    }
}
