using CRUDapp.Models.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CRUDapp.Services.ProductServices
{
    public class ProductServicesStoredProcedure : IProductServices
    {
        private readonly ApplicationDbContext _context;
        public ProductServicesStoredProcedure(ApplicationDbContext context)
        {
            _context = context;
        }
        // Add product using SpAddProduct
        public async Task AddProduct(Product product)
        {
            var parameters = new[]
            {
                new SqlParameter("@Id", product.Id),
                new SqlParameter("@Name", product.Name),
                new SqlParameter("@Price", product.Price),
                new SqlParameter("@Quantity", product.Quantity)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC SpAddProduct @Id, @Name, @Price, @Quantity", parameters);
        }
        // Delete product using SpDeleteProduct
        public async Task DeleteProduct(Guid id)
        {
            var param = new SqlParameter("@Id", id);
            await _context.Database.ExecuteSqlRawAsync("EXEC SpDeleteProduct @Id", param);
        }

        //Get all products using SpGetAllProducts
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products
                 .FromSqlRaw("EXEC SpGetAllProducts")
                 .ToListAsync();
        }

        //Get product by ID using SpGetProductById

        public async Task<Product> GetProductById(Guid id)
        {
            var param = new SqlParameter("@Id", id);
            return await _context.Products
                 .FromSqlRaw("EXEC SpaGetProductById @Id", param)
                 .FirstOrDefaultAsync();

        }

        // Update product using SpUpdateProduct
        public async Task UpdateProduct(Product product)
        {
            var parameters = new[]
            {
                new SqlParameter("@Id", product.Id),
                new SqlParameter("@Name", product.Name),
                new SqlParameter("@Price", product.Price),
                new SqlParameter("@Quantity", product.Quantity)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC SpUpdateProduct @Id, @Name, @Price, @Quantity", parameters);
        }
    }
}
