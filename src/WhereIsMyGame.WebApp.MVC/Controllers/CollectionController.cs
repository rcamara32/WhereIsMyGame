using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
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
            //var collection = new List<GameViewModel>();
            return View(collection);
        }

        [Route("new-game")]
        public async Task<IActionResult> NewGame()
        {
            return View(await GetAllPlataformsAsync(new NewGameViewModel()));
        }

        [Route("new-game")]
        [HttpPost]
        public async Task<IActionResult> NewProduct(NewGameViewModel newGameViewModel)
        {
            if (!ModelState.IsValid) return View(await GetAllPlataformsAsync(newGameViewModel));

            var response = await _collectionService.AddGame(newGameViewModel);

            if (GetResponseErrors(response)) 
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();

            return RedirectToAction("Index");
        }

        private async Task<NewGameViewModel> GetAllPlataformsAsync(NewGameViewModel newGameViewModel)
        {
            newGameViewModel.Plataforms = await _collectionService.GetAllPlataforms();
            return newGameViewModel;
        }

    }
}