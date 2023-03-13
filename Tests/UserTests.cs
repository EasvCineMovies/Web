using CineMoviesWeb.Models;
using DevOpsCineMovies.Entities;

namespace Tests;

public class UserTests
{
    private int _userToDeleteId;
    
    [Test]
    public async Task CreateUser()
    {
        var response = await ApiRequestAdapter.CreateUser("name", "phone", "email", "password");
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(User)));
        
        _userToDeleteId = response.Id;
    }
    
    [Test]
    public async Task ReadUser()
    {
        var response = await ApiRequestAdapter.ReadUser(3);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(User)));
    }
    
    [Test]
    public async Task UpdateUser()
    {
        var response = await ApiRequestAdapter.UpdateUser(3, "name", "phone", "email", "password");
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(User)));
    }
    
    [Test]
    public async Task DeleteUser()
    {
        var response = await ApiRequestAdapter.DeleteUser(_userToDeleteId);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(User)));
    }
}