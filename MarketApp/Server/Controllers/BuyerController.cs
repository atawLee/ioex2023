using System.Security.Claims;
using MarketApp.Server.Service;
using MarketApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MarketApp.Server.Controllers;

[ApiController]
[Route("Buy")]
[Authorize]
public class BuyerController : ControllerBase
{
    private readonly BuyerService _service;
    private int UserId =>int.Parse(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value ?? "0");

    public BuyerController(BuyerService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("~/Cart")]
    public List<CartDto> Carts()
    {
        return _service.GetCarts(this.UserId);
    }

    [HttpPost]
    public void AddCart([FromBody] CartInfoRequest param)
    { 
        _service.AddCart(this.UserId,param.productId,param.qty );
    }

    [HttpPut]
    [Route("~/Cart")]
    public void UpdateCart([FromBody] CartInfoRequest param)
    {
        _service.UpdateCart(this.UserId, param.productId, param.qty);
    }
}