namespace CheeseMVCPersistingObjects.Models
{
    public class CheeseMenu // Clase intermediaria
    {
        public int MenuID { get; set; }
        public Menu Menu { get; set; }

        public int CheeseID { get; set; }
        public Cheese Cheese { get; set; }
    }
}
