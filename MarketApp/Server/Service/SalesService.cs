using MarketApp.Server.Database.Entity;
using MarketApp.Server.Repository;
using MarketApp.Server.Repository.Interface;
using MarketApp.Shared;

namespace MarketApp.Server.Service;

public class SalesService
{
    private readonly ISalesRepository _repository;

    public SalesService(ISalesRepository repository)
    {
        _repository = repository;
    }

    public ProductDto AddProduct(int userId, string productName , int categoryId, int price, string content, string imageUrl )
    {
        Product product = new()
        {
            ProductId = 0,
            UserId = userId,
            ProductName = productName,
            CategoryId = categoryId,
            Price = price,
            Content = content,
            ImageUrl = imageUrl,
            RegistrationDate = DateTime.Now,
            IsActive = true,
        };
        _repository.AddProduct(product);
        return DtoConverter.ConvertToDto(product);
    }
    public List<ProductDto> GetSalesProduct(int userId)
    {
        return 
        _repository.GetSalesProducts(userId)
            .Select(x => DtoConverter.ConvertToDto(x))
            .ToList();
    }

    public void DeleteProduct(int productId)
    {
        Product product = new()
        {
            ProductId = productId
        };
        _repository.DeleteProduct(product);
    }

    public void UpdateProduct(int productId, int category, int price, string productName)
    {
        Product product = new()
        {
            ProductId = 0,
            UserId = null,
            ProductName = null,
            CategoryId = null,
            Price = 0,
            Content = null,
            ImageUrl = null,
            RegistrationDate = default,
            IsActive = true,
            Carts = null,
            Category = null,
            User = null
        };
    }

}