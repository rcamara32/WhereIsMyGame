using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WhereIsMyGame.Collection.API.Application.Dto;
using WhereIsMyGame.Collection.API.Application.Services;
using WhereIsMyGame.WebApi.Core.Controllers;
using WhereIsMyGame.WebApi.Core.Users;

namespace WhereIsMyGame.Collection.API.Controllers
{
    [Route("api/friends")]
    public class FriendController : MainController
    {
        private readonly IFriendAppService _friendAppService;
        private readonly IUser _user;

        public FriendController(
            IFriendAppService gameAppService,
            IUser user)
        {
            _friendAppService = gameAppService;
            _user = user;
        }

        [HttpGet("list")]
        public async Task<IActionResult> Index()
        {
            var friends = await _friendAppService.GetByUser(_user.GetUserId());
            return friends == null ? NotFound() : CustomResponse(friends);
        }

        //[ClaimsAuthorize("Collection", "Read")]
        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var game = await _friendAppService.GetById(id);
            return game == null ? NotFound() : CustomResponse(game);
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddFriend(AddFriendDto addFriendDto) 
        {
            addFriendDto.UserId = _user.GetUserId();
            var result = await _friendAppService.AddFriend(addFriendDto);

            return CustomResponse(result);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit(EditFriendDto editFriendDto)
        {            
            var result = await _friendAppService.EditFriend(editFriendDto);

            return CustomResponse(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _friendAppService.DeleteFriend(id);
            return CustomResponse(result);
        }

    }
}