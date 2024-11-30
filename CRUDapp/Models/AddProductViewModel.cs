namespace CRUDapp.Models
{
    public class AddProductViewModel //This folder is created to save and send to http post method , so we bind all the form filled elements and send it to the db.
    {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            

    }
}
