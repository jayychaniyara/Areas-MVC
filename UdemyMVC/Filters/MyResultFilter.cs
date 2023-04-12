using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UdemyMVC.Filters
{
    public class MyResultFilter : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.NoOfVistiorsOfTheDay = 80;
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
        }
    }
}