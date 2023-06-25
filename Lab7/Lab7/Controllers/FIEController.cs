using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab7.Controllers
{
    public class FIEController : Controller
    {
        // GET: FIE
        [Authorize(Roles = "Guest,Employer")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Employer")]
        public ActionResult FLT_TM()
        {
            return View();
        }

        [Authorize(Roles = "Employer")]
        public ActionResult FLT_UR()
        {
            return View();
        }

        [Authorize(Roles = "Employer")]
        public ActionResult FLT_UP()
        {
            return View();
        }
    }
}