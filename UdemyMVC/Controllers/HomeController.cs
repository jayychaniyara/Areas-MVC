using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMVC.Filters;
using Company.DomainModels;
using Company.DataLayer;

namespace UdemyMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [MyActionFilter]
        [MyResultFilter]
        [OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            //throw new Exception("Some exception for testion");
            return View();
        }
    }
}