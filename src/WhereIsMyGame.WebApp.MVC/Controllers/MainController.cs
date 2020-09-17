using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WhereIsMyGame.WebApp.MVC.Models;

namespace WhereIsMyGame.WebApp.MVC.Controllers
{
    public class MainController : Controller
    {
        protected bool GetResponseErrors(ResponseResult response)
        {
            if (response != null && response.Errors.ErrorMessages.Any())
            {
                foreach (var mensagem in response.Errors.ErrorMessages)
                {
                    ModelState.AddModelError(string.Empty, mensagem);
                }

                return true;
            }

            return false;
        }
    }
}
