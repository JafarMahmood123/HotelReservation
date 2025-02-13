using Hotel.API.Data;
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

        public async Task<IEnumerable<Hotel.API.Models.Domain.Hotel>> GetAllHotels()
        {
            return await hotelReservationDBContext.Hotels.ToListAsync();
        }
    }
}
