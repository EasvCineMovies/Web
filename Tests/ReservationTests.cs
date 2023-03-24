using CineMoviesWeb.Models;
using DevOpsCineMovies.Entities;

namespace Tests;

public class ReservationTests
{
    private int _reservationToDeleteId;
    
    [Test]
    public async Task CreateReservation()
    {
        var response = await ApiRequestAdapter.CreateReservation("bobthephone", 1, 1, 1, 1, 499, DateTime.Now);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(Reservation)));
        
        _reservationToDeleteId = response.Id;
    }
    
    [Test]
    public async Task ReadReservation()
    {
        var response = await ApiRequestAdapter.ReadReservation("bobthephone");
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(List<Reservation>)));
    }
    
    [Test]
    public async Task UpdateReservation()
    {
        var response = await ApiRequestAdapter.UpdateReservation(1, "bobthephone", 1, 1, 1, 1, 499, DateTime.Now);
        
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