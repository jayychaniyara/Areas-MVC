using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DomainModels;

namespace Company.DataLayer
{
    public class CompanyDBContext : DbContext
    {
        public CompanyDBContext() : base("MyConnectionString")
        {

        }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
