using Hotel.API.Models.Domain;

namespace HotelReservation.API.Repositories
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAllReservations();

        Task<Reservation> GetReservation(Guid id);

        Task<Reservation> AddReservationAsync(Reservation reservation);

        Task<Reservation> DeleteReservationAsync(Guid id);

        Task<Reservation> UpdateReservationAsync(Guid id, Reservation reservation);
    }
}
