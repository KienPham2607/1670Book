using _1670Book.Data;
using _1670Book.Models;
using Microsoft.EntityFrameworkCore;

namespace _1670Book.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _context;
        public HomeRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> Categories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts (string sTerm = "", int categoryId = 0)
        {
            sTerm = sTerm.ToLower();
            IEnumerable<Product> products = await (from product in _context.Products
                            join category in _context.Categories
                            on product.IdCategory equals category.Id
                            where string.IsNullOrWhiteSpace(sTerm) || (product != null && product.Name.ToLower().StartsWith(sTerm))
                            select new Product
                            {
                                Id = product.Id,
                                Name = product.Name,
                                Price = product.Price,
                                //Quantity = product.Quantity,
                                Image = product.Image,
                                IdCategory = categoryId,
                                CategoryName = product.CategoryName
                            }).ToListAsync();
            if(categoryId > 0)
            {
                products = products.Where(a=>a.IdCategory == categoryId).ToList();
            }
            return products;
        }
    }
}
