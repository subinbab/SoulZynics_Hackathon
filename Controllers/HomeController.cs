using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoulZynics.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SoulZynics.Controllers
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
           /* HttpClient client1 = new HttpClient();
            var response = client1.GetStringAsync("https://affiliate-api.flipkart.net/affiliate/1.0/search.json?query=sony+mobiles&resultCount=5").Result;*/

            HtmlWeb client = new HtmlWeb();
            HtmlDocument doc = client.Load("https://www.amazon.in/s?k=samasung+winterfall+blue");
            /*List<HtmlNodeCollection> node1 = doc.DocumentNode.Elements("//a[contains(@class, 'a-link-normal s-no-outline')]").ToList();*/
            HtmlNodeCollection Nodes = doc.DocumentNode.SelectNodes("//a[contains(@class, 'a-link-normal s-no-outline')]");
            List<string> nodes = new List<string>();
            List<string> tags = new List<string>();
            HtmlNodeCollection reviewNum = null;

            nodes.Add(Nodes[10].Attributes["href"].Value);
                HtmlWeb client1 = new HtmlWeb();
                HtmlDocument docChild = client1.Load("https://www.amazon.in"+ Nodes[10].Attributes["href"].Value);
                    reviewNum = doc.DocumentNode.SelectNodes("//i[contains(@class, 'a-icon a-icon-star a-star-4')]");
                if(reviewNum != null)
                {
                    tags.Add(reviewNum[0].InnerHtml.ToString());
                }
                
                //HtmlDocument docChild = client.Load("https://www.amazon.in/"+ link.Attributes["href"].Value);
               
            
            ViewData["links"] = nodes;
            if (reviewNum != null)
            {
                ViewData["reviews"] = tags[0];
            }
                
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
    }
}
