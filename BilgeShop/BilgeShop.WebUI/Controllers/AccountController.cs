using BilgeShop.Business.Dtos;
using BilgeShop.Business.Services;
using BilgeShop.WebUI.Extensions;
using BilgeShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BilgeShop.WebUI.Controllers
{
    public class AccountController : Controller
    {
        // UserManager bir class , bunun içerisinde metotlar var. Benim bu metotları kullanmam için, UserManager classını newlemem gerekiyor.
        // Newlemek yerine kullanabileceğim bir diğer yöntem ise Dependency Injection ile servis burada tanımlamak.
        // Interface üzerinden bir servis tanımlayıp bunu constuctor injection'da yaratıyorum.
        // Artık _userService. diyerek , bana sunulan hizmetleri/metotları kullanabilirim.
        
        // Dependency Injection ile oluşturuğum servis, istek gönderildiğinde newlenip , istek bitiminde silinecek.
        // eskiden using kullanılırdı. artık gerek yok.

       
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("Hesabim")]
        public IActionResult Index()
        {
            var viewModel = new AccountViewModel()
            {
                FirstName = User.GetUserFirstName(),
                LastName = User.GetUserLastName(),
                Email = User.GetUserEmail(),
                EmailConfirm = User.GetUserEmail()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(AccountViewModel formData)
        {
            // ModelState.IsValid -> Modelim , DataAnnotations ile verilen kuralara uygun mu doldurulmuş.
            if (!ModelState.IsValid)
            {
                return View("index", formData);  // Viewimin adı , action adından farklı olduğu için parametre ile hangi view'e gideceğini belirtmem lazım. Doldurduğum veriler silinmesin diye formdata'yı geri gönderiyorum.
            }

            var userProfileEditDto = new UserProfileEditDto()
            {
                FirstName = formData.FirstName,
                LastName = formData.LastName,
                Email = formData.Email,
                Id = User.GetUserId()
            };

            _userService.UpdateUser(userProfileEditDto);

            
            return RedirectToAction("index", "home");
                
        }


    }
}
