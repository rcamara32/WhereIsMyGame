﻿using Microsoft.Extensions.Options;
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
    public interface ICollectionService
    {
        Task<IEnumerable<GameDto>> GetByUser();
        Task<GameDto> GetById(Guid id);
        Task<IEnumerable<PlataformDto>> GetAllPlataforms();
        Task<ResponseResult> AddGame(AddGameDto addGameDto);
        Task<ResponseResult> EditGame(EditGameDto editGameDto);
        Task<ResponseResult> DeleteGame(Guid id);
        Task<ResponseResult> MarkAsReturned(MarkReturnedDto markReturnedDto);
        Task<ResponseResult> GameLoan(GameLoanDto gameLoanDto);
    }

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
            var response = await _httpClient.GetAsync($"/api/collection/games/{id}");

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

        public async Task<ResponseResult> EditGame(EditGameDto editGameDto)
        {
            var itemContent = GetContent(editGameDto);

            var response = await _httpClient.PostAsync("/api/collection/games/edit-game/", itemContent);

            if (!HandlingResponseError(response))
                return await DeserializeObjectResponse<ResponseResult>(response);

            return Ok();
        }

        public async Task<ResponseResult> DeleteGame(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"/api/collection/games/delete-game/{id}");

            if (!HandlingResponseError(response))
                return await DeserializeObjectResponse<ResponseResult>(response);

            return Ok();
        }

        public async Task<ResponseResult> MarkAsReturned(MarkReturnedDto markReturnedDto)
        {
            var editGameContent = GetContent(markReturnedDto);
            var response = await _httpClient.PutAsync("/api/collection/games/mark-returned/", editGameContent);

            if (!HandlingResponseError(response))
                return await DeserializeObjectResponse<ResponseResult>(response);

            return Ok();
        }

        public async Task<ResponseResult> GameLoan(GameLoanDto gameLoanDto)
        {
            var itemContent = GetContent(gameLoanDto);
            var response = await _httpClient.PostAsync("/api/collection/games/loan/", itemContent);

            if (!HandlingResponseError(response))
                return await DeserializeObjectResponse<ResponseResult>(response);

            return Ok();
        }
    }
}
