using MarketApp.Server.Database.Context;
using MarketApp.Server.Database.Entity;
using MarketApp.Server.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MarketApp.Server.Repository;

public class BuyerRepository : RepositoryBase,IBuyerRepository
{
    public BuyerRepository(CornMarketContext context) : base(context)
    {
    }
    
    public List<Cart> GetCart(int userId)
    {
        var items= 
            _context.Carts
            .Include(x => x.Product)
            .ThenInclude(x => x.Category).ToList();

        return items;
    }

    public Cart AddCart(Cart cart)
    {
        _context.Carts.Add(cart);
        _context.SaveChanges();
        return cart;
    }

    
}