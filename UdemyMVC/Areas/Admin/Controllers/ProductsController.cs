using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Company.DomainModels;
using Company.DataLayer;
using UdemyMVC.Filters;
using Company.ServiceContracts;
using Company.ServiceLayer;

namespace UdemyMVC.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class ProductsController : Controller
    {
        CompanyDBContext db;
        IProductsService prodService;

        public ProductsController(IProductsService pService)
        {
            this.db = new CompanyDBContext();
            this.prodService = pService;
        }

        // GET: Admin/Products
        public ActionResult Index()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<Product> Products = db.Products.ToList();
            return View(Products);
        }

        public ActionResult SearchProduct(string search = "", string SortColumn = "ProductID", string Index = "asc", int PageNo = 1)
        {
            List<Product> Product = prodService.SearchProducts(search);
            ViewBag.Search = search;
            ViewBag.sortColumn = SortColumn;
            ViewBag.index = Index;

            if (ViewBag.SortColumn == "ProductID")
            {
                if (ViewBag.Index == "asc")
                    Product = Product.OrderBy(temp => temp.ProductID).ToList();

                else
                    Product = Product.OrderByDescending(temp => temp.ProductID).ToList();
            }

            if (ViewBag.SortColumn == "ProductName")
            {
                if (ViewBag.Index == "asc")
                    Product = Product.OrderBy(temp => temp.ProductName).ToList();

                else
                    Product = Product.OrderByDescending(temp => temp.ProductName).ToList();
            }

            if (ViewBag.SortColumn == "DateOfPurchase")
            {
                if (ViewBag.Index == "asc")
                    Product = Product.OrderBy(temp => temp.DateOfPurchase).ToList();

                else
                    Product = Product.OrderByDescending(temp => temp.DateOfPurchase).ToList();
            }

            if (ViewBag.SortColumn == "CategoryName")
            {
                if (ViewBag.Index == "asc")
                    Product = Product.OrderBy(temp => temp.Category.CategoryName).ToList();

                else
                    Product = Product.OrderByDescending(temp => temp.Category.CategoryName).ToList();
            }

            if (ViewBag.SortColumn == "BrandName")
            {
                if (ViewBag.Index == "asc")
                    Product = Product.OrderBy(temp => temp.Brand.BrandName).ToList();

                else
                    Product = Product.OrderByDescending(temp => temp.Brand.BrandName).ToList();
            }

            //Paging
            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Product.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.NoOfPages = NoOfPages;
            ViewBag.PageNo = PageNo;
            Product = Product.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
            return View(Product);
        }

        public ActionResult Details(long id)
        {
            Product Product = prodService.GetProductByProductID(id);
            ViewBag.ProductName = Product.ProductName;
            return View(Product);
        }

        public ActionResult Create()
        {
            CompanyDBContext db = new CompanyDBContext();
            ViewBag.Cat = db.Categories.ToList();
            ViewBag.Bd = db.Brands.ToList();
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,DateOfPurchase,AvailablityStatus,CategoryId,BrandId,Active,Photo")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imageBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imageBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                    product.Photo = base64String;
                }
                prodService.InsertProduct(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(long id)
        {
            Product existingProduct = prodService.GetProductByProductID(id);
            ViewBag.AvailablityStatus = existingProduct.AvailablityStatus;
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            CompanyDBContext db = new CompanyDBContext();
            Product existingProduct = db.Products.Where(temp => temp.ProductID == product.ProductID).FirstOrDefault();

            if (Request.Files.Count >= 1)
            {
                var file = Request.Files[0];
                var imageBytes = new Byte[file.ContentLength];
                file.InputStream.Read(imageBytes, 0, file.ContentLength);
                var base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                existingProduct.Photo = base64String;
            }

            existingProduct.ProductName = product.ProductName;
            existingProduct.DateOfPurchase = product.DateOfPurchase;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.BrandId = product.BrandId;
            existingProduct.AvailablityStatus = product.AvailablityStatus;
            existingProduct.Active = product.Active;
            prodService.UpdateProduct(existingProduct);
            return RedirectToAction("Index", "Products");
        }

        public ActionResult Delete(long id)
        {
            Product existingProduct = prodService.GetProductByProductID(id);
            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Delete(long id, Product p)
        {
            prodService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}