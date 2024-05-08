using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using misty.DataAccess.Repository;
using misty.DataAccess.Repository.IRepository;
using misty.Models;
using misty.Utility;
using System.Diagnostics;

namespace YessineWEB.Areas.User.Controllers {
    [Area("User")]
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork) {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }



        public IActionResult Index() {
            List<Game> games = _unitOfWork.GameRepository.GetAll(includes: "Category").ToList();
            return View(games);
        }

        public IActionResult Privacy() {
            return View();
        }

        public IActionResult Details(int id) {
            Game game = _unitOfWork.GameRepository.Get(u => u.Id == id, includes: "Category");
            return View(game);
        }

    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize(Roles = SD.Role_User)]
        public IActionResult idk(int id) {
            Game game1 = _unitOfWork.GameRepository.Get(u => u.Id == id, includes :  "Category");

            if (game1 == null) {
                return NotFound();
            }
            return View(game1);

        }
    }
}
