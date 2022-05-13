using CheeseMVCPersistingObjects.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CheeseMVCPersistingObjects.ViewModel
{
    public class AddCheeseViewModel
    {
        [Required(ErrorMessage ="Se requiere un nombre valido de queso")]
        [StringLength(20)]
        [Display(Name ="Nombre del queso")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Se requiere una descripcion de queso")]
        [StringLength(20)]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public CheeseCategory Category { get; set; }

        public List<SelectListItem> CheeseCategories { get; set; }
        
        public AddCheeseViewModel(List<CheeseCategory> cheeseCategories)
        {
            CheeseCategories = new List<SelectListItem>();

            foreach (var category in cheeseCategories)
            {
                CheeseCategories.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name
                });
            }
        }

        public AddCheeseViewModel()
        {

        }

    }
}
