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
            Id = 1,
            Name = "username",
            Password = "password",
            Phone = "phone"
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
            Id = 1,
            Name = "username",
            Password = "password",
            Phone = "phone"
        };
        
        UserHandler.SetUser(user);
        
        Assert.That(UserHandler.GetUser(), Is.Not.Null);
        Assert.That(UserHandler.GetUser(), Is.EqualTo(user));
        
        UserHandler.Logout();
        
        Assert.That(UserHandler.GetUser(), Is.Null);
    }
}