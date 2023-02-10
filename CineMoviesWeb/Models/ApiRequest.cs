using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;
using RestSharp;

namespace CineMoviesWeb.Models;

public class ApiRequest
{
    private const string URL = "https://easvcinemovies.azurewebsites.net/";
    private readonly HttpClient Client = new();

    public async Task<T?> Invoke<T>(Dictionary<T,T> body, [CallerMemberName] string memberName = "") where T : notnull
    {
        var json = JsonConvert.SerializeObject(body);
        
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(URL+memberName),
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };
        
        var response = await Client.SendAsync(request);

        return !response.IsSuccessStatusCode ? default : JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
    }
}