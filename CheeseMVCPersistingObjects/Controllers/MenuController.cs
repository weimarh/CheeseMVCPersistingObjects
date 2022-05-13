using CheeseMVCPersistingObjects.Data;
using CheeseMVCPersistingObjects.Models;
using CheeseMVCPersistingObjects.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVCPersistingObjects.Controllers
{
    public class MenuController : Controller
    {
        private CheeseDbContext dbContext;
        public MenuController(CheeseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Menu> menus = dbContext.Menus.ToList();
            ViewBag.title = "Menues";
            return View(menus);
        }

        public IActionResult Add()
        {
            AddMenuViewModel addMenuViewModel = new AddMenuViewModel();
            ViewBag.title = "Agregar Menu";
            return View(addMenuViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddMenuViewModel addMenuViewModel)
        {
            if(ModelState.IsValid)
            {
                Menu newMenu = new Menu
                {
                    Name = addMenuViewModel.Name,
                };
                dbContext.Menus.Add(newMenu);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addMenuViewModel);
        }

        public IActionResult ViewMenu(int id)
        {
            ViewBag.title = "Quesos en el menu";

            List<CheeseMenu> items = dbContext.CheeseMenus
                .Include(item => item.Cheese)
                .Where(cm => cm.MenuID == id)
                .ToList();

            Menu menu = dbContext.Menus.Single(m => m.Id == id);

            ViewMenuViewModel viewMenuViewModel = new ViewMenuViewModel
            {
                Menu = menu,
                Items = items
            };

            return View(viewMenuViewModel);
        }

        public IActionResult AddItem(int id)
        {
            ViewBag.title = "Agregar queso al Menu";
            Menu menu = dbContext.Menus.Single(x => x.Id == id);
            List<Cheese> cheeses = dbContext.Cheeses.ToList();

            ViewBag.menues = dbContext.Menus.Single(x => x.Id == id);

            AddMenuItemViewModel addMenuItemViewModel = new AddMenuItemViewModel(menu, cheeses)
            {               
                MenuId = menu.Id,
            };
           

            return View(addMenuItemViewModel);
            //return View(new AddMenuItemViewModel(menu, cheeses));
        }

        [HttpPost]
        public IActionResult AddItem(AddMenuItemViewModel addMenuItemViewModel)
        {
            if(!ModelState.IsValid)
            {
                var cheeseId = addMenuItemViewModel.CheeseId;
                var menuId = addMenuItemViewModel.MenuId;

                IList<CheeseMenu> existingItems = dbContext.CheeseMenus
                    .Where(cm => cm.CheeseID == cheeseId)
                    .Where(cm => cm.MenuID == menuId).ToList();
                

                if (existingItems.Count == 0)
                {
                    Cheese cheese = dbContext.Cheeses.Single(x => x.Id == cheeseId);
                    Menu menu = dbContext.Menus.Single(x => x.Id == menuId);

                    CheeseMenu cheeseMenu = new CheeseMenu
                    {
                        Cheese = cheese,
                        Menu = menu,
                        MenuID = menu.Id,
                        CheeseID = cheese.Id
                    };

                    dbContext.CheeseMenus.Add(cheeseMenu);
                    dbContext.SaveChanges();
                }
                return Redirect(String.Format("/Menu/ViewMenu/{0}", addMenuItemViewModel.MenuId));
            }
            return View(addMenuItemViewModel);
        }
    }
}
