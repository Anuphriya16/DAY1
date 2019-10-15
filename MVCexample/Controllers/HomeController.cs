using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCexample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
        public ActionResult Test()
        {
            return View();
        }
        public ActionResult Example(int empid, string name)
        {
            if (empid > 0)
            {
                return Content("id" + empid + "name" + name);
            }
            else
            {
                return Content("Id cannot be negative");
            }
        }
        
        [Route("searchbyname/{name}")]
        public ActionResult Product(string name)
        {
            return Content("Product name"+name);
        }
    }
}