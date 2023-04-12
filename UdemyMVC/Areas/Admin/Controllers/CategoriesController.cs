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
    public class CategoriesController : Controller
    {
        // GET: Admin/Categories
        public ActionResult Index()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
    }
}