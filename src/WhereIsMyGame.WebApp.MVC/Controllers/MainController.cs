using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WhereIsMyGame.Core.Communication;

namespace WhereIsMyGame.WebApp.MVC.Controllers
{
    public class MainController : Controller
    {
        protected bool GetResponseErrors(ResponseResult response)
        {
            if (response != null && response.Errors.Messages.Any())
            {
                foreach (var mensagem in response.Errors.Messages)
                {
                    ModelState.AddModelError(string.Empty, mensagem);
                }

                return true;
            }

            return false;
        }
    }
}
