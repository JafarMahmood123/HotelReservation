using Hotel.API.Models.Domain;

namespace HotelReservation.API.Models.DTO
{
    public class UpdateReservationRequest
    {
        public Guid CustomerId { get; set; }
        public Guid HotelId { get; set; }
        public int RoomNumber { get; set; }
    }
}
