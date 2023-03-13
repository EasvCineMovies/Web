using System.Globalization;
using DevOpsCineMovies.Entities;

namespace CineMoviesWeb.Models;

public abstract class ApiRequestAdapter
{
    private static readonly ApiRequest ApiRequest = new();
    
    public static async Task<Cinema> CreateCinema(string name, string address)
    {
        var body = new Dictionary<string, object>
        {
            { "name", name },
            { "address", address }
        };
        return await ApiRequest.Invoke<Cinema>(body, "cinema/create");
    }
    
    public static async Task<Cinema> ReadCinema(int id)
    {
        var body = new Dictionary<string, object>
        {
            { "id", id }
        };
        return await ApiRequest.Invoke<Cinema>(body, "cinema/read");
    }
    
    public static async Task<Cinema> UpdateCinema(int id, string name, string address)
    {
        var body = new Dictionary<string, object>
        {
            { "id", id },
            { "name", name },
            { "address", address }
        };
        return await ApiRequest.Invoke<Cinema>(body, "cinema/update");
    }
    
    public static async Task<Cinema> DeleteCinema(int id)
    {
        var body = new Dictionary<string, object>
        {
            { "id", id }
        };
        return await ApiRequest.Invoke<Cinema>(body, "cinema/delete");
    }
    
    public static async Task<Movie> CreateMovie(string name, string description, string genre, int duration, int cinemaId)
    {
        var body = new Dictionary<string, object>
        {
            { "name", name },
            { "description", description },
            { "genre", genre },
            { "duration", duration },
            { "cinemaId", cinemaId }
        };
        return await ApiRequest.Invoke<Movie>(body, "movie/create");
    }
    
    public static async Task<Movie> ReadMovie(int id)
    {
        var body = new Dictionary<string, object>
        {
            { "id", id }
        };
        return await ApiRequest.Invoke<Movie>(body, "movie/read");
    }
    
    public static async Task<List<Movie>> ReadAllMovie(int cinemaId)
    {
        var body = new Dictionary<string, object>
        {
            { "id", cinemaId }
        };
        return await ApiRequest.Invoke<List<Movie>>(body, "movie/readall");
    }
    
    public static async Task<Movie> UpdateMovie(int id, string name, string description, string genre, int duration, int cinemaId)
    {
        var body = new Dictionary<string, object>
        {
            { "id", id },
            { "name", name },
            { "description", description },
            { "genre", genre },
            { "duration", duration },
            { "cinemaId", cinemaId }
        };
        return await ApiRequest.Invoke<Movie>(body, "movie/update");
    }
    
    public static async Task<Movie> DeleteMovie(int id)
    {
        var body = new Dictionary<string, object>
        {
            { "id", id }
        };
        return await ApiRequest.Invoke<Movie>(body, "movie/delete");
    }
    
    public static async Task<Reservation> CreateReservation(
        int userId, int seatId, int movieId, int cinemaId, int scheduleId, double price, DateTime reservationDate 
    )
    {
        var body = new Dictionary<string, object>
        {
            {"userId", userId},
            {"seatId", seatId},
            {"movieId", movieId},
            {"cinemaId", cinemaId},
            {"scheduleId", scheduleId},
            {"reservationDate", reservationDate.ToString(CultureInfo.InvariantCulture)},
            {"price", price},
        };
        return await ApiRequest.Invoke<Reservation>(body, "reservation/create");
    }
    
    public static async Task<List<Reservation>> ReadReservation(int id)
    {
        var body = new Dictionary<string, object>
        {
            { "id", id }
        };
        return await ApiRequest.Invoke<List<Reservation>>(body, "reservation/read");
    }
    
    public static async Task<Reservation> UpdateReservation(
        int id, int userId, int seats, int movieId, int cinemaId, int scheduleId, double price, DateTime reservationDate 
    )
    {
        var body = new Dictionary<string, object>
        {
            {"id", id},
            {"userId", userId},
            {"seatId", seats},
            {"movieId", movieId},
            {"cinemaId", cinemaId},
            {"scheduleId", scheduleId},
            {"reservationDate", reservationDate},
            {"price", price},
        };
        return await ApiRequest.Invoke<Reservation>(body, "reservation/update");
    }
    
