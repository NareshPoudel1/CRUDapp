using CRUDapp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using CRUDapp.Models;
using CRUDapp.Services;     
using Microsoft.EntityFrameworkCore;

namespace CRUDapp.Controllers
{
    public class ProductsController : Controller
    {
       // private readonly ApplicationDbContext dbContext;

        private readonly IProductServices _productServices;

        //public ProductsController(ApplicationDbContext dbContext)
        //{
        //    this.dbContext = dbContext;
        //}
        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
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

            //await dbContext.Products.AddAsync(product);
            //await dbContext.SaveChangesAsync();

            //return View();

            await _productServices.AddProduct(product);

            return RedirectToAction("List"); // Redirect to the List view after adding a product
        }

        // for displaying information from the table as a list
        // using async because we want to use the dbcontext to retrieve the value
        [HttpGet]
        public async Task<IActionResult> List()
        {
            //var products = await dbContext.Products.ToListAsync();
            //return View(products);
            var products = await _productServices.GetAllProducts();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            //var product = await dbContext.Products.FindAsync(id);
            //return View(product);
            var product = await _productServices.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product viewModel)
        {
            //var product = await dbContext.Products.FindAsync(viewModel.Id);

            //if (product is not null)
            //{
            //    product.Name = viewModel.Name;
            //    product.Price = viewModel.Price;
            //    product.Quantity = viewModel.Quantity;

            //    await dbContext.SaveChangesAsync();
            //}

            //return RedirectToAction("List", "Products");
            var product = await _productServices.GetProductById(viewModel.Id);

            if (product is not null)
            {
                product.Name = viewModel.Name;
                product.Price = viewModel.Price;
                product.Quantity = viewModel.Quantity;

                await _productServices.UpdateProduct(product);
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product viewModel)
        {
            //    var product = await dbContext.Products
            //        .AsNoTracking()
            //        .FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            //    if (product is not null)
            //    {
            //        dbContext.Products.Remove(product); //  to remove 'product' instead of 'viewModel'
            //        await dbContext.SaveChangesAsync();
            //    }

            //    return RedirectToAction("List", "Products"); //  the return statement
            //
            await _productServices.DeleteProduct(viewModel.Id);
            return RedirectToAction("List");
        }


    }
}
