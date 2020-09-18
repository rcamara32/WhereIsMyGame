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
    public class CollectionService : Service, ICollectionService
    {
        private readonly HttpClient _httpClient;

        public CollectionService(HttpClient httpClient,
            IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.CollectionBffUrl);
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
            var response = await _httpClient.GetAsync($"/api/collection/games/{id}");

            ExceptionHandlingResponse(response);

            return await DeserializeObjectResponse<GameViewModel>(response);
        }

        public async Task<IEnumerable<PlataformViewModel>> GetAllPlataforms()
        {
            var response = await _httpClient.GetAsync("/api/collection/games/plataforms");

            ExceptionHandlingResponse(response);

            return await DeserializeObjectResponse<IEnumerable<PlataformViewModel>>(response);
        }

        public async Task<ResponseResult> AddGame(NewGameViewModel newGameViewModel)
        {
            var newGameContent = GetContent(newGameViewModel);

            var response = await _httpClient.PostAsync("/api/collection/games/add-game/", newGameContent);

            if (!ExceptionHandlingResponse(response)) 
                return await DeserializeObjectResponse<ResponseResult>(response);

            return Ok();
        }

        public async Task<ResponseResult> EditGame(EditGameViewModel editGameViewModel)
        {
            var editGameContent = GetContent(editGameViewModel);

            var response = await _httpClient.PutAsync("/api/collection/games/edit-game/", editGameContent);

            if (!ExceptionHandlingResponse(response))
                return await DeserializeObjectResponse<ResponseResult>(response);

            return Ok();
        }

        public async Task<ResponseResult> DeleteGame(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"/api/collection/games/delete-game/{id}");

            if (!ExceptionHandlingResponse(response))
                return await DeserializeObjectResponse<ResponseResult>(response);

            return Ok();
        }
    }
}