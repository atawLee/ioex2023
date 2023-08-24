using MarketApp.Server.Database.Entity;

namespace MarketApp.Server.Repository.Interface;

public interface ISalesRepository
{
    public Product AddProduct(Product product);

    public List<Product> GetSalesProducts(int userId);

    public void DeleteProduct(Product product);

    public void UpdateProduct(Product product);
}