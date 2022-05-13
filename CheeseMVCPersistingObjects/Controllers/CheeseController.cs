using CheeseMVCPersistingObjects.Data;
using CheeseMVCPersistingObjects.Models;
using CheeseMVCPersistingObjects.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVCPersistingObjects.Controllers
{
    public class CheeseController : Controller
    {
        private CheeseDbContext dbContext;

        public CheeseController(CheeseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Cheese> cheeses = dbContext.Cheeses.Include(c => c.Category).ToList();//Si no ponemos Include no nos mostraria en la vista la categoria
            ViewBag.title = "Quesos";
            return View(cheeses);
        }

        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = 
                new AddCheeseViewModel(dbContext.Categories.ToList());
            ViewBag.title = "Agregar Quesos";
            return View(addCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (!ModelState.IsValid)
            {
                CheeseCategory newCheeseCategory =
                    dbContext.Categories.Single(c => c.Id == addCheeseViewModel.CategoryId);

                Cheese newCheese = new Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    CategoryId = addCheeseViewModel.CategoryId,
                    Category = addCheeseViewModel.Category
                };
                dbContext.Cheeses.Add(newCheese);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addCheeseViewModel);
        }

        public IActionResult Remove()
        {
            List<Cheese> cheeses = dbContext.Cheeses.ToList();
            ViewBag.title = "Eliminar quesos";
            return View(cheeses);
        }

        [HttpPost]
        public IActionResult Remove(int[] cheesesIds)
        {
            foreach (int cheese in cheesesIds)
            {
                Cheese cheeseToRemove = dbContext.Cheeses.Single(x => x.Id == cheese);
                dbContext.Cheeses.Remove(cheeseToRemove);                
            }
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Category(int id)
        {
            if(id== 0)
            {
                return RedirectToAction("Category");
            }

            List<Cheese> cheeses = dbContext.Cheeses.ToList();

            CheeseCategory theCategory = dbContext.Categories
                .Include(cat => cat.Cheeses)
                .Single(cat => cat.Id == id);

            ViewBag.title = "Quesos en la categoria: " + theCategory.Name;

            return View("Index", theCategory.Cheeses); // Estoy pasando quesos, pero solo de una cierta categoria
            
        }

    }
}
