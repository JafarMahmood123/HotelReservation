namespace Hotel.API.Models.Domain
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