    public static async Task<Reservation> DeleteReservation(int id)
    {
        var body = new Dictionary<string, object>
        {
            { "id", id }
        };
        return await ApiRequest.Invoke<Reservation>(body, "reservation/delete");
    }
    
    public static async Task<Schedule> CreateSchedule(
        int movieId, int cinemaId, DateTime fromTime, DateTime toTime)
    {
        var body = new Dictionary<string, object>
        {
            { "cinemaId", cinemaId },
            { "movieId", movieId },
            { "fromTime", fromTime },
            { "toTime", toTime }
        };
        return await ApiRequest.Invoke<Schedule>(body, "schedule/create");
    }
    
    public static async Task<List<Schedule>> ReadSchedule(int id)
    {
        var body = new Dictionary<string, object>
        {
            { "id", id }
        };
        return await ApiRequest.Invoke<List<Schedule>>(body, "schedule/read");
    }
    
    public static async Task<Schedule> UpdateSchedule(
        int id, int movieId, int cinemaId, DateTime fromTime, DateTime toTime)
    {
        var body = new Dictionary<string, object>
        {
            { "id", id },
            { "cinemaId", cinemaId },
            { "movieId", movieId },
            { "fromTime", fromTime },
            { "toTime", toTime }
        };
        return await ApiRequest.Invoke<Schedule>(body, "schedule/update");
    }
    
    public static async Task<Schedule> DeleteSchedule(int id)
    {
        var body = new Dictionary<string, object>
        {
            { "id", id }
        };
        return await ApiRequest.Invoke<Schedule>(body, "schedule/delete");
    }
    
    public static async Task<Seat> CreateSeat(int cinemaId, int row, int column)
    {
        var body = new Dictionary<string, object>
        {
            { "cinemaId", cinemaId },
            { "row", row },
            { "column", column }
        };
        return await ApiRequest.Invoke<Seat>(body, "seat/create");
    }
    
    public static async Task<Seat> ReadSeat(int id)
    {
        var body = new Dictionary<string, object>
        {
            { "id", id }
        };
        return await ApiRequest.Invoke<Seat>(body, "seat/read");
    }
    
    public static async Task<List<Seat>?> ReadAllSeats(int cinemaId)
    {
        var body = new Dictionary<string, object>
        {
            { "id", cinemaId }
        };
        return await ApiRequest.Invoke<List<Seat>>(body, "seat/readall");
    }
    
    public static async Task<Seat> UpdateSeat(int id, int cinemaId, int row, int column)
    {
        var body = new Dictionary<string, object>
        {
            { "id", id },
            { "cinemaId", cinemaId },
            { "row", row },
            { "column", column }
        };
        return await ApiRequest.Invoke<Seat>(body, "seat/update");
    }
    
    public static async Task<Seat> DeleteSeat(int id)
    {
        var body = new Dictionary<string, object>
        {
            { "id", id }
        };
        return await ApiRequest.Invoke<Seat>(body, "seat/delete");
    }
    
    public static async Task<User> CreateUser(string name, string phone, string email, string password)
    {
        var body = new Dictionary<string, object>
        {
            { "name", name },
            { "phone", phone },
            { "email", email },
            { "password", password },
        };
        return await ApiRequest.Invoke<User>(body, "user/create");
    }
    
    public static async Task<User> ReadUser(int id)
    {
        var body = new Dictionary<string, object>
        {
            { "id", id }
        };
        return await ApiRequest.Invoke<User>(body, "user/read");
    }
    
    public static async Task<User> UpdateUser(int id, string name, string phone, string email, string password)
    {
        var body = new Dictionary<string, object>
        {
            { "id", id },
            { "name", name },
            { "phone", phone },
            { "email", email },
            { "password", password },
        };
        return await ApiRequest.Invoke<User>(body, "user/update");
    }
    
    public static async Task<User> LoginUser(string phone, string password)
    {
        var body = new Dictionary<string, object>
        {
            { "phone", phone },
            { "password", password },
        };
        return await ApiRequest.Invoke<User>(body, "user/login");
    }
    
    public static async Task<User> DeleteUser(int id)
    {
        var body = new Dictionary<string, object>
        {
            { "id", id }
        };
        return await ApiRequest.Invoke<User>(body, "user/delete");
    }
}