namespace MarketApp.Shared;

public class UserDto
{
    public string UserEmail { get; set; }
    public string JwtToken { get; set; }
    
    public string Role { get; set; }
}
public class CartDto
{
    public int CartId { get; set; }
    public int Quantity { get; set; }
    public ProductDto Product { get; set; }
}
public class ProductDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public decimal Price { get; set; }
    public string Content { get; set; }
    public string ImageUrl { get; set; }
    public DateTime RegistrationDate { get; set; }
    
}
public class CategoryDto
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}
