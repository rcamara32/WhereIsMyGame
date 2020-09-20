using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WhereIsMyGame.Core.Communication;
using WhereIsMyGame.WebApp.MVC.Extensions;
using WhereIsMyGame.WebApp.MVC.Models;

namespace WhereIsMyGame.WebApp.MVC.Services
{

    public interface IProfileService
    {
        Task<UserDetailsDto> GetUserDetails();
    }

    public class ProfileService : Service, IProfileService
    {
        private readonly HttpClient _httpClient;

        public ProfileService(HttpClient httpClient,
            IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.CollectionBffUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _httpClient = httpClient;
        }

        public async Task<UserDetailsDto> GetUserDetails()
        {
            var response = await _httpClient.GetAsync($"/api/user/details/");

            ExceptionHandlingResponse(response);

            return await DeserializeObjectResponse<UserDetailsDto>(response);
        }

    }
}
