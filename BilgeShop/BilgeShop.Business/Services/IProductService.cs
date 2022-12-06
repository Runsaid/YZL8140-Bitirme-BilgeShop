using BilgeShop.Business.Dtos;
using BilgeShop.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeShop.Business.Services
{
    public interface IProductService
    {

        ServiceMessage AddProduct(ProductDto productDto);

        List<ProductDto> GetProducts();

        ProductDto GetProductById(int id);

        void EditProduct(ProductDto productDto);

        List<ProductDto> GetProductsByCategoryId(int? CategoryId = null);

        ProductDetailDto GetProductDetail(int id);

        void DeleteProduct(int id);

    }
}
