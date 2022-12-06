using System.ComponentModel.DataAnnotations;

namespace BilgeShop.WebUI.Areas.Admin.Models
{
    public class CategoryFormViewModel
    {
        public int Id { get; set; }

        [Display(Name="Ad")]
        [Required(ErrorMessage = "Kategori Adını girmek zorunludur.")]
        public string Name { get; set; }

        [Display(Name="Açıklama")]
        
        public string? Description { get; set; }

        // ? ile -> null olabilir.
    }
}
