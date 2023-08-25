using MarketApp.Shared;

namespace MarketApp.Client.Service;

public class UserStateService
{
    public UserDto UserInfo { get; set; }
    
    public bool IsLogin { get; set; }
}