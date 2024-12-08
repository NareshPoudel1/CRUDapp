﻿using CRUDapp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDapp.Services.ProductServices
{
    public class ProductServices : IProductServices
    {
        private readonly ApplicationDbContext _context;

        public ProductServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Guid id)
        {
            var product = await GetProductById(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

<<<<<<< HEAD
        public async Task<IEnumerable<Product>> GetAllProducts()//>> is part of the generic type syntax used to define that the method will return a Task that resolves to IEnumerable<Product>.
=======
        public async Task<IEnumerable<Product>> GetAllProducts()
>>>>>>> 31d814c294fd9382fb508acbf2a8f33eab2e3b3e
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
