using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MVCexample.CustomAttribute;

namespace MVCexample.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Your Name")]
        [StringLength(50)]
        public string CustomerName { get; set; }

   
        [Required]
        [ValidBirthDate]
        [Display(Name = "Birth of Date")]
       
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }
 
        public long MobileNumber { get; set; }

        [Required]
        [Display(Name = "Your City")]
        public string City { get; set; }


        //Reference Table
       public MembershipType MembershipType { get; set; }

        // Reference Column
        [Required]
        public int? MembershipTypeID { get; set; }

      

    }
    
}