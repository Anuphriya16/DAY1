using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCexample.Models;
using MVCexample.ViewModel;
using System.Data.Entity;

namespace MVCexample.Controllers
{


    public class MoviesController : Controller
    {
        private ApplicationDbContext dbContext = null;
        public MoviesController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = dbContext.Movies.Include(a => a.Genre).ToList();

            return View(movies);
        }
        public ActionResult MovieDetails(int id)
        {
            var movies = dbContext.Movies.Include(b => b.Genre).ToList().SingleOrDefault(a => a.ID == id);
            return View(movies);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            var Movies = new Movie();
            ViewBag.GenreID = ListGenre();
            return View(Movies);
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Create(Movie DetailsfromView)
        {
            if(!ModelState.IsValid)
            {
                
                ViewBag.GenreID = ListGenre();
                return View(DetailsfromView);
            }
            dbContext.Movies.Add(DetailsfromView);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        [Authorize]
        [HttpGet]
        public ActionResult EditMovie(int id)
        {
            var movie = dbContext.Movies.SingleOrDefault(a => a.ID == id);
            if (movie != null)
            {
                ViewBag.GenreID = ListGenre();
           
                return View(movie);

            }
            return HttpNotFound("ID does not exists");

        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult EditMovie(Movie moviefromview)
        {
            if (ModelState.IsValid)
            {
                var movieinDB = dbContext.Movies.FirstOrDefault(c => c.ID == moviefromview.ID);
                movieinDB.Movie_Name = moviefromview.Movie_Name;
                movieinDB.Release_Date = moviefromview.Release_Date;
                movieinDB.Date_Added = moviefromview.Date_Added;
                movieinDB.GenreID = moviefromview.GenreID;
                movieinDB.Available_Stock = moviefromview.Available_Stock;

                dbContext.SaveChanges();
                return RedirectToAction("Index", "Movies");
            }
            else
            {
                ViewBag.GenreID = ListGenre();
                return View(moviefromview);
            }
        }
        [Authorize]
        [HttpGet]
        public ActionResult DeleteMovie(int id)
        {
            var movie = dbContext.Movies.SingleOrDefault(a => a.ID == id);
            if (movie != null)
            {
                ViewBag.GenreID = ListGenre();

                return View(movie);

            }
            return HttpNotFound("ID does not exists");

        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult DeleteMovie(Movie customerfromview)
        {
            if (ModelState.IsValid)
            {
                var customerinDB = dbContext.Movies.FirstOrDefault(c => c.ID == customerfromview.ID);

                dbContext.Movies.Remove(customerinDB);
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Movies");
            }
            else
            {

                return HttpNotFound("Delted");
            }
        }
        public IEnumerable<SelectListItem> ListGenre()
        {
            //This is using LINQ
            //var gen = (from m in dbContext.Genres.AsEnumerable()
            //                  select new SelectListItem
            //                  {
            //                      Text = m.Name,
            //                      Value = m.ID.ToString()
            //                  }).ToList();
            //gen.Insert(0, new SelectListItem { Text = "---Select----", Value = "0" });
            //return gen;
            //This using Lamda
            var gen = dbContext.Genres.AsEnumerable().Select(m => new SelectListItem()
            {
                Text = m.Name,
                Value = m.ID.ToString()
            }).ToList();
            gen.Insert(0, new SelectListItem { Text = "---Select----", Value = "0",Disabled=true,Selected=true });
            return gen;
        }

        //public ActionResult Display()
        //{
        //    Movie movie = new Movie();
        //    movie.ID = 1;
        //    movie.MovieName = "Kappaan";
        //    return View(movie);
        //}
        //public ActionResult Display()
        //{
        //    CustomerMovieViewModel vm = new CustomerMovieViewModel();
        //    vm.Movies = new Movie { ID = 1, MovieName = "Kappaan" };
        //    vm.Customers = new List<Customer>
        //    {
        //        new Customer{ID=1,CustomerName="Anu"},
        //        new Customer{ID=2,CustomerName="Sushu"},
        //        new Customer{ID=3,CustomerName="Priyanga"}
        //    };


        //    return View(vm);
        //}
        //public ActionResult DisplayCustomer()
        //{
        //    CustomerMovieViewModel vm1 = new CustomerMovieViewModel();
        //    vm1.Customers1 = new Customer { CustomerName = "Anuphriya" };
        //    vm1.Movies1 = new List<Movie>
        //    {
        //        new Movie{ID=1,MovieName="ABC"},
        //        new Movie{ID=2,MovieName="XYZ"}
        //    };

        //    return View(vm1);
        //}
        //public List<Movie> GetMovies()
        //{
        //    List<Movie> movies = new List<Movie>
        //    {
        //       new Movie{ID=1,MovieName="Spider Man",ReleaseDate=Convert.ToDateTime("17/07/2000"),DateAdded=Convert.ToDateTime("11/07/2004")},
        //       new Movie{ID=2,MovieName="Raatchasan",ReleaseDate=Convert.ToDateTime("17/11/1990"),DateAdded=Convert.ToDateTime("11/05/2011")},
        //       new Movie{ID=3,MovieName="Avengers",ReleaseDate=Convert.ToDateTime("24/07/2010"),DateAdded=Convert.ToDateTime("22/10/1994")},
        //       new Movie{ID=4,MovieName="Final Destination",ReleaseDate=Convert.ToDateTime("25/07/2015"),DateAdded=Convert.ToDateTime("23/10/2008")}
        //    };

        //    return movies;
        //}


    }
}