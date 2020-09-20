using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WhereIsMyGame.WebApp.MVC.Models;
using WhereIsMyGame.WebApp.MVC.Services;

namespace WhereIsMyGame.WebApp.MVC.Controllers
{
    public class CollectionController : MainController
    {
        private readonly ICollectionService _collectionService;

        public CollectionController(ICollectionService collectionService)
        {
            _collectionService = collectionService;
        }

        [HttpGet]
        [Route("my-games")]
        public async Task<IActionResult> Index()
        {
            var collection = await _collectionService.GetByUser();
            return View(collection);
        }

        [HttpGet]
        [Route("game")]
        public async Task<IActionResult> Detail(Guid id)
        {
            var game = await _collectionService.GetById(id);
            game.Plataforms = await _collectionService.GetAllPlataforms();

            return View(game);
        }

        [Route("new-game")]
        public async Task<IActionResult> NewGame()
        {
            return View(await GetAllPlataformsAsync(new NewGameViewModel()));
        }

        [Route("new-game")]
        [HttpPost]
        public async Task<IActionResult> NewGame([Bind("PlataformId, Name, Description, IsActive, Image")]NewGameViewModel newGameViewModel)
        {
            if (!ModelState.IsValid)
                return View(await GetAllPlataformsAsync(newGameViewModel));

            //var image = Image.Load(newGameViewModel.Image.OpenReadStream());
            //image.Mutate(x => x.Resize(256, 256));

            var response = await _collectionService.AddGame(newGameViewModel);

            if (GetResponseErrors(response))
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();

            return RedirectToAction("Index");
        }


        [HttpPost]
        [Route("edit-game")]
        public async Task<IActionResult> EditGame(Guid id, EditGameViewModel editGameViewModel)
        {
            if (!ModelState.IsValid)
                return View(await GetAllPlataformsAsync(editGameViewModel));

            await _collectionService.EditGame(editGameViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("delete-game")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _collectionService.DeleteGame(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("return")]
        public async Task<IActionResult> MarkAsReturned(MarkReturnedDto markReturnedDto)
        {
           var response =  await _collectionService.MarkAsReturned(markReturnedDto);

            if (GetResponseErrors(response)) 
                return View("Index", await _collectionService.GetById(markReturnedDto.Id));
            
            return RedirectToAction("Index");
        }

        private async Task<NewGameViewModel> GetAllPlataformsAsync(NewGameViewModel newGameViewModel)
        {
            newGameViewModel.Plataforms = await _collectionService.GetAllPlataforms();
            return newGameViewModel;
        }

        private async Task<EditGameViewModel> GetAllPlataformsAsync(EditGameViewModel editGameViewModel)
        {
            editGameViewModel.Plataforms = await _collectionService.GetAllPlataforms();
            return editGameViewModel;
        }


    }
}