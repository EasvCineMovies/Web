using CineMoviesWeb.Models;
using DevOpsCineMovies.Entities;

namespace Tests;

public class MovieTests
{
    private int _movieToDeleteId;
    
    [Test]
    public async Task CreateMovie()
    {
        var response = await ApiRequestAdapter.CreateMovie("Movie", "Description", "Genre", 120, 1);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(Movie)));
        
        _movieToDeleteId = response.Id;
    }
    
    [Test]
    public async Task ReadMovie()
    {
        var response = await ApiRequestAdapter.ReadMovie(1);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(Movie)));
    }
    
    [Test]
    public async Task ReadAllMovie()
    {
        var response = await ApiRequestAdapter.ReadAllMovie(1);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(List<Movie>)));
    }
    
    [Test]
    public async Task UpdateMovie()
    {
        var response = await ApiRequestAdapter.UpdateMovie(1, "Movie", "Description", "Genre", 120, 1);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(Movie)));
    }
    
    [Test]
    public async Task DeleteMovie()
    {
        var response = await ApiRequestAdapter.DeleteMovie(_movieToDeleteId);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(Movie)));
    }
}