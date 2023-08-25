using MarketApp.Server.Database.Context;

namespace MarketApp.Server.Repository;

public class RepositoryBase
{
    protected readonly CornMarketContext _context;

    public RepositoryBase(CornMarketContext context)
    {
        _context = context;
    }
    
}