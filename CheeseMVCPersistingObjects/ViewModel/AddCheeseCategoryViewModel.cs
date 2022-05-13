using CheeseMVCPersistingObjects.Models;
using System.ComponentModel.DataAnnotations;

namespace CheeseMVCPersistingObjects.ViewModel
{
    public class AddCheeseCategoryViewModel
    {
        [Required(ErrorMessage ="Se requiere un nombre parra la categoria")]
        [Display(Name = "Nombre de la categoria")]
        [StringLength(50)]
        public string Name { get; set; }

        
    }
}
