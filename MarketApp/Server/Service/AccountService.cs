using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using MarketApp.Server.Database.Entity;
using MarketApp.Server.Repository.Interface;
using MarketApp.Shared;
using Microsoft.IdentityModel.Tokens;

namespace MarketApp.Server.Service;

public class AccountService
{
    private readonly IConfiguration _configuration;
    private readonly IAccountRepository _repository;

    public AccountService(IConfiguration configuration, IAccountRepository repository)
    {
        _configuration = configuration;
        _repository = repository;
    }

    public void SignUp(string email, string userName, string userRole, string password)
    {
        User user = new()
        {
            Email = email,
            Password = HashPassword(password),
            Role = userRole,
            Username = userName,
        };
        _repository.CreateUser(user);

    }

    public UserDto SignIn(string email, string password)
    {
        var user = _repository.GetUser(email, HashPassword(password));
        var token = GenerateJWTToken(user);
        UserDto dto = new()
        {
            UserEmail = user.Email,
            JwtToken = token,
            Role = user.Role,
        };
        return dto;
    }

    private string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashedBytes.Length; i++)
            {
                builder.Append(hashedBytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }

    private string GenerateJWTToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("email", user.Email),
            new Claim("UserID", user.UserId.ToString()),
            new Claim("UserName", user.Username)
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(24),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}
    

