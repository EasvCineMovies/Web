using CineMoviesWeb.Models;
using DevOpsCineMovies.Entities;

namespace Tests;

public class SeatTests
{
    private int _seatToDeleteId;
    
    [Test]
    public async Task CreateSeat()
    {
        var response = await ApiRequestAdapter.CreateSeat(1, 1, 1);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(Seat)));
        
        _seatToDeleteId = response.Id ?? 0;
    }
    
    [Test]
    public async Task ReadSeat()
    {
        var response = await ApiRequestAdapter.ReadSeat(9);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(Seat)));
    }
    
    [Test]
    public async Task ReadAllSeats()
    {
        var response = await ApiRequestAdapter.ReadAllSeats(1);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(List<Seat>)));
    }
    
    [Test]
    public async Task UpdateSeat()
    {
        var response = await ApiRequestAdapter.UpdateSeat(9, 1, 1, 1);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(Seat)));
    }
    
    [Test]
    public async Task DeleteSeat()
    {
        var response = await ApiRequestAdapter.DeleteSeat(_seatToDeleteId);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(Seat)));
    }
}