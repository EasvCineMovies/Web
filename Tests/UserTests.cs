using CineMoviesWeb.Models;
using DevOpsCineMovies.Entities;

namespace Tests;

public class UserTests
{
    private string _userToDeletePhone;
    
    [Test]
    public async Task CreateUser()
    {
        var response = await ApiRequestAdapter.CreateUser("phone", "name", "email", "password");
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(User)));
        
        _userToDeletePhone = response.Phone;
    }
    
    [Test]
    public async Task ReadUser()
    {
        var response = await ApiRequestAdapter.ReadUser("bobthephone");
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(User)));
    }
    
    [Test]
    public async Task UpdateUser()
    {
        var response = await ApiRequestAdapter.UpdateUser("bobthephone", "bobthename", "bobtheemail", PasswordHelper.HashPassword("bobthepassword"));
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(User)));
    }
    
    [Test]
    public async Task DeleteUser()
    {
        var response = await ApiRequestAdapter.DeleteUser(_userToDeletePhone);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(User)));
    }

    [Test]
    public async Task LoginUser()
    {
        var response = await ApiRequestAdapter.LoginUser("bobthephone", "bobthepassword");
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(User)));
    }
}