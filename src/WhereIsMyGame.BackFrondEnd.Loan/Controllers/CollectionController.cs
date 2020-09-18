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
    [Route("api/collection")]
    public class CollectionController : MainController
    {        
        private readonly ICollectionService _collectionService;

        public CollectionController(ICollectionService collectionService)
        {
            _collectionService = collectionService;
        }

        [HttpGet]
        [Route("games")]
        public async Task<IActionResult> Index()
        {
            var gameCollection = await _collectionService.GetByUser();
            return gameCollection == null ? NotFound() : CustomResponse(gameCollection);
        }

        [HttpGet]
        [Route("games/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return CustomResponse(await _collectionService.GetById(id));
        }

        [HttpGet]
        [Route("games/plataforms")]
        public async Task<IActionResult> Plataforms()
        {
            var plataforms = await _collectionService.GetAllPlataforms();
            return plataforms == null ? NotFound() : CustomResponse(plataforms);
        }

        [HttpPost]
        [Route("games/add-game")]
        public async Task<IActionResult> AddGame(AddGameDto addGameDto) 
        {

            var response = await _collectionService.AddGame(addGameDto);
            return CustomResponse(response);
        }

        [HttpPut]
        [Route("games/edit-game")]
        public async Task<IActionResult> EditGame(EditGameDto editGameDto)
        {
            var response = await _collectionService.EditGame(editGameDto);
            return CustomResponse(response);
        }

        [HttpDelete]
        [Route("games/delete-game/{id}")]
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            var game = await _collectionService.GetById(id);

            if (game == null)
            {
                AddError("Game not found");
                return CustomResponse();
            }

            var response = await _collectionService.DeleteGame(id);
            return CustomResponse(response);
        }

    }
}