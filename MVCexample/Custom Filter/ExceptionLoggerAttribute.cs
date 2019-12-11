using MVCexample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCexample.Custom_Filter
{
    public class ExceptionLoggerAttribute:FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if(filterContext.ExceptionHandled==false)
            {

                DBLogger dBLogger = new DBLogger
                {
                    ErrorMEssgae = filterContext.Exception.Message,
                    StackTrace = filterContext.Exception.StackTrace,
                    ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                    ActionName = filterContext.RouteData.Values["action"].ToString(),
                    LoginDate = DateTime.Now
                };
                ApplicationDbContext db = new ApplicationDbContext();
                db.DBLoggers .Add(dBLogger);
                db.SaveChanges();
                filterContext.ExceptionHandled = true;
            }
        }
    }
    
}