using System.Security.Claims;
using MarketApp.Server.Repository.Policy;
using MarketApp.Server.Service;
using MarketApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketApp.Server.Controllers;
[ApiController]
[Route("[controller]")]
[Authorize(Policy = Polices.Seller)]
public class SalesController: ControllerBase
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly SalesService _service;
    
    private int UserId => int.Parse(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value ?? "0");


    public SalesController(IWebHostEnvironment webHostEnvironment ,SalesService service)
    {
        _webHostEnvironment = webHostEnvironment;
        _service = service;
    }

    [HttpPost]
    [Route("~/Regist")]
    public ProductDto RegistSalesProduct([FromForm] ProductPostRequest param)
    {
       
        var dto = _service.AddProduct(this.UserId, param.productName, param.category, param.price, param.content);
        
        string imageUrl = null; // 이 변수에 URL을 저장할 것입니다.

        if (param.file != null && param.file.Length > 0)
        {
            //클라이언트 정적 파일루트 
            //발표용 파일루트 설정입니다.
#if Conference
            var webRoot = "/Users/leejonghoon/RiderProjects/MarketApp/MarketApp/Client/wwwroot";
            
            // 파일 확장자 가져오기
            var extension = Path.GetExtension(param.file.FileName);

            // 저장 경로 설정
            var filePath = Path.Combine(webRoot, "images", $"{dto.ProductId}{extension}");
            imageUrl = Path.Combine("images", $"{dto.ProductId}{extension}");

            var dir = Path.Combine(webRoot, "images");
            // 파일 저장
            Directory.CreateDirectory(dir);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                
                param.file.CopyTo(fileStream);
            }

            _service.UpdateUrl(dto.ProductId, imageUrl);
            dto.ImageUrl = imageUrl;
#endif
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
