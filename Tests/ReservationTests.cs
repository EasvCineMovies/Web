using CineMoviesWeb.Models;
using DevOpsCineMovies.Entities;

namespace Tests;

public class ReservationTests
{
    private int _reservationToDeleteId;
    
    [Test]
    public async Task CreateReservation()
    {
        var response = await ApiRequestAdapter.CreateReservation(3, 9, 1, 1, 5, 499, DateTime.Now);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(Reservation)));
        
        _reservationToDeleteId = response.Id;
    }
    
    [Test]
    public async Task ReadReservation()
    {
        var response = await ApiRequestAdapter.ReadReservation(3);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(List<Reservation>)));
    }
    
    [Test]
    public async Task UpdateReservation()
    {
        var response = await ApiRequestAdapter.UpdateReservation(11, 3, 9, 1, 1, 5, 499, DateTime.Now);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(Reservation)));
    }
    
    [Test]
    public async Task DeleteReservation()
    {
        var response = await ApiRequestAdapter.DeleteReservation(_reservationToDeleteId);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(Reservation)));
    }
    
}