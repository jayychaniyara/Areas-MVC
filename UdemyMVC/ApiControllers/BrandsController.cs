using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Company.DomainModels;
using Company.DataLayer;

namespace UdemyMVC.ApiControllers
{
    [Authorize(Roles = "Admin")]
    public class BrandsController : ApiController
    {
        public List<Brand> GetBrands()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<Brand> brands = db.Brands.ToList();
            return brands;
        }

        public Brand GetBrandsByBrandId(long BrandId)
        {
            CompanyDBContext db = new CompanyDBContext();
            Brand existingBrand = db.Brands.Where(b => b.BrandId == BrandId).FirstOrDefault();
            return existingBrand;
        }

        public void PostBrand(Brand newBrand)
        {
            CompanyDBContext db = new CompanyDBContext();
            db.Brands.Add(newBrand);
            db.SaveChanges();
        }

        public void PutBrand(Brand brandData)
        {
            CompanyDBContext db = new CompanyDBContext();
            var existingBrand = db.Brands.Where(temp => temp.BrandId == brandData.BrandId).FirstOrDefault();
            existingBrand.BrandName = brandData.BrandName;
            db.SaveChanges();
        }


        public void DeleteBrand(long BrandId)
        {
            CompanyDBContext db = new CompanyDBContext();
            var existingBrand = db.Brands.Where(temp => temp.BrandId == BrandId).FirstOrDefault();
            db.Brands.Remove(existingBrand);
            db.SaveChanges();
        }

    }
}
