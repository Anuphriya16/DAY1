using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCexample.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Movie Name is must")]
        [Display(Name = "Movie Name")]
        [StringLength(50)]
        public string Movie_Name { get; set; }
        //  public string Genre { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? Release_Date { get; set; }


        [Required]
        [Display(Name = "Date Added")]
        public DateTime? Date_Added { get; set; }
        [Required]
        public int Available_Stock { get; set; }

   
        public Genre Genre { get; set; }
 
        // Reference Column
        [Required]
        public int? GenreID { get; set; }
   

    }
}