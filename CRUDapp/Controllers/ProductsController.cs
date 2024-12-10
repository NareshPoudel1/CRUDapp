using CRUDapp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using CRUDapp.Models;
     
using Microsoft.EntityFrameworkCore;


namespace CRUDapp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext dbContext;



        public ProductsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult Add() // method
        {
            return View(); // create view cshtml for the CRUD app
        }

        // we keep AddProductViewModel as parameter to get access to this and giving it a name of view model
        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel viewModel)
        {
            var product = new Product
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Price = viewModel.Price,
                Quantity = viewModel.Quantity,
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            return View();


        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var products = await dbContext.Products.ToListAsync();
            return View(products);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await dbContext.Products.FindAsync(id);
            return View(product);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product viewModel)
        {
            var product = await dbContext.Products.FindAsync(viewModel.Id);

            if (product is not null)
            {
                product.Name = viewModel.Name;
                product.Price = viewModel.Price;
                product.Quantity = viewModel.Quantity;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Products");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product viewModel)
        {
               var product = await dbContext.Products
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == viewModel.Id);

                if (product is not null)
                {
                    dbContext.Products.Remove(product); //  to remove 'product' instead of 'viewModel'
                   await dbContext.SaveChangesAsync();
                }

               return RedirectToAction("List", "Products"); //  the return statement
            
          
        }


    }
}
