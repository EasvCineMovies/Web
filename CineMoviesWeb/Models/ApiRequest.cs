using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CineMoviesWeb.Models;

public class ApiRequest
{
    private const string URL = "https://easvcinemovies.azurewebsites.net/";
    private readonly HttpClient _client = new();

    public async Task<T> Invoke<T>(Dictionary<string, object> body, string path) where T : notnull
    {
        var json = JsonConvert.SerializeObject(body);

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(URL + path),
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };

        HttpResponseMessage response = await _client.SendAsync(request);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Error calling {path}: {response.StatusCode}");

        var stringResponse = await response.Content.ReadAsStringAsync();
        
        var status = JObject.Parse(stringResponse)["status"]?.ToString();
        var message = JObject.Parse(stringResponse)["message"]?.ToString();
        var data = JObject.Parse(stringResponse)["data"];

        if (status == null || message == null)
            throw new Exception($"Error calling {path}: {stringResponse}");

        if (status != "success")
            throw new Exception($"Call to {path} failed: {message}");

        if (data == null)
            throw new Exception($"There is no data in the response from {path}");

        var converted = data.ToObject<T>();
        if (converted == null)
            throw new Exception($"Error converting data from {path} to {typeof(T).Name}");
        
        return converted;
    }
}