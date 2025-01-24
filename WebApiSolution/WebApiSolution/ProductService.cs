using Domain;
using Data;
using Microsoft.EntityFrameworkCore;
 /* Services:
Implement the ProductService class in the Services class library.
Include methods for CRUD operations on products.
 */
namespace Services
{
    public class ProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId)
        {
            return await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalPriceByCategoryId(int categoryId)
        {
            return await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .SumAsync(p => p.Price);
        }

        public async Task<Dictionary<string, decimal>> GetTotalPricePerCategory()
        {
            return await _context.Categories
                .Select(c => new
                {
                    c.Name,
                    TotalPrice = c.Products.Sum(p => p.Price)
                })
                .ToDictionaryAsync(x => x.Name, x => x.TotalPrice);
        }
    }
}