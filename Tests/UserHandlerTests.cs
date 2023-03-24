using CineMoviesWeb.Models;
using DevOpsCineMovies.Entities;

namespace Tests;

public class UserHandlerTests
{
    [Test]
    public void SetUser()
    {
        var user = new User
        {
            Phone = "phone",
            Name = "username",
            Password = "password",
        };
        
        UserHandler.SetUser(user);
        
        Assert.That(UserHandler.GetUser(), Is.Not.Null);
        Assert.That(UserHandler.GetUser(), Is.EqualTo(user));
    }
    
    [Test]
    public void Logout()
    {
        var user = new User
        {
            Phone = "phone",
            Name = "username",
            Password = "password",
        };
        
        UserHandler.SetUser(user);
        
        Assert.That(UserHandler.GetUser(), Is.Not.Null);
        Assert.That(UserHandler.GetUser(), Is.EqualTo(user));
        
        UserHandler.Logout();
        
        Assert.That(UserHandler.GetUser(), Is.Null);
    }
}