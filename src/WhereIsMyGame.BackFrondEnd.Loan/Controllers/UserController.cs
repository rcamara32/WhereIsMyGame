using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WhereIsMyGame.BackFrondEnd.Loan.Services;
using WhereIsMyGame.WebApi.Core.Controllers;
using WhereIsMyGame.WebApi.Core.Users;

namespace WhereIsMyGame.BackFrondEnd.Loan.Controllers
{
    [Route("api/user")]
    public class UserController : MainController
    {

        private readonly IUserService _userService;
        private readonly IUser _user;


        public UserController(
            IUserService userService,
            IUser user)
        {
            _userService = userService;
            _user = user;
        }

        [HttpGet]
        [Route("details")]
        public async Task<IActionResult> GetUserDetails()
        {
            var userId = _user.GetUserId();
            return CustomResponse(await _userService.GetUserDetails(userId));
        }

    }
}