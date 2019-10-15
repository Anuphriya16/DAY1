using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCexample.Models;

namespace MVCexample.ViewModel
{
    public class CustomerMovieViewModel
    {
        public Movie Movies { get; set; }
        public List<Customer> Customers { get; set; }

        public Customer Customers1 { get; set; }
        public List<Movie> Movies1 { get; set; }


    }
}