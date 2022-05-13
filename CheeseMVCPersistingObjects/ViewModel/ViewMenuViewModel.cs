using CheeseMVCPersistingObjects.Models;

namespace CheeseMVCPersistingObjects.ViewModel
{
    public class ViewMenuViewModel
    {
        public Menu Menu { get; set; }
        public IList<CheeseMenu> Items { get; set; }
    }
}
