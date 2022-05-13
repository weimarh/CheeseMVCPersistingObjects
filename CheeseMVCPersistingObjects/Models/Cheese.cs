namespace CheeseMVCPersistingObjects.Models
{
    public class Cheese
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; } //Foreign Key
        public CheeseCategory Category { get; set; } //Navigation Property

        public List<CheeseMenu> CheeseMenus { get; set; }
        
    }
}
