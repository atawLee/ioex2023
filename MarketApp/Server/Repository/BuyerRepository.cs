using MarketApp.Server.Database.Context;
using MarketApp.Server.Database.Entity;
using MarketApp.Server.Repository.Interface;

namespace MarketApp.Server.Repository;

public class BuyerRepository : RepositoryBase,IBuyerRepository
{
    public BuyerRepository(CornMarketContext context) : base(context)
    {
    }
    
    public List<Cart> GetCart(int userId)
    {
        throw new NotImplementedException();
    }

    public Cart AddCart(Cart cart)
    {
        throw new NotImplementedException();
    }

    
}