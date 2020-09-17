using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
    }
}