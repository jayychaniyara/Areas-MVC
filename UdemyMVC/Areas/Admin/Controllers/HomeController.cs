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
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StudentDetails()
        {
            ViewBag.StudentId = 1;
            ViewBag.StudentName = "Jayy";
            ViewBag.Marks = 98;
            ViewBag.SubjectList = new List<string> { "Maths", "Physics", "Chemistry" };
            return View();
        }

        [Route("Home/RequestExample/{id:int?}")]
        public ActionResult RequestExample(int? id)
        {
            ViewBag.Url = Request.Url;
            ViewBag.PhysicalAppPath = Request.PhysicalApplicationPath;
            ViewBag.Path = Request.Path;
            ViewBag.BrowserType = Request.Browser.Type;
            ViewBag.QueryString = Request.QueryString;
            ViewBag.Headers = Request.Headers;
            ViewBag.HttpMethod = Request.HttpMethod;
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Customer cus)
        {
            return View();
        }
    }
}