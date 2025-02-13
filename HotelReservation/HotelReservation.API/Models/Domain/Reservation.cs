namespace Hotel.API.Models.Domain
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public int RoomNumber { get; set; }


        public Guid CustomerId { get; set; }
        public Guid HotelId { get; set; }


        public Customer Customer { get; set; }
        public Hotel Hotel { get; set; }
    }
}
