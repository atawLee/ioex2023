using MarketApp.Server.Database.Entity;
using MarketApp.Server.Repository;
using MarketApp.Server.Repository.Interface;
using MarketApp.Shared;

namespace MarketApp.Server.Service;

public class BuyerService
{
    private readonly IBuyerRepository _repository;

    public BuyerService(IBuyerRepository repository)
    {
        _repository = repository;
    }

    public List<CartDto> GetCarts(int userId)
    {
        return _repository.GetCart(userId)
            .Select(x => DtoConverter.ConvertToDto(x)).ToList();
    }

    public CartDto AddCart(int userId, int productId, int qty)
    {
        Cart cart = new()
        {
            UserId = userId,
            ProductId = productId,
            Quantity = qty,
        };
        _repository.AddCart(cart);

        return DtoConverter.ConvertToDto(cart);
    }
}