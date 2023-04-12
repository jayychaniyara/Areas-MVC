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
    public class ProductsController : Controller
    {
        // GET: Products
        [MyAuthenticationFilter]
        [CustomerAuthorization]
        public ActionResult Index()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<Product> Products = db.Products.ToList();
            return View(Products);
        }
    }
}