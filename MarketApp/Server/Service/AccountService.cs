using MarketApp.Server.Repository.Interface;

namespace MarketApp.Server.Service;

public class AccountService
{
    private readonly IAccountRepository _repository;

    public AccountService(IAccountRepository repository)
    {
        _repository = repository;
    }
    
    
    
}
