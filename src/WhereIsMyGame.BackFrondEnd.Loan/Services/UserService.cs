using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WhereIsMyGame.BackFrondEnd.Loan.Extensions;
using WhereIsMyGame.BackFrondEnd.Loan.Models;

namespace WhereIsMyGame.BackFrondEnd.Loan.Services
{

    public interface IUserService
    {
        Task<UserDetailsDto> GetUserDetails(Guid userId);
    }

    public class UserService : Service, IUserService
    {

        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.AuthUrl);
        }


        public async Task<UserDetailsDto> GetUserDetails(Guid userId)
        {
            var response = await _httpClient.GetAsync($"/api/auth/details/{userId}");

            HandlingResponseError(response);

            return await DeserializeObjectResponse<UserDetailsDto>(response);
        }

    }
}
