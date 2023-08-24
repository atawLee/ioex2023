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
        var org = _context.Users.FirstOrDefault(x => x.Email == user.Email);
        if (org is not null) throw new Exception("중복된 사용자");
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public User GetUser(string email, string passwordHash)
    {
        var user = _context.Users.FirstOrDefault(x => x.Email == email && x.Password == passwordHash);
        if (user is null) throw new Exception("이메일 또는 패스워드 확인");
        return user;
    }

    
}