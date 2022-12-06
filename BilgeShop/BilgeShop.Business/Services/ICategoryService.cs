using BilgeShop.Business.Dtos;
using BilgeShop.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeShop.Business.Services
{
    public interface ICategoryService
    {
        ServiceMessage AddCategory(CategoryDto categoryDto);

        List<CategoryDto> GetCategories();

        CategoryDto GetCategoryById(int id);

        void UpdateCategory(CategoryDto categoryDto);
        void DeleteCategory(int id);
    }
}
