using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DomainModels
{
    public class Brand
    {
        [Key]
        public long BrandId { get; set; }
        public string BrandName { get; set; }

    }
}
