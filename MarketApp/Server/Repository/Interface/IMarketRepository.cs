using MarketApp.Server.Database.Entity;

namespace MarketApp.Server.Repository.Interface;

public interface IMarketRepository
{
    public List<Product> GetProductByCategory(int categoryId);

    public List<Product> GetProduct();

    public List<Category> GetCategory();
}