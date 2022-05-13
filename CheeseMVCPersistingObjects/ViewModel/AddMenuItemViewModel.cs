using CheeseMVCPersistingObjects.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CheeseMVCPersistingObjects.ViewModel
{
    public class AddMenuItemViewModel
    {
        public Menu Menu { get; set; } 
        public List<SelectListItem> Cheeses { get; set; }

        [Required]
        public int MenuId { get; set; }
        public int CheeseId { get; set; }

        public AddMenuItemViewModel()
        {
            
        }

        public AddMenuItemViewModel(Menu menu, List<Cheese> cheeses)
        {
            
            
            Cheeses = new List<SelectListItem>();

            foreach (var cheese in cheeses)
            {
                Cheeses.Add(new SelectListItem
                {
                    Text = cheese.Name,
                    Value = cheese.Id.ToString()
                });
            }

            Menu = menu;
        }
    }
}
