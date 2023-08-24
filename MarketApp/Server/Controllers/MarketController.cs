using MarketApp.Server.Service;
using MarketApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketApp.Server.Controllers;
[ApiController]
[Route("[controller]")]
[Authorize]
public class MarketController: ControllerBase
{
    private readonly MarketService _service;

    public MarketController(MarketService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("{categoryId}")]
    public List<ProductDto> GetProduct([FromQuery] int categoryId)
    {
        return _service.GetProductByCategoryId(categoryId);
    }

    [HttpGet]
    public List<ProductDto> GetProduct()
    {
        return _service.GetProduct();
    }

    [HttpGet]
    [Route("~/category")]
    public List<CategoryDto> GetCategory()
    {
        return _service.GetCategory();
    }
}