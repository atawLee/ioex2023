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

    public void AddCart(int userId, int productId, int qty)
    {
        Cart cart = new()
        {
            UserId = userId,
            ProductId = productId,
            Quantity = qty,
        };
        _repository.AddCart(cart);

        
    }
    
    

    public void UpdateCart(int paramUserId, int paramProductId, int paramQty)
    {
        Cart cartToUpdate = new Cart
        {
            UserId = paramUserId,
            ProductId = paramProductId,
            Quantity = paramQty
        };

        // 레포지토리의 UpdateCart 메서드를 호출합니다.
         _repository.UpdateCart(cartToUpdate); // _cartRepository는 레포지토리 인스턴스라고 가정

    }
}