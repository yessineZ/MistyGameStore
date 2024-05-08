using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using misty.DataAccess.Repository;
using misty.DataAccess.Repository.IRepository;
using misty.Models;
using misty.Utility;
using MistyASP.DataAccess.Data;
using System.CodeDom;

namespace YessineWEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin )]
    public class CategoryController : Controller
    {



        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Catergory> catergories = _unitOfWork.CategoryRepository.GetAll().ToList();

            return View(catergories);
        }

        public IActionResult Create()
        {

            return View();

        }


        [HttpPost]
        public IActionResult Create(Catergory obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "You cant put the Name and the DisplayOrder with the same name");
            }

            if (obj.Name == "test")
            {
                ModelState.AddModelError("", "You cant put the name test");
            }


            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();


        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Catergory? category = _unitOfWork.CategoryRepository.Get(u => u.Id == id);
            //Catergory? category1 = _db.catergories.FirstOrDefault(u =>u.Id == id);
            //Catergory? category2 = _db.catergories.Where(u => u.Id ==id).FirstOrDefault()  ; 
            if (category == null)
            {
                return NotFound();
            }


            return View(category);



        }


        [HttpPost]
        public IActionResult Edit(Catergory obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "THE EDIT OF THE CATEGORY HAS BEEN APPLIED successfully";
                return RedirectToAction("Index");
            }
            return View();


        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Catergory? category = _unitOfWork.CategoryRepository.Get(u => u.Id == id);
            //Catergory? category1 = _db.catergories.FirstOrDefault(u =>u.Id == id);
            //Catergory? category2 = _db.catergories.Where(u => u.Id ==id).FirstOrDefault()  ; 
            if (category == null)
            {
                return NotFound();
            }


            return View(category);



        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Catergory? category = _unitOfWork.CategoryRepository.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            _unitOfWork.CategoryRepository.Remove(category);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");


        }


    }
}





































