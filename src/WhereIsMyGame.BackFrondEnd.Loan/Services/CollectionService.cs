using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WhereIsMyGame.BackFrondEnd.Loan.Extensions;
using WhereIsMyGame.BackFrondEnd.Loan.Models;
using WhereIsMyGame.Core.Communication;

namespace WhereIsMyGame.BackFrondEnd.Loan.Services
{
    public class CollectionService : Service, ICollectionService
    {
        private readonly HttpClient _httpClient;

        public CollectionService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CollectionUrl);
        }

        public async Task<GameDto> GetById(Guid id)
        {
            var response = await _httpClient.GetAsync($"/api/collection/game/{id}");

            HandlingResponseError(response);

            return await DeserializeObjectResponse<GameDto>(response);
        }

        public async Task<IEnumerable<GameDto>> GetByUser()
        {   
            var response = await _httpClient.GetAsync("/api/collection/games/");

            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            HandlingResponseError(response);

            return await DeserializeObjectResponse<IEnumerable<GameDto>>(response);
        }

        public async Task<IEnumerable<PlataformDto>> GetAllPlataforms()
        {
            var response = await _httpClient.GetAsync("/api/collection/games/plataforms");

            HandlingResponseError(response);

            return await DeserializeObjectResponse<IEnumerable<PlataformDto>>(response);
        }

        public async Task<ResponseResult> AddGame(AddGameDto addGameDto)
        {
            var itemContent = GetContent(addGameDto);

            var response = await _httpClient.PostAsync("/api/collection/games/add-game/", itemContent);

            if (!HandlingResponseError(response))
                return await DeserializeObjectResponse<ResponseResult>(response);

            return Ok();
        }
    }
}
