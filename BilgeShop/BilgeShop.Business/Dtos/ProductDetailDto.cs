using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BilgeShop.Business.Dtos
{
    public class ProductDetailDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public string ImagePath { get; set; }
        public string CategoryName { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int UnitInStock { get; set; }

    }
}
