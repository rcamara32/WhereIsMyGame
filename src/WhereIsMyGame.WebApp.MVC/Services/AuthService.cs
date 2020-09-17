using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WhereIsMyGame.WebApp.MVC.Extensions;
using WhereIsMyGame.WebApp.MVC.Models;

namespace WhereIsMyGame.WebApp.MVC.Services
{
    public class AuthService : Service, IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.AuthUrl);            
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _httpClient = httpClient;            
        }

        public async Task<GetUserLogin> Login(UserLogin userLogin)
        {
            var loginContent = GetContent(userLogin);

            var response = await _httpClient.PostAsync("/api/auth/login", loginContent);

            if (!ExceptionHandlingResponse(response))
            {
                return new GetUserLogin
                {
                    ResponseResult = await DeserializeObjectResponse<ResponseResult>(response)
                };
            }

            return await DeserializeObjectResponse<GetUserLogin>(response);
        }

        public async Task<GetUserLogin> Register(RegisterUser registerUser)
        {
            var registerUserContent = GetContent(registerUser);

            var response = await _httpClient.PostAsync("/api/auth/new-account", registerUserContent);

            if (!ExceptionHandlingResponse(response))
            {
                return new GetUserLogin
                {
                    ResponseResult = await DeserializeObjectResponse<ResponseResult>(response)
                };
            }

            return await DeserializeObjectResponse<GetUserLogin>(response);
        }
    }
}