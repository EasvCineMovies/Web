using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace CineMoviesWeb.Models;

public class ApiRequest
{
    private const string URL = "https://easvcinemovies.azurewebsites.net/";
    private readonly HttpClient _client = new();

    public async Task<T?> Invoke<T>(Dictionary<T,T> body, [CallerMemberName] string memberName = "") where T : notnull
    {
        var json = JsonConvert.SerializeObject(body);
        
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(URL+memberName),
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };
        
        var response = await _client.SendAsync(request);

        return !response.IsSuccessStatusCode ? default : JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
    }
}