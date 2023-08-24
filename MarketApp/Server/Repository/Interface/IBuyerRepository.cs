using MarketApp.Server.Database.Entity;

namespace MarketApp.Server.Repository.Interface;

public interface IBuyerRepository
{
    public List<Cart> GetCart(int userId);

    public Cart AddCart(Cart cart);

}