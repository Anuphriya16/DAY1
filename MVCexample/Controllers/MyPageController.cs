using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCexample.Controllers
{
    public class MyPageController : Controller
    {
        // GET: MyPage
        public ActionResult Index()
        {
            string Email = TempData["Email"].ToString();
       
            return Content("EmailId:"+Email);
        }
        
    }
}