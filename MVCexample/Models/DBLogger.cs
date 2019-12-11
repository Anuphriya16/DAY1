using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCexample.Models
{
    public class DBLogger
    {
        public int ID { get; set; }
        public string ErrorMEssgae { get; set; }
        public string StackTrace { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public DateTime LoginDate { get; set; }

    }
}