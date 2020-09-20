using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WhereIsMyGame.WebApp.MVC.Models;
using WhereIsMyGame.WebApp.MVC.Services;

namespace WhereIsMyGame.WebApp.MVC.Controllers
{
    public class ProfileController : MainController
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        public async Task<IActionResult> Index()
        {
            var userDetails = await _profileService.GetUserDetails();
            return View(userDetails);
        }

        [HttpPost]
        [Route("change-password")]
        public async Task<IActionResult> ChangePassword(UserDetailsDto userDetailsDto)
        {
            if (!ModelState.IsValid) 
                return View("Index", userDetailsDto);

            //var registered = await _authService.Register(userDetailsDto);

            //if (GetResponseErrors(registered.ResponseResult))
                //return View(userDetailsDto);

            return RedirectToAction("Index");
        }

    }
}