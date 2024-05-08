using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using misty.DataAccess.Repository;
using misty.DataAccess.Repository.IRepository;
using misty.Models;
using misty.Utility;
using MistyASP.DataAccess.Data;
using System.CodeDom;

namespace YessineWEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class GameController : Controller
    {



        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public GameController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;


        }

        public IActionResult Index()
        {
            List<Game> games = _unitOfWork.GameRepository.GetAll(includes: "Category").ToList();

            return View(games);
        }
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.CategoryRepository.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ViewBag.LISTA = CategoryList;


            if (id == null || id == 0)
            {
                return View();
            }
            else
            {
                Game game = _unitOfWork.GameRepository.Get(u => u.Id == id, includes: "Category");
                return View(game);
            }
        }



        [HttpPost]
        public IActionResult Upsert(Game obj, IFormFile? file)
        {
            if (obj.Title == obj.Author.ToString())
            {
                ModelState.AddModelError("name", "You cant put the title and the Author with the same name");
            }

            if (obj.Title == "test")
            {
                ModelState.AddModelError("", "You cant put the name test");
            }

            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string name = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string ModelPath = Path.Combine(wwwRootPath, @"images\games");



                // Update or add the game object
                if (obj.Id == 0)
                {
                    _unitOfWork.GameRepository.Add(obj);
                }
                else
                {
                    // Ensure Id is not set explicitly
                    // or set it to default value
                    _unitOfWork.GameRepository.Update(obj);
                }

                using (var file1 = new FileStream(Path.Combine(ModelPath, name), FileMode.Create))
                {
                    file.CopyTo(file1);
                }
                obj.ImageUrl = @"\images\games\" + name;
            }

            _unitOfWork.Save();
            TempData["success"] = "Game created or updated successfully";
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Game? game = _unitOfWork.GameRepository.Get(u => u.Id == id, includes: "Category");
            //Game? game1 = _db.catergories.FirstOrDefault(u =>u.Id == id);
            //Game? game2 = _db.catergories.Where(u => u.Id ==id).FirstOrDefault()  ; 
            if (game == null)
            {
                return NotFound();
            }


            return View(game);



        }


        [HttpPost, ActionName("Delete")]
        public IActionResult deletePOST(int? id)
        {
            Game game = _unitOfWork.GameRepository.Get(u => u.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            
            _unitOfWork.GameRepository.Remove(game);
            _unitOfWork.Save();
            TempData["success"] = "game deleted successfully";
            return RedirectToAction("Index");


        }

        
    }

}



































