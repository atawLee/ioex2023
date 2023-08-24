using MarketApp.Server.Database.Context;
using MarketApp.Server.Database.Entity;
using MarketApp.Server.Repository.Interface;

namespace MarketApp.Server.Repository;

public class MarketRepository :RepositoryBase, IMarketRepository
{
    
    public MarketRepository(CornMarketContext context) : base(context)
    {
    }
    
    
    public List<Product> GetProductByCategory(int categoryId)
    {
        throw new NotImplementedException();
    }
    
    public List<Product> GetProduct()
    {
        throw new NotImplementedException();
    }

    public List<Category> GetCategory()
    {
        throw new NotImplementedException();
    }

    
}