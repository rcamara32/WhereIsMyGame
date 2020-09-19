using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WhereIsMyGame.BackFrondEnd.Loan.Models;
using WhereIsMyGame.BackFrondEnd.Loan.Services;
using WhereIsMyGame.WebApi.Core.Controllers;

namespace WhereIsMyGame.BackFrondEnd.Loan.Controllers
{
    [Authorize]
    [Route("api/friends")]
    public class FriendController : MainController
    {
        private readonly IFriendService _friendService;

        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
            _friendService = friendService;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> Index()
        {
            var gameCollection = await _friendService.GetByUser();
            return gameCollection == null ? NotFound() : CustomResponse(gameCollection);
        }

        [HttpGet]
        [Route("details/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return CustomResponse(await _friendService.GetById(id));
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddFriend(AddFriendDto addFriendDto)
        {

            var response = await _friendService.AddFriend(addFriendDto);
            return CustomResponse(response);
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> EditFriend(EditFriendDto editFriendDto)
        {
            var response = await _friendService.EditFriend(editFriendDto);
            return CustomResponse(response);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            var game = await _friendService.GetById(id);

            if (game == null)
            {
                AddError("Friend not found");
                return CustomResponse();
            }

            var response = await _friendService.DeleteFriend(id);
            return CustomResponse(response);
        }

    }
}