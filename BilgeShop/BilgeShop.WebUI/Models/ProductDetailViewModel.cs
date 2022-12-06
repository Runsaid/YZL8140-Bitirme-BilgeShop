namespace BilgeShop.WebUI.Models
{
    public class ProductDetailViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public decimal? UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public string CategoryName { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public TimeSpan? LastUpdate { 
            get
            {
                var timeDif = DateTime.Now - ModifiedDate;
                return timeDif;
            }
        }
        // Son güncelleme tarihini atamak istiyorum.

    }
}
