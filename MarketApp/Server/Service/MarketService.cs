using MarketApp.Server.Repository.Interface;

namespace MarketApp.Server.Service;

public class MarketService
{
    private readonly IMarketRepository _repository;

    public MarketService(IMarketRepository repository)
    {
        _repository = repository;
    }
}