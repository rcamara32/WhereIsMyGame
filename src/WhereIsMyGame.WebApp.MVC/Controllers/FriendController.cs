using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WhereIsMyGame.WebApp.MVC.Models;
using WhereIsMyGame.WebApp.MVC.Services;

namespace WhereIsMyGame.WebApp.MVC.Controllers
{
    public class FriendController : MainController
    {
        private readonly IFriendService _friendService;

        public FriendController(
            IFriendService friendService)
        {
            _friendService = friendService;
        }

        [HttpGet]
        [Route("my-friends")]
        public async Task<IActionResult> Index()
        {
            var collection = await _friendService.GetByUser();
          
            return View(collection);
        }


        [HttpGet]
        [Route("edit-friend")]
        public async Task<IActionResult> EditFriend(Guid id)
        {
            var friend = await _friendService.GetById(id);
            return View(friend);
        }

        [Route("add-friend")]
        public IActionResult AddFriend()
        {
            return View(new NewFriendViewModel());
        }

        [Route("add-friend")]
        [HttpPost]
        public async Task<IActionResult> AddFriend(NewFriendViewModel newFriendViewModel)
        {
            if (!ModelState.IsValid)
                return View(newFriendViewModel);

            var response = await _friendService.AddFriend(newFriendViewModel);

            if (GetResponseErrors(response))
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("edit-friend")]
        public async Task<IActionResult> EditFriend(Guid id, EditFriendViewModel editFriendViewModel)
        {
            if (!ModelState.IsValid)
                return View(editFriendViewModel);

            await _friendService.EditFriend(editFriendViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("delete-friend")]
        public async Task<IActionResult> DeleteFriend(Guid id)
        {
            await _friendService.DeleteFriend(id);
            return RedirectToAction("Index");
        }

    }
}