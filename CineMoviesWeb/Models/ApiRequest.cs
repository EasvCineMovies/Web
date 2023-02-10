using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using RestSharp;

namespace CineMoviesWeb.Models;

public class ApiRequest
{
    private const string URL = "https://easvcinemovies.azurewebsites.net/";
    private static readonly HttpClient _client = new();

    public static async Task<string?> Greet()
    {
        var body = new Dictionary<string, string>
        {
            { "greeting", "Hello World!" }
        };
        
        var json = JsonConvert.SerializeObject(body);
        
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(URL+nameof(Greet)),
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };
        
        var response = await _client.SendAsync(request);

        if (!response.IsSuccessStatusCode) return null;
        
        return await response.Content.ReadAsStringAsync();

    }
}