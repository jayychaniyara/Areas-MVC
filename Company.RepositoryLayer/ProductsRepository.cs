﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DomainModels;
using Company.RepositoryContracts;
using Company.DataLayer;
namespace Company.RepositoryLayer
{
    public class ProductsRepository : IProductsRepository
    {
        CompanyDBContext db;

        public ProductsRepository()
        {
            this.db = new CompanyDBContext();
        }

        public void DeleteProduct(long ProductID)
        {
            Product existingProduct = db.Products.Where(temp => temp.ProductID == ProductID).FirstOrDefault();
            db.Products.Remove(existingProduct);
            db.SaveChanges();
        }

        public Product GetProductByProductID(long ProductID)
        {
            Product p = db.Products.Where(x => x.ProductID == ProductID).FirstOrDefault();
            return p;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = db.Products.ToList();
            return products;
        }

        public void InsertProduct(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
        }

        public List<Product> SearchProducts(string ProductName)
        {
            List<Product> products = db.Products.Where(temp => temp.ProductName.Contains(ProductName)).ToList();
            return products;
        }

        public void UpdateProduct(Product p)
        {
            Product existingProduct = db.Products.Where(temp => temp.ProductID == p.ProductID).FirstOrDefault();
            existingProduct.ProductName = p.ProductName;
            existingProduct.DateOfPurchase = p.DateOfPurchase;
            existingProduct.CategoryId = p.CategoryId;
            existingProduct.BrandId = p.BrandId;
            existingProduct.AvailablityStatus = p.AvailablityStatus;
            existingProduct.Active = p.Active;
            existingProduct.Photo = p.Photo;
            db.SaveChanges();
        }
    }
}
