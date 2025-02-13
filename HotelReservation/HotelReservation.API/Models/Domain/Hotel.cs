namespace Hotel.API.Models.Domain
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double RoomRent { get; set; }
        public int NumberOfRooms { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
