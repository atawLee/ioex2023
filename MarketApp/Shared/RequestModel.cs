using Microsoft.AspNetCore.Http;

namespace MarketApp.Shared;

public record ProductUpdateRequest(

    int productId,
    string productName,
    int categoryId,
    int price,
    string content);


public record ProductPostRequest(    IFormFile file,int userid, int category, int price, string productName,string content);

public record CartInfoRequest(int userId, int productId, int qty);

public record SignInRequest(string email, string password);
public record SignUpRequest(string email ,string userName ,string userRole , string password );