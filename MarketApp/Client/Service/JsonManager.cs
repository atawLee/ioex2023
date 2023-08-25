using System.Text.Json;

namespace MarketApp.Client.Service;

public class JsonManager
{
    public static JsonSerializerOptions DefaultSerializerOptions = new ()
        { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
}