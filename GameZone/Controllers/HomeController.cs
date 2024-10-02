using GameZone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GameZone.Sevices;

namespace GameZone.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGamesService _gameService;

        public HomeController(IGamesService gamesService)
        {
          _gameService = gamesService;
        }

        public IActionResult Index()
        {
            var games = _gameService.GetAll();
            return View(games);  
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
