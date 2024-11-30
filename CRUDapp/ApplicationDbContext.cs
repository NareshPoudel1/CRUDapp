using CRUDapp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUDapp
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        { 
        
        }
            public DbSet<Product> Products { get; set; }//Represents the Products table in the database; allows querying and saving instances of the Product entity.
    }



    
}
