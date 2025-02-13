using Hotel.API.Data;
using HotelReservation.API.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.API.Repositories
{
    public class SqlHotelRepository : IHotelRepository
    {
        private readonly HotelReservationDBContext hotelReservationDBContext;

        public SqlHotelRepository(HotelReservationDBContext hotelReservationDBContext)
        {
            this.hotelReservationDBContext = hotelReservationDBContext;
        }

        public async Task<Hotel.API.Models.Domain.Hotel> AddHotelAsync(Hotel.API.Models.Domain.Hotel hotel)
        {
            hotel.Id = new Guid();
            await hotelReservationDBContext.Hotels.AddAsync(hotel);
            await hotelReservationDBContext.SaveChangesAsync();
            return hotel;
        }

        public async Task<Hotel.API.Models.Domain.Hotel> DeleteHotelAsync(Guid id)
        {
            var hotel = await hotelReservationDBContext.Hotels.FirstOrDefaultAsync(x => x.Id == id);
            if (hotel == null)
                return null;
            hotelReservationDBContext.Remove(hotel);
            await hotelReservationDBContext.SaveChangesAsync();
            return hotel;
        }

        public async Task<IEnumerable<Hotel.API.Models.Domain.Hotel>> GetAllHotels()
        {
            return await hotelReservationDBContext.Hotels.ToListAsync();
        }

        public async Task<Hotel.API.Models.Domain.Hotel> GetHotel(Guid id)
        {
            var res = await hotelReservationDBContext.Hotels.FirstOrDefaultAsync(h => h.Id == id);
            return res;
        }
    }
}
