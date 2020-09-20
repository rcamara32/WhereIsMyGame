using Microsoft.AspNetCore.Http;
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
            var newGameObj = new
            {
                newGameViewModel.PlataformId,
                newGameViewModel.Name,
                newGameViewModel.Description,
                newGameViewModel.IsActive,
                Image = ConvertToByte(newGameViewModel.Image)
            };

            var newGameContent = GetContent(newGameObj);

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

        public async Task<ResponseResult> MarkAsReturned(MarkReturnedDto markReturnedDto)
        {
            var editGameContent = GetContent(markReturnedDto);

            var response = await _httpClient.PutAsync($"/api/collection/games/mark-returned/", editGameContent);

            if (!ExceptionHandlingResponse(response))
                return await DeserializeObjectResponse<ResponseResult>(response);

            return Ok();
        }


        /// <summary>
        /// Convert IFormFile to array
        /// </summary>
        /// <param name="IFormFile">object type of IFormFile - game image</param>
        /// <returns></returns>
        private byte[] ConvertToByte(IFormFile formFile)
        {
            using var fileStream = formFile.OpenReadStream();
            byte[] bytes = new byte[formFile.Length];
            fileStream.Read(bytes, 0, (int)formFile.Length);

            return bytes;
        }

    }
}