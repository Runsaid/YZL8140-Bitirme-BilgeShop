using BilgeShop.Business.Dtos;
using BilgeShop.Business.Services;
using BilgeShop.Business.Types;
using BilgeShop.Data.Entities;
using BilgeShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeShop.Business.Managers
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepository<CategoryEntity> _categoryRepository;
        public CategoryManager(IRepository<CategoryEntity> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ServiceMessage AddCategory(CategoryDto categoryDto)
        {
            // Aynı isimde kategori var mı diye kontrol yapıyorum.
            var hasCategory = _categoryRepository.GetAll(x => x.Name.ToLower() == categoryDto.Name.ToLower() && x.IsDeleted == false).ToList();

            if(hasCategory.Any()) // Hiç veri gelmediyse
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Bu isimde bir kategori zaten mevcut."
                };
            }
            // Else yazılabilir fakat return görüldükten sonra , metottan çıkılacağı için , yazmaya gerek yok .

            var categoryEntity = new CategoryEntity()
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };

            _categoryRepository.Add(categoryEntity);

            return new ServiceMessage
            {
                IsSucceed = true
            };

          
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.Delete(id);
        }

        public List<CategoryDto> GetCategories()
        {
            var categoryEntites = _categoryRepository.GetAll().Where(x => x.IsDeleted == false).OrderBy(x => x.Name);

            var categoryDtoList = categoryEntites.Select(x => new CategoryDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToList();

            return categoryDtoList;
        }

        public CategoryDto GetCategoryById(int id)
        {
            // Bu Id'ye sahip category entity çekilecek.
            var categoryEntity = _categoryRepository.GetById(id);

            // İhtiyacım olan propertyler , dto'da doldurulup, return edilecek.
            var categoryDto = new CategoryDto()
            {
                Id = categoryEntity.Id,
                Name = categoryEntity.Name,
                Description = categoryEntity.Description
            };

            return categoryDto;
        }

        public void UpdateCategory(CategoryDto categoryDto)
        {
            var categoryEntity = _categoryRepository.GetById(categoryDto.Id);

            categoryEntity.Name = categoryDto.Name;
            categoryEntity.Description = categoryDto.Description;

            _categoryRepository.Update(categoryEntity);


        }
    }
}
