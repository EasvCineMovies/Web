using CineMoviesWeb.Models;
using DevOpsCineMovies.Entities;

namespace Tests;

public class CinemaTests
{
    private int _cinemaToDeleteId;
    
    [Test]
    public async Task CreateCinema()
    {
        var response = await ApiRequestAdapter.CreateCinema("CineMovies", "Address asd");
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(Cinema)));
        
        _cinemaToDeleteId = response.Id;
    }
    
    [Test]
    public async Task ReadCinema()
    {
        var response = await ApiRequestAdapter.ReadCinema(1);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(Cinema)));
    }
    
    [Test]
    public async Task UpdateCinema()
    {
        var response = await ApiRequestAdapter.UpdateCinema(1, "CineMovies", "Address asd");
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(Cinema)));
    }
    
    [Test]
    public async Task DeleteCinema()
    {
        var response = await ApiRequestAdapter.DeleteCinema(_cinemaToDeleteId);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(Cinema)));
    }
}