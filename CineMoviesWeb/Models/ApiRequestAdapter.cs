using System.Runtime.CompilerServices;

namespace CineMoviesWeb.Models;

public abstract class ApiRequestAdapter
{
    private static readonly ApiRequest ApiRequest = new();
    
    private static void ValidateDictionary<T>(Dictionary<T, T?> dictionary, [CallerMemberName] string memberName = "") where T : notnull
    {
        if (dictionary.Any(x => x.Value == null))
        {
            throw new Exception($"Missing parameter: {dictionary.First(x => x.Value == null).Key} for method {memberName}");
        }
    }

    public static async Task<string?> Greet(dynamic body)
    {
        var dictionary = new Dictionary<string, string?>
        {
            {"greeting", body.greeting}
        };
       
        ValidateDictionary(dictionary);
        
        return await ApiRequest.Invoke(dictionary!);
    }
}