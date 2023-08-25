using MarketApp.Shared;

namespace MarketApp.Client.Service;

public class UserStateManager
{
    private readonly HttpClient _httpClient;

    public UserStateManager(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    private UserDto _userInfo;

    public UserDto UserInfo
    {
        get => _userInfo;
        set
        {
            _userInfo = value;  
            if (_userInfo != null && !string.IsNullOrEmpty(_userInfo.JwtToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = 
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _userInfo.JwtToken);
            }
            else
            {
                _httpClient.DefaultRequestHeaders.Authorization = null;
            }
            NotifyStateChanged();
        } 
    }
    public bool IsLogin { get; set; }
    public event Action OnChange;
    private void NotifyStateChanged() => OnChange?.Invoke();
}