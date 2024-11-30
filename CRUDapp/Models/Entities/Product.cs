namespace CRUDapp.Models.Entities
{
    public class Product
    {
        // EFC will automatically set this Id for us; others we have to capture from a form.
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }  // Change to decimal
        public int Quantity { get; set; }   // Change to int
    }
}
