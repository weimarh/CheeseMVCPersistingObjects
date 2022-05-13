using System.ComponentModel.DataAnnotations;

namespace CheeseMVCPersistingObjects.ViewModel
{
    public class AddMenuViewModel
    {
        [Required(ErrorMessage = "Se requiere un nombre para el menu")]
        [Display(Name = "Nombre del menu")]
        [StringLength(20)]
        public string Name { get; set; }
    }
}
