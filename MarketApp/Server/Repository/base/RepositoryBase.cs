using MarketApp.Server.Database.Context;

namespace MarketApp.Server.Repository;

public class RepositoryBase
{
    private readonly CornMarketContext _context;

    public RepositoryBase(CornMarketContext context)
    {
        _context = context;
    }
}