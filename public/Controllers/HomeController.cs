using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace publicWeb.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ApplicationCache()
        {
            //Response.Cache.SetMaxAge(TimeSpan.Zero);
            return View();
        }

    }
}
