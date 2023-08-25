using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MarketApp.Server.Repository.Policy;
public static class Polices
{
    public const string User = "User";
    public const string Seller = "Seller";

    public static Action<AuthorizationPolicyBuilder> UserPolicy()
    {
        return policy => policy.RequireClaim(ClaimTypes.Role, "User");
    }

    public static Action<AuthorizationPolicyBuilder> SellerPolicy()
    {
        return policy => policy.RequireClaim(ClaimTypes.Role, "Seller");
    }
}
