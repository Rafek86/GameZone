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
        private ApplicationDbContext _context;
        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesService _devicesService;
        private readonly IGamesService _gamesService;

        public GamesController(ApplicationDbContext context
            ,ICategoriesService categoriesService
            ,IDevicesService devicesService
            ,IGamesService gamesService) { 
            _context = context;
            _categoriesService = categoriesService; 
            _devicesService = devicesService;
            _gamesService = gamesService;
        }
        public IActionResult Index()
        {
            return View();
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
    }
}
