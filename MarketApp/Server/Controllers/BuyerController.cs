using MarketApp.Server.Service;
using MarketApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MarketApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class BuyerController : ControllerBase
{
    private readonly BuyerService _service;

    public BuyerController(BuyerService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("{userId}")]
    public List<CartDto> Carts(int userId)
    {
        return _service.GetCarts(userId);
    }

    [HttpPost]
    public CartDto AddCart([FromBody] CartInfoRequest param)
    {
        return _service.AddCart(param.userId,param.productId,param.qty );
    }
}