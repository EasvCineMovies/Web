namespace CineMoviesWeb.Models;

public class Adapter
{
    private static readonly ApiRequest ApiRequest = new();

    public static async Task<string?> Greet(dynamic body)
    {
        var dictionary = new Dictionary<string, string>
        {
            {"greeting", body.greeting}
        };
        return await ApiRequest.Invoke(dictionary);
    }
}