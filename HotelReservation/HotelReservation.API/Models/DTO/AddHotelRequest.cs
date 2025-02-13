namespace HotelReservation.API.Models.DTO
{
    public class AddHotelRequest
    {
        public string Name { get; set; }
        public double RoomRent { get; set; }
        public int NumberOfRooms { get; set; }
    }
}
