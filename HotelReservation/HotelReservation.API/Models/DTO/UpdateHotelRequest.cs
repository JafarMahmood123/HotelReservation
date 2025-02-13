namespace HotelReservation.API.Models.DTO
{
    public class UpdateHotelRequest
    {
        public string Name { get; set; }
        public double RoomRent { get; set; }
        public int NumberOfRooms { get; set; }
    }
}
