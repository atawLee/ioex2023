using MarketApp.Server.Database.Context;
using MarketApp.Server.Database.Entity;
using MarketApp.Server.Repository.Interface;

namespace MarketApp.Server.Repository;

public class SalesRepository : RepositoryBase ,ISalesRepository
{
    public SalesRepository(CornMarketContext context) : base(context)
    {
    }
    
    public Product AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetSalesProducts(int userId)
    {
        throw new NotImplementedException();
    }

    public void DeleteProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public void UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }

    
}