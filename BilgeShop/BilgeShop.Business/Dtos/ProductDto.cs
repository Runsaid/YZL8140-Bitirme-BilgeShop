namespace BilgeShop.Business.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }
        public string CategoryName { get; set; }




    }
}
