namespace CheeseMVCPersistingObjects.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<CheeseMenu> CheeseMenus { get; set; } = new List<CheeseMenu>();
    }
}
