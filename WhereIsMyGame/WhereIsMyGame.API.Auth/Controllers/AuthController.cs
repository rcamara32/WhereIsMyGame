using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetDevPack.Identity.Jwt;
using NetDevPack.Identity.Jwt.Model;
using NetDevPack.Identity.Model;
using System.Threading.Tasks;

namespace WhereIsMyGame.API.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppJwtSettings _appJwtSettings;

        public AuthController(SignInManager<IdentityUser> signInManager,
                      UserManager<IdentityUser> userManager,
                      IOptions<AppJwtSettings> appJwtSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appJwtSettings = appJwtSettings.Value;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterUser registerUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var createdUser = await _userManager.CreateAsync(user, registerUser.Password);
            if (createdUser.Succeeded)
            {
                return Ok(GetUserResponse(user.Email));
            }

            return BadRequest(createdUser.Errors);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUser loginUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var logged = await _signInManager.PasswordSignInAsync
                 (loginUser.Email, loginUser.Password, false, true);

            if (logged.Succeeded)
            {
                return Ok(GetFullJwt(loginUser.Email));
            }

            if (logged.IsLockedOut)
            {
                return BadRequest("Your account is temporalily disabled.");
            }

            return BadRequest("Incorrect user or password");
        }


        private string GetFullJwt(string email)
        {
            return new JwtBuilder()
                .WithUserManager(_userManager)
                .WithJwtSettings(_appJwtSettings)
                .WithEmail(email)
                .WithJwtClaims()
                .WithUserClaims()
                .WithUserRoles()
                .BuildToken();
        }

        private UserResponse GetUserResponse(string email)
        {
            var response = new JwtBuilder()
                 .WithUserManager(_userManager)
                 .WithJwtSettings(_appJwtSettings)
                 .WithEmail(email)
                 .WithJwtClaims()
                 .WithUserClaims()
                 .WithUserRoles()
                 .BuildUserResponse() as UserResponse;

            return response;
        }

    }
}