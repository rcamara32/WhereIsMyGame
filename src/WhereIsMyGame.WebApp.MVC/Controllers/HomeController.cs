using Microsoft.AspNetCore.Mvc;
using WhereIsMyGame.WebApp.MVC.Models;

namespace WhereIsMyGame.WebApp.MVC.Controllers
{
    public class HomeController : MainController
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("system-unavailable")]
        public IActionResult SystemUnavailable()
        {
            var modelErro = new ErrorViewModel
            {
                ErrorMessage = "The system is temporarily unavailable",
                Error = "Game Over...",
                ErroCode = 500
            };

            return View("Error", modelErro);
        }


        [Route("error/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.ErrorMessage = "An error has occurred! Please try again later.";
                modelErro.Error = "Game Over...";
                modelErro.ErroCode = id;
            }
            else if (id == 404)
            {
                modelErro.ErrorMessage = "The page you are looking for does not exist!";
                modelErro.Error = "Page Not Found";
                modelErro.ErroCode = id;
            }
            else if (id == 403)
            {
                modelErro.ErrorMessage = "You didn't kill the big boss!";
                modelErro.Error = "Level Locked!";
                modelErro.ErroCode = id;
            }
            else
            {
                return StatusCode(404);
            }

            return View("Error", modelErro);
        }
    }
}
