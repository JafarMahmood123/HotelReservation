using Hotel.API.Models.Domain;
using Hotel.API.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.API.Repositories
{
    public class SqlReservationRepository : IReservationRepository
    {
        private readonly HotelReservationDBContext hotelReservationDBContext;

        public SqlReservationRepository(HotelReservationDBContext hotelReservationDBContext)
        {
            this.hotelReservationDBContext = hotelReservationDBContext;
        }

        public async Task<Reservation> AddReservationAsync(Reservation reservation)
        {
            reservation.Id = new Guid();
            await hotelReservationDBContext.Reservations.AddAsync(reservation);
            await hotelReservationDBContext.SaveChangesAsync();
            return reservation;
        }

        public async Task<Reservation> DeleteReservationAsync(Guid id)
        {
            var reservation = await hotelReservationDBContext.Reservations.FirstOrDefaultAsync(x => x.Id == id);
            if (reservation == null)
                return null;
            hotelReservationDBContext.Remove(reservation);
            await hotelReservationDBContext.SaveChangesAsync();
            return reservation;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await hotelReservationDBContext.Reservations.ToListAsync();
        }

        public async Task<Reservation> GetReservation(Guid id)
        {
            var res = await hotelReservationDBContext.Reservations.FirstOrDefaultAsync(r => r.Id == id);
            return res;
        }

        public async Task<Reservation> UpdateReservationAsync(Guid id, Reservation reservation)
        {
            var existingReservation = await hotelReservationDBContext.Reservations.FirstOrDefaultAsync(r => r.Id == id);
            if (existingReservation == null)
                return null;
            existingReservation.RoomNumber = reservation.RoomNumber;
            await hotelReservationDBContext.SaveChangesAsync();
            return existingReservation;
        }
    }
}
