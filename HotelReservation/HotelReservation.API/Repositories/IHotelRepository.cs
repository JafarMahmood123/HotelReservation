namespace HotelReservation.API.Repositories
{
    public interface IHotelRepository
    {
        IEnumerable<Hotel.API.Models.Domain.Hotel> GetHotels();
    }
}
