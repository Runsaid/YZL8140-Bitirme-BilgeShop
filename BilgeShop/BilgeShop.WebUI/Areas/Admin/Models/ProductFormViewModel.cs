using System.ComponentModel.DataAnnotations;

namespace BilgeShop.WebUI.Areas.Admin.Models
{
    public class ProductFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ürün adı girmek zorunlu")]
        [Display(Name = "Ürün Adı")]
        public string Name { get; set; }

        [Display(Name = "Ürün Açıklaması")]
        public string? Description { get; set; }

        [Display(Name = "Ürün Fiyatı")]
        public decimal? UnitPrice { get; set; }

        [Display(Name = "Stok Miktarı")]
        public int UnitInStock { get; set; }

        [Required(ErrorMessage = "Bir Kategori seçmek zorunlu.")]
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }

        [Display(Name="Ürün Görseli")]
        public IFormFile? File { get; set; }

       
    }
}
