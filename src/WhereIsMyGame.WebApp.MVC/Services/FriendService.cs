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

    public interface IFriendService
    {
        Task<IEnumerable<FriendViewModel>> GetByUser();
        Task<FriendViewModel> GetById(Guid id);

        Task<ResponseResult> AddFriend(NewFriendViewModel newFriendViewModel);
        Task<ResponseResult> EditFriend(EditFriendViewModel editFriendViewModel);
        Task<ResponseResult> DeleteFriend(Guid id);
    }

    public class FriendService : Service, IFriendService
    {
        private readonly HttpClient _httpClient;

        public FriendService(HttpClient httpClient,
            IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.CollectionUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _httpClient = httpClient;
        }

        public async Task<IEnumerable<FriendViewModel>> GetByUser()
        {
            var response = await _httpClient.GetAsync("/api/friends/list");

            ExceptionHandlingResponse(response);

            return await DeserializeObjectResponse<IEnumerable<FriendViewModel>>(response);
        }

        public async Task<FriendViewModel> GetById(Guid id)
        {
            var response = await _httpClient.GetAsync($"/api/friends/details/{id}");

            ExceptionHandlingResponse(response);

            return await DeserializeObjectResponse<FriendViewModel>(response);
        }

        public async Task<ResponseResult> AddFriend(NewFriendViewModel newFriendViewModel)
        {
            var newContent = GetContent(newFriendViewModel);

            var response = await _httpClient.PostAsync("/api/friends/add/", newContent);

            if (!ExceptionHandlingResponse(response))
                return await DeserializeObjectResponse<ResponseResult>(response);

            return Ok();
        }

        public async Task<ResponseResult> EditFriend(EditFriendViewModel editFriendViewModel)
        {
            var editContent = GetContent(editFriendViewModel);

            var response = await _httpClient.PutAsync("/api/friends/edit/", editContent);

            if (!ExceptionHandlingResponse(response))
                return await DeserializeObjectResponse<ResponseResult>(response);

            return Ok();
        }

        public async Task<ResponseResult> DeleteFriend(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"/api/friends/delete/{id}");

            if (!ExceptionHandlingResponse(response))
                return await DeserializeObjectResponse<ResponseResult>(response);

            return Ok();
        }
    }
}
