using MarketApp.Server.Database.Entity;

namespace MarketApp.Server.Repository.Interface;

public interface IAccountRepository
{
    public void CreateUser(User user);

    public User GetUser(User user);
}