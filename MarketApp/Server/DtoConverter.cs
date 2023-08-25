using MarketApp.Server.Database.Entity;
using MarketApp.Shared;

namespace MarketApp.Server.Repository;

public class DtoConverter
{
    public static ProductDto ConvertToDto(Product product)
    {
        return new ProductDto
        {
            ProductId = product.ProductId,
            ProductName = product.ProductName,
            CategoryId = product.CategoryId ?? 0,
            CategoryName = product.Category?.CategoryName,
            Price = product.Price,
            Content =product.Content,
            ImageUrl = product.ImageUrl,
            RegistrationDate = product.RegistrationDate
        };
    }
    public static CartDto ConvertToDto(Cart cart)
    {
        return new CartDto
        {
            CartId = cart.CartId,

            Quantity = cart.Quantity,
            Product = new ProductDto
            {
                ProductId = cart.Product.ProductId,
                ProductName = cart.Product.ProductName,
                CategoryId = cart.Product?.CategoryId ?? 0,
                CategoryName = cart.Product.Category.CategoryName,
                Price = cart.Product.Price,
                Content = cart.Product.Content,
                ImageUrl = cart.Product.ImageUrl,
                RegistrationDate = cart.Product.RegistrationDate
            }
        };
    }
}