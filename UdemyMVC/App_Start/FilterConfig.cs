using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMVC.Filters;

namespace UdemyMVC.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new MyExceptionFilter());
            filters.Add(new HandleErrorAttribute() { ExceptionType = typeof(Exception), View = "Error" });
        }
    }
}