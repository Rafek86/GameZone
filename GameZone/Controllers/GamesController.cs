using GameZone.Data;
using GameZone.Models;
using GameZone.Sevices;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesService _devicesService;
        private readonly IGamesService _gamesService;

        public GamesController(ApplicationDbContext context
            ,ICategoriesService categoriesService
            ,IDevicesService devicesService
            ,IGamesService gamesService) { 
            _categoriesService = categoriesService; 
            _devicesService = devicesService;
            _gamesService = gamesService;
        }

        public IActionResult Index()
        {
            var games = _gamesService.GetAll();
            return View(games);
        }

        public IActionResult Details(int id) { 
            
            Game game= _gamesService.GetById(id);
            if (game is null) {
               return NotFound();
            }
            return View(game);  
        }

        [HttpGet]
        public IActionResult Create() 
        {

            CreateGameFormVM viewModel = new CreateGameFormVM()
            {
                categories = _categoriesService.GetSelectList(),
                Devices =_devicesService.GetDevices()
            };
        return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormVM model)
        {

            if (!ModelState.IsValid)
            {
                model.categories =_categoriesService.GetSelectList();
                model.Devices = _devicesService.GetDevices();

                return View(model);
            }
            //Save Db
            //SaveCover to Server 
            await _gamesService.Create(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id) {

            Game game = _gamesService.GetById(id);
            if (game is null)
            {
                return NotFound();
            }
            EditGameFormVM viewModel = new()
            {
                Id = id,
                Name =game.Name,
                Description =game.Description,  
                CategoryId = game.CategoryId,   
                SelectedDevices =game.Devices.Select(x=> x.DeviceId).ToList(),
                categories = _categoriesService.GetSelectList(),
                Devices = _devicesService.GetDevices(),
                CurrentCover = game.Cover
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(EditGameFormVM model)
        {

            if (!ModelState.IsValid)
            {
                model.categories = _categoriesService.GetSelectList();
                model.Devices = _devicesService.GetDevices();
                return View(model);
            }
            var game=await _gamesService.Update(model);

            if (game is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            var isDeleted = _gamesService.Delete(id);   
            if (isDeleted)
                return Ok();
            else 
                return BadRequest();
        }
    }
}
