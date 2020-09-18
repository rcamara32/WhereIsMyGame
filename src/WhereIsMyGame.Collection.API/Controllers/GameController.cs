﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WhereIsMyGame.Collection.API.Application.Dto;
using WhereIsMyGame.Collection.API.Application.Services;
using WhereIsMyGame.WebApi.Core.Controllers;
using WhereIsMyGame.WebApi.Core.Identity;
using WhereIsMyGame.WebApi.Core.Users;

namespace WhereIsMyGame.Collection.API.Controllers
{
    [Route("api/collection")]
    public class GameController : MainController
    {
        private readonly IGameAppService _gameAppService;
        private readonly IUser _user;

        public GameController(
            IGameAppService gameAppService,
            IUser user)
        {
            _gameAppService = gameAppService;
            _user = user;
        }

        [HttpGet("games")]
        public async Task<IActionResult> Index()
        {
            var gameCollection = await _gameAppService.GetByUser(_user.GetUserId());

            return gameCollection == null ? NotFound() : CustomResponse(gameCollection);
        }

        [ClaimsAuthorize("Collection", "Read")]
        [HttpGet("games/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var game = await _gameAppService.GetById(id);
            return game == null ? NotFound() : CustomResponse(game);
        }

        [HttpGet("games/plataforms")]
        public async Task<IActionResult> Plataforms()
        {
            var plataforms = await _gameAppService.GetAllPlataforms();

            return plataforms == null ? NotFound() : CustomResponse(plataforms);
        }

        [HttpPost("games/add-game")]
        public async Task<IActionResult> AddGame(AddGameDto addGameDto) 
        {
            addGameDto.UserId = _user.GetUserId();

            var result = await _gameAppService.AddGame(addGameDto);

            return CustomResponse(result);
        }

    }
}