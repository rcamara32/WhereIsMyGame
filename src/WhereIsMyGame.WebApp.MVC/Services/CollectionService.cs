using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WhereIsMyGame.WebApp.MVC.Extensions;
using WhereIsMyGame.WebApp.MVC.Models;

namespace WhereIsMyGame.WebApp.MVC.Services
{
    public class CollectionService : Service, ICollectionService
    {
        private readonly HttpClient _httpClient;

        public CollectionService(HttpClient httpClient,
            IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.CollectionUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _httpClient = httpClient;
        }

        public async Task<IEnumerable<GameViewModel>> GetByUser()
        {
            var response = await _httpClient.GetAsync("/api/collection/games/");

            ExceptionHandlingResponse(response);

            return await DeserializeObjectResponse<IEnumerable<GameViewModel>>(response);
        }

        public async Task<GameViewModel> GetById(Guid id)
        {
            var response = await _httpClient.GetAsync($"/api/collection/game/{id}");

            ExceptionHandlingResponse(response);

            return await DeserializeObjectResponse<GameViewModel>(response);
        }

      
    }
}