using MarketApp.Server.Database.Context;
using MarketApp.Server.Database.Entity;
using MarketApp.Server.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MarketApp.Server.Repository;

public class MarketRepository :RepositoryBase, IMarketRepository
{
    
    public MarketRepository(CornMarketContext context) : base(context)
    {
    }
    
    
    public List<Product> GetProductByCategory(int categoryId)
    {
        return _context.Products.Include(x=>x.Category)
            .Where(x => x.CategoryId == categoryId).ToList();
    }
    
    public List<Product> GetProduct()
    {
        return _context.Products.Include(x => x.Category)
            .ToList();
    }

    public List<Category> GetCategory()
    {
        return _context.Categories.ToList();
    }

    
}