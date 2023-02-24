using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class HWController : Controller
    {
        Models.HW_DB db = new Models.HW_DB();
        // GET: HW
        public ActionResult Index()
        {
            ViewBag.getall = db.GetAll();
            ViewBag.find2 = db.Find(2);
            return View();
        }
    }
}