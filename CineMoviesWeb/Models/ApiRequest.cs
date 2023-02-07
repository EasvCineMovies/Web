using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CineMoviesWeb.Models;

public class ApiRequest
{
    private static readonly HttpClient _client = new();
    private const string URL = "https://easvcinemovies.azurewebsites.net/";
    
    public static async Task<string?> Greet()
    {
        var response = await _client.GetStringAsync(URL+nameof(Greet));
        Console.WriteLine(response);
        return response;
    }
}