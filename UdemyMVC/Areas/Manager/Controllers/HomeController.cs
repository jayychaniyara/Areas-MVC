using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMVC.Filters;
using Company.DomainModels;
using Company.DataLayer;

namespace UdemyMVC.Areas.Manager.Controllers
{
    [ManagerAuthhorization]
    public class HomeController : Controller
    {
        // GET: Manager/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}