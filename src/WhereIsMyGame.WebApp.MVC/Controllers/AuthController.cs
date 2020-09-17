using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using WhereIsMyGame.WebApp.MVC.Models;
using WhereIsMyGame.WebApp.MVC.Services;

namespace WhereIsMyGame.WebApp.MVC.Controllers
{
    public class AuthController : MainController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authenticationService)
        {
            _authService = authenticationService;
        }

        [HttpGet]
        [Route("create-account")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("create-account")]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            if (!ModelState.IsValid) return View(registerUser);

            var registered = await _authService.Register(registerUser);

            if (GetResponseErrors(registered.ResponseResult)) 
                return View(registerUser);

            await AuthUser(registered);

            return RedirectToAction("Index", "Collection");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLogin userLogin, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid) return View(userLogin);

            var userLogin1 = await _authService.Login(userLogin);

            if (GetResponseErrors(userLogin1.ResponseResult)) return View(userLogin1);

            await AuthUser(userLogin1);

            if (string.IsNullOrEmpty(returnUrl))
                return RedirectToAction("Index", "Collection");

            return LocalRedirect(returnUrl);
        }

        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private async Task AuthUser(GetUserLogin userLogin)
        {
            var token = GetToken(userLogin.AccessToken);

            var claims = new List<Claim>
            {
                new Claim("JWT", userLogin.AccessToken)
            };
            claims.AddRange(token.Claims);

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                IsPersistent = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        private static JwtSecurityToken GetToken(string jwtToken)
        {
            return new JwtSecurityTokenHandler()
                .ReadToken(jwtToken) as JwtSecurityToken;
        }
    }
}
