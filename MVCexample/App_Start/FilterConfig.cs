﻿using MVCexample.Custom_Filter;
using System.Web;
using System.Web.Mvc;

namespace MVCexample
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ExceptionLoggerAttribute());
        }
    }
}
