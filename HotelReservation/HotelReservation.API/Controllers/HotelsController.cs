using HotelReservation.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelsController : Controller
    {
        private readonly IHotelRepository hotelRepository;

        public HotelsController(IHotelRepository hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }
        [HttpGet]
        public IActionResult GetAllHotels()
        {
            var hotels = hotelRepository.GetHotels();
            return Ok(hotels);
        }
    }
}
