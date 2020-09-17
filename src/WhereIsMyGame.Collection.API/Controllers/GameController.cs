using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhereIsMyGame.Collection.API.Data.Repositories;
using WhereIsMyGame.Collection.API.Models;
using WhereIsMyGame.WebApi.Core.Controllers;
using WhereIsMyGame.WebApi.Core.Identity;
using WhereIsMyGame.WebApi.Core.Users;

namespace WhereIsMyGame.Collection.API.Controllers
{
    [Route("api/collection")]
    [ApiController]
    [Authorize]
    public class GameController : MainController
    {
        private readonly IGameRepository _gameRepository;
        private readonly IUser _user;

        public GameController(IGameRepository gameRepository,
            IUser user)
        {
            _gameRepository = gameRepository;
            _user = user;
        }

        //[AllowAnonymous]
        [HttpGet("games")]
        public async Task<IEnumerable<Game>> Index()
        {
            var userId = _user.GetUserId();
            return await _gameRepository.GetByUser(userId);
        }

        [ClaimsAuthorize("Collection","Read")]
        [HttpGet("games/{id}")]
        public async Task<Game> Details(Guid id)
        {
            return await _gameRepository.GetById(id);
        }
    }
}