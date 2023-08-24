using MarketApp.Server.Repository.Interface;

namespace MarketApp.Server.Service;

public class SalesService
{
    private readonly ISalesRepository _repository;

    public SalesService(ISalesRepository repository)
    {
        _repository = repository;
    }
}