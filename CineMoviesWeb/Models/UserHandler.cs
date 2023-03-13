using DevOpsCineMovies.Entities;

namespace CineMoviesWeb.Models;

public abstract class UserHandler
{
    private static User? _user;
    public static void SetUser(User user)
    {
        _user = user;
    }
    public static User? GetUser()
    {
        return _user;
    }
    
    public static void Logout()
    {
        _user = null;
    }
}