using CRUDapp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using CRUDapp.Models;
using CRUDapp.Services;     
using Microsoft.EntityFrameworkCore;

namespace CRUDapp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductServices _productServices;

        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            product.Id = Guid.NewGuid(); // Ensure new product has unique ID
            await _productServices.AddProduct(product);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var products = await _productServices.GetAllProducts();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await _productServices.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            await _productServices.UpdateProduct(product);
            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productServices.DeleteProduct(id);
            return RedirectToAction("List");
        }
    }
}
