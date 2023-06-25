using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.UI;

namespace lab5b.Controllers
{
    //объект cach типа Dictionary
    public class CHResearchController : Controller
    {
        // GET: CHResearch
        public ActionResult Index()
        {
            return View();
        }
        static int x = 9;
        [OutputCache(Duration = 5, Location = OutputCacheLocation.ServerAndClient), HttpGet] //OutputCacheLocation - это перечисление (enum) в языке C#, которое определяет местоположение, в котором хранится кэш вывода.
        public ActionResult AD()
        {
            x++;
            string t = DateTime.Now.ToLongTimeString();
            return Content($"GET:/AD:{t} \n {x}");
        }

        [OutputCache(Duration = 7, VaryByParam = "x;y"), HttpPost]  //это атрибут для настройки кэширования содержимого страницы на основе параметров запроса
        public ActionResult AP(string x, string y)
        {
            string t = DateTime.Now.ToLongTimeString();
            return Content($"POST:/AP:{t}:{x}:{y}");
        }
    }
}