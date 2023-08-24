using MarketApp.Server.Service;
using MarketApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketApp.Server.Controllers;
[ApiController]
[Route("[contoller]")]
[Authorize("Seller")]
public class SalesController: ControllerBase
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly SalesService _service;

    public SalesController(IWebHostEnvironment webHostEnvironment ,SalesService service)
    {
        _webHostEnvironment = webHostEnvironment;
        _service = service;
    }

    [HttpPost]
    public ProductDto RegistSalesProduct([FromForm] ProductPostRequest param)
    {
       
        var dto = _service.AddProduct(param.userid, param.productName, param.category, param.price, param.content);
        
        string imageUrl = null; // 이 변수에 URL을 저장할 것입니다.

        if (param.file != null && param.file.Length > 0)
        {
            // 웹 루트 경로 가져오기
            var webRoot = _webHostEnvironment.WebRootPath;
            
            // 파일 확장자 가져오기
            var extension = Path.GetExtension(param.file.FileName);

            // 저장 경로 설정
            var filePath = Path.Combine(webRoot, "images", $"{dto.ProductId}{extension}");
            imageUrl = Path.Combine("images", $"{dto.ProductId}{extension}");

            var dir = Path.Combine(webRoot, "images");
            // 파일 저장
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Directory.CreateDirectory(dir);
                param.file.CopyTo(fileStream);
            }

            _service.UpdateUrl(dto.ProductId, imageUrl);
            dto.ImageUrl = imageUrl;
        }

        return dto;
    }

    [HttpGet]
    [Route("{userId}")]
    public List<ProductDto> SalesProduct([FromQuery] int userId)
    {
        return _service.GetSalesProduct(userId);
    }

    [HttpDelete]
    [Route("{productId}")]
    public void RemoteProduct([FromQuery] int productId)
    {
        _service.DeleteProduct(productId);
    }

    [HttpPut]
    public void UpdateProduct([FromBody] ProductUpdateRequest param)
    {
        _service.UpdateProduct(param.productId,param.categoryId,param.price,param.productName);
    }
    
}