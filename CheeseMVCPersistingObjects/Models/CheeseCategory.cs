namespace CheeseMVCPersistingObjects.Models
{
    public class CheeseCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Cheese> Cheeses { get; set; }
    }
}
