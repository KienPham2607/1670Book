using _1670Book.Models;

namespace _1670Book
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Product>> GetProducts(string sTerm = "", int categoryId = 0);
        Task<IEnumerable<Category>> Categories();
    }
}