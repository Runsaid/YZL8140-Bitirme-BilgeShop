using BilgeShop.Business.Services;
using BilgeShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BilgeShop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("/{productName}-{id}")]
        public IActionResult Detail (int id)
        {
            var productDetailDto = _productService.GetProductDetail(id);

            var viewModel = new ProductDetailViewModel()
            {

                Name = productDetailDto.Name,
                Description = productDetailDto.Description,
                ImagePath = productDetailDto.ImagePath,
                UnitInStock = productDetailDto.UnitInStock,
                UnitPrice = productDetailDto.UnitPrice,
                CategoryName = productDetailDto.CategoryName,
                ModifiedDate = productDetailDto.ModifiedDate

            };
 
            return View(viewModel);

        }
    }
}
