namespace Hotel.API.Models.Domain
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid HotelId { get; set; }
        public Customer customer { get; set; }
        public Hotel hotel { get; set; }
        public int RoomNumber { get; set; }
    }
}
