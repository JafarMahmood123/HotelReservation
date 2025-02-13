namespace HotelReservation.API.Repositories
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel.API.Models.Domain.Hotel>> GetAllHotels();
    }
}
