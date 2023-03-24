using CineMoviesWeb.Models;
using DevOpsCineMovies.Entities;

namespace Tests;

public class ScheduleTests
{
    private int _scheduleToDeleteId;
    
    [Test]
    public async Task CreateSchedule()
    {
        var response = await ApiRequestAdapter.CreateSchedule(1, 1, DateTime.Now, DateTime.Now);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(Schedule)));
        
        _scheduleToDeleteId = response.Id;
    }
    
    [Test]
    public async Task ReadSchedule()
    {
        var response = await ApiRequestAdapter.ReadSchedule(1);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(List<Schedule>)));
    }
    
    [Test]
    public async Task UpdateSchedule()
    {
        var response = await ApiRequestAdapter.UpdateSchedule(1, 1, 1, DateTime.Now, DateTime.Now);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(Schedule)));
    }
    
    [Test]
    public async Task DeleteSchedule()
    {
        var response = await ApiRequestAdapter.DeleteSchedule(_scheduleToDeleteId);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.GetType(), Is.EqualTo(typeof(Schedule)));
    }
    
}