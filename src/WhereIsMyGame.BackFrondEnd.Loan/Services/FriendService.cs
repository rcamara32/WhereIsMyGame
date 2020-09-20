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
    public interface IFriendService
    {
        Task<IEnumerable<FriendDto>> GetByUser();
        Task<GameDto> GetById(Guid id);

        Task<ResponseResult> AddFriend(AddFriendDto addFriendDto);
        Task<ResponseResult> EditFriend(EditFriendDto editFriendDto);
        Task<ResponseResult> DeleteFriend(Guid id);
    }

    public class FriendService : Service, IFriendService
    {
        private readonly HttpClient _httpClient;

        public FriendService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CollectionUrl);
        }

        public async Task<GameDto> GetById(Guid id)
        {
            var response = await _httpClient.GetAsync($"/api/friends/details/{id}");

            HandlingResponseError(response);

            return await DeserializeObjectResponse<GameDto>(response);
        }

        public async Task<IEnumerable<FriendDto>> GetByUser()
        {
            var response = await _httpClient.GetAsync("/api/friends/list");

            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            HandlingResponseError(response);

            return await DeserializeObjectResponse<IEnumerable<FriendDto>>(response);
        }


        public async Task<ResponseResult> AddFriend(AddFriendDto addFriendDto)
        {
            var itemContent = GetContent(addFriendDto);

            var response = await _httpClient.PostAsync("/api/friends/add/", itemContent);

            if (!HandlingResponseError(response))
                return await DeserializeObjectResponse<ResponseResult>(response);

            return Ok();
        }

        public async Task<ResponseResult> EditFriend(EditFriendDto editFriendDto)
        {
            var itemContent = GetContent(editFriendDto);

            var response = await _httpClient.PostAsync("/api/friends/edit/", itemContent);

            if (!HandlingResponseError(response))
                return await DeserializeObjectResponse<ResponseResult>(response);

            return Ok();
        }

        public async Task<ResponseResult> DeleteFriend(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"/api/friends/delete/{id}");

            if (!HandlingResponseError(response))
                return await DeserializeObjectResponse<ResponseResult>(response);

            return Ok();
        }
    }
}
