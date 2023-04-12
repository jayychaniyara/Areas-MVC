using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMVC.Filters;
using Company.DomainModels;
using Company.DataLayer;

namespace UdemyMVC.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class BrandController : Controller
    {
        // GET: Admin/Brand
        public ActionResult Index()
        {
            return View();
        }
    }
}