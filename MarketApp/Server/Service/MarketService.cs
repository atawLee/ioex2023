using MarketApp.Server.Repository;
using MarketApp.Server.Repository.Interface;
using MarketApp.Shared;

namespace MarketApp.Server.Service;

public class MarketService
{
    private readonly IMarketRepository _repository;

    public MarketService(IMarketRepository repository)
    {
        _repository = repository;
    }

    public List<ProductDto> GetProductByCategoryId(int categoryId)
    {
        return _repository.GetProductByCategory(categoryId)
            .Select(x => DtoConverter.ConvertToDto(x))
            .ToList();
    }

    public List<ProductDto> GetProduct()
    {
        return _repository.GetProduct()
            .Select(x => DtoConverter.ConvertToDto(x))
            .ToList();
    }

    public List<CategoryDto> GetCategory()
    {
        return (List<CategoryDto>)_repository.GetCategory()
            .Select(x => new CategoryDto
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName
            }).ToList();
    }
}