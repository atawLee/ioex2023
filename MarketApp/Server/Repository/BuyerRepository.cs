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
        // 동일한 유저 및 상품 아이디로 기존 카트 아이템을 찾습니다.
        var existingCart = _context.Carts
            .Where(c => c.UserId == cart.UserId && c.ProductId == cart.ProductId)
            .FirstOrDefault();

        // 같은 상품이 이미 카트에 있다면 수량을 추가합니다.
        if (existingCart != null)
        {
            existingCart.Quantity += cart.Quantity;
        }
        else
        {
            // 없다면 새로운 아이템을 카트에 추가합니다.
            _context.Carts.Add(cart);
        }

        // 데이터베이스를 업데이트합니다.
        _context.SaveChanges();

        return existingCart != null ? existingCart : cart;
    }

    public Cart UpdateCart(Cart cart)
    {
        // 기존 카트 항목을 찾습니다.
        var existingCart = _context.Carts
            .Where(c => c.UserId == cart.UserId && c.ProductId == cart.ProductId)
            .FirstOrDefault();

        // 해당 항목이 존재하는지 검사합니다.
        if (existingCart == null)
        {
            // 존재하지 않으면 null을 반환하거나 예외를 발생시킬 수 있습니다.
            return null;
        }

        // 수량을 업데이트합니다.
        existingCart.Quantity = cart.Quantity;
        // 변경사항을 저장합니다.
        _context.SaveChanges();

        return existingCart;
    }

    


    
}