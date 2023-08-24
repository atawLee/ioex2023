using MarketApp.Server.Database.Context;
using MarketApp.Server.Database.Entity;
using MarketApp.Server.Repository.Interface;

namespace MarketApp.Server.Repository;

public class AccountRepository : RepositoryBase,IAccountRepository
{
    public AccountRepository(CornMarketContext context) : base(context)
    {
    }
    
    public void CreateUser(User user)
    {
        throw new NotImplementedException();
    }

    public User GetUser(User user)
    {
        throw new NotImplementedException();
    }

    
}