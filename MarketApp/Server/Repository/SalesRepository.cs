using MarketApp.Server.Database.Context;
using MarketApp.Server.Database.Entity;
using MarketApp.Server.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MarketApp.Server.Repository;

public class SalesRepository : RepositoryBase ,ISalesRepository
{
    public SalesRepository(CornMarketContext context) : base(context)
    {
    }
    
    public Product AddProduct(Product product)
    {
        _context.Products.Add(product);
        var category = _context.Categories.FirstOrDefault(x => x.CategoryId == product.CategoryId);
        _context.SaveChanges();
        product.Category = category;
        return product;
    }

    public List<Product> GetSalesProducts(int userId)
    {
        return _context.Products.Include(x => x.Category)
            .Where(x=>x.UserId == userId).ToList();
    }

    public void DeleteProduct(Product product)
    {
        _context.Products.Remove(product);
        _context.SaveChanges();
    }

    public void UpdateProduct(Product product)
    {
        var org = _context.Products.FirstOrDefault(x => x.ProductId == product.ProductId);
        org.CategoryId = product.CategoryId;
        org.Price = product.Price;
        org.ProductName = product.ProductName;
        _context.SaveChanges();
    }

    public void UpdateUrl(int productId, string imageUrl)
    {
        var first = _context.Products.FirstOrDefault(x => x.ProductId == productId);
        first.ImageUrl = imageUrl;
        _context.SaveChanges();
    }
}