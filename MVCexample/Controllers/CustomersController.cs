using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCexample.Models;
using System.Data.Entity;
using MVCexample.Custom_Filter;

namespace MVCexample.Controllers
{
   
    public class CustomersController : Controller
    {
        private ApplicationDbContext DbContext = null;
        public CustomersController()
        {
            DbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DbContext.Dispose();
            }
        }
        // GET: Customers
        public ActionResult Index()
        {
            List<Customer> customers = DbContext.Customers.Include(a => a.MembershipType).ToList(); //instead of List<Customer> we can use var
            return View("DisplayCustomer", customers);
        }
        [HandleError(ExceptionType = typeof(NullReferenceException), View = "NullReference")]
        [OutputCache(Duration =50,VaryByParam ="id",Location =System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Details(int id)
        {
            var customers = DbContext.Customers.Include(b => b.MembershipType).ToList().SingleOrDefault(a => a.ID == id);
            if(customers==null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }
      
        [NonAction]
        public IEnumerable<SelectListItem> ListGender()
        {
            var gender = new List<SelectListItem>
            { 
                new SelectListItem { Text = "Select a gender", Value = "0", Disabled = true, Selected = true },
                new SelectListItem { Text = "Male", Value = "Male" },
                   new SelectListItem { Text = "Female", Value = "Female" },
                      new SelectListItem { Text = "Others", Value = "Others" },
            };
        return gender;
            }
        //var gender=new List<SelectListItem>
        //  {

        //  }
        public IEnumerable<SelectListItem> ListMembership()
        {
            var membership = (from m in DbContext.MembershipTypes.AsEnumerable()
                              select new SelectListItem
                              {
                                  Text = m.Type,
                                  Value = m.ID.ToString()
                              }).ToList();
            membership.Insert(0, new SelectListItem { Text = "---Select----", Value = "0" });
            return membership;
        }
        //[Authorize]
        //[AllowAnonymous]
        [HttpGet]
        public ActionResult Create()
        {
            var Customers = new Customer();
            ViewBag.Gender = ListGender();
            ViewBag.MembershipTypeID = ListMembership();
            return View(Customers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        [AllowAnonymous]

        [ExceptionLogger]
        public ActionResult Create(Customer DetailsfromView)
        {                     
            if(!ModelState.IsValid)
            {
                ViewBag.Gender = ListGender();
                ViewBag.MembershipTypeID = ListMembership();
                return View(DetailsfromView);
            }
            DbContext.Customers.Add(DetailsfromView);
            DbContext.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
     
        [HttpGet]
        public ActionResult EditCustomer(int id)
        {
            var customer = DbContext.Customers.SingleOrDefault(a => a.ID == id);
            if(customer!=null)
            {
                ViewBag.Gender = ListGender();
                ViewBag.MembershipTypeID = ListMembership();
                return View(customer);
                
            }
            return HttpNotFound("ID does not exists");

        }
      
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult EditCustomer(Customer customerfromview)
        {
            if(ModelState.IsValid)
            {
                var customerinDB = DbContext.Customers.FirstOrDefault(c => c.ID == customerfromview.ID);
                customerinDB.CustomerName = customerfromview.CustomerName;
                customerinDB.City = customerfromview.City;
                customerinDB.Gender = customerfromview.Gender;
                customerinDB.BirthDate = customerfromview.BirthDate;
                customerinDB.MembershipTypeID = customerfromview.MembershipTypeID;
                DbContext.SaveChanges();
                return RedirectToAction("Index","Customers");
            }
            else
            {
                ViewBag.Gender = ListGender();
                ViewBag.MembershipTypeID = ListMembership();
                return View (customerfromview);
            }
        }
        [Authorize]
        [HttpGet]
        public ActionResult DeleteCustomer(int id)
        {
           var customer= DbContext.Customers.SingleOrDefault(a => a.ID == id);
            if (customer != null)
            {

                DbContext.Customers.Remove(customer);
                DbContext.SaveChanges();
                return View(customer);

            }
            return HttpNotFound("ID does not exists");

        }

        //[HttpGet]
        //public ActionResult CountryName()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult CountryName(string CountryName)
        //{
        //    TempData["CountryName"] = CountryName;
        //    return RedirectToAction("Index", "Home");

        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken()]
        //public ActionResult DeleteCustomer(Customer customerfromview)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var customerinDB = DbContext.Customers.FirstOrDefault(c => c.ID == customerfromview.ID);
              
        //        DbContext.Customers.Remove(customerinDB);
        //        DbContext.SaveChanges();
        //        return RedirectToAction("Index", "Customers");
        //    }
        //    else
        //    {

        //        return HttpNotFound("No Content");
        //    }
        //}
        [NonAction]
      
       
        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer{ID=1,CustomerName="Anu",BirthDate=Convert.ToDateTime("01/11/1997"),Gender="Female",MobileNumber=9585915676},
                new Customer{ID=2,CustomerName="Phriya",BirthDate=Convert.ToDateTime("25/03/2004"),Gender="Femlae",MobileNumber=9874560321},
                new Customer{ID=3,CustomerName="Raghav",BirthDate=Convert.ToDateTime("06/11/2003"),Gender="Male",MobileNumber=7708965231}
            };

            return customers;
        }



    }
}