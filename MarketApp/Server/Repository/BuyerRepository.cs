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
        return _context.Carts.Where(x => x.UserId == userId).ToList();
    }

    public Cart AddCart(Cart cart)
    {
        _context.Carts.Add(cart);
        _context.SaveChanges();
        return cart;
    }

    
}