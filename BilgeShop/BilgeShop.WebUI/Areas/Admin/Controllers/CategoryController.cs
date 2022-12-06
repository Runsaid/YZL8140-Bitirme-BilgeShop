using BilgeShop.Business.Dtos;
using BilgeShop.Business.Services;
using BilgeShop.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BilgeShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult List()
        {
            var categoryDtoList = _categoryService.GetCategories();

            var viewModel = categoryDtoList.Select(x => new CategoryFormViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToList();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult New()
        {
            return View("form" , new CategoryFormViewModel());
        }

        [HttpPost]
        public IActionResult Save(CategoryFormViewModel formData)
        {
            if (!ModelState.IsValid)
            {
                return View("form", formData);
            }

            var categoryDto = new CategoryDto
            {
                Id = formData.Id,
                Name = formData.Name,
                Description = formData.Description
            };


            if(formData.Id == 0) // Yeni eklenecek demektir
            {
               var response = _categoryService.AddCategory(categoryDto);

                if(response.IsSucceed)
                {
                    return RedirectToAction("list", "category");
                }
                else
                {
                    ViewBag.ErrorMessage = response.Message;
                    return View("form" , formData);
                }



            }
            else // id 0'dan farklıysa -> öyle bir kayıt demek ki var
            {
                // Güncelleme işlemleri
                _categoryService.UpdateCategory(categoryDto);
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var categoryDto = _categoryService.GetCategoryById(id);

            var viewModel = new CategoryFormViewModel()
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };

            return View("form" , viewModel);
        }

        public IActionResult Delete(int id)
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction("list");
        }
    }
}
