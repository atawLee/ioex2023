using MarketApp.Server.Repository.Interface;

namespace MarketApp.Server.Service;

public class BuyerService
{
    private readonly IBuyerRepository _repository;

    public BuyerService(IBuyerRepository repository)
    {
        _repository = repository;
    }
}