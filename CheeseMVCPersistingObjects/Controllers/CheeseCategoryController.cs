using CheeseMVCPersistingObjects.Data;
using CheeseMVCPersistingObjects.Models;
using CheeseMVCPersistingObjects.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CheeseMVCPersistingObjects.Controllers
{
    public class CheeseCategoryController : Controller
    {
        private CheeseDbContext dbContext;

        public CheeseCategoryController(CheeseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<CheeseCategory> Categories = dbContext.Categories.ToList();
            ViewBag.title = "Categorias";
            return View(Categories);
        }

        public IActionResult Add()
        {
            AddCheeseCategoryViewModel addCheeseCategoryViewModel = 
                new AddCheeseCategoryViewModel();

            ViewBag.title = "Agregar categoria";
            return View(addCheeseCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCheeseCategoryViewModel addCheeseCategoryViewModel)
        {
            if(ModelState.IsValid)
            {
                CheeseCategory cheeseCategory = new CheeseCategory
                {
                    Name = addCheeseCategoryViewModel.Name
                };

                dbContext.Categories.Add(cheeseCategory);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addCheeseCategoryViewModel);
        }

       

        [HttpPost]
        public IActionResult Remove(int categoriesId)
        {
            
            CheeseCategory categoryToRemove = dbContext.Categories.Single(x => x.Id == categoriesId);
            dbContext.Categories.Remove(categoryToRemove);
            
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
