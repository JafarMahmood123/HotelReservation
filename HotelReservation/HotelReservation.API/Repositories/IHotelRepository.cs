using HotelReservation.API.Models.DTO;

namespace HotelReservation.API.Repositories
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel.API.Models.Domain.Hotel>> GetAllHotels();

        Task<Hotel.API.Models.Domain.Hotel> GetHotel(Guid id);

        Task<Hotel.API.Models.Domain.Hotel> AddHotelAsync(Hotel.API.Models.Domain.Hotel hotel);
        Task<Hotel.API.Models.Domain.Hotel> DeleteHotelAsync(Guid id);
    }
}
