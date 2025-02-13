using Hotel.API.Data;

namespace HotelReservation.API.Repositories
{
    public class SqlHotelRepository : IHotelRepository
    {
        private readonly HotelReservationDBContext hotelReservationDBContext;

        public SqlHotelRepository(HotelReservationDBContext hotelReservationDBContext)
        {
            this.hotelReservationDBContext = hotelReservationDBContext;
        }

        public IEnumerable<Hotel.API.Models.Domain.Hotel> GetHotels()
        {
            return hotelReservationDBContext.Hotels.ToList();
        }
    }
}
