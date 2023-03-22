using CineMoviesWeb.Models;

namespace Tests;

public class PasswordHelperTests
{
    [Test]
    public void HashPassword()
    {
        var password = "password";
        var hashedPassword = PasswordHelper.HashPassword(password);
        
        Assert.That(hashedPassword, Is.Not.Null);
        Assert.That(hashedPassword, Is.Not.EqualTo(password));
    }
    
    [Test]
    public void ComparePassword()
    {
        var password = "password";
        var hashedPassword = PasswordHelper.HashPassword(password);
        
        Assert.That(hashedPassword, Is.Not.Null);
        Assert.That(hashedPassword, Is.Not.EqualTo(password));
        
        var comparePassword = PasswordHelper.ComparePassword(password, hashedPassword);
        
        Assert.That(comparePassword, Is.True);
    }
}