using HotelReservation.API.Models.DTO;
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
        public async Task<IActionResult> GetAllHotels()
        {
            var hotels = await hotelRepository.GetAllHotels();
            return Ok(hotels);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetHotel")]
        public async Task<IActionResult> GetHotel(Guid id) 
        {
            var res= await hotelRepository.GetHotel(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddHotelAsync(AddHotelRequest addHotelRequest)
        {
            if (!ValidateAddHotelAsync(addHotelRequest))
                return BadRequest(ModelState);
            var hotel = new Hotel.API.Models.Domain.Hotel()
            {
                Name = addHotelRequest.Name,
                RoomRent = addHotelRequest.RoomRent,
                NumberOfRooms = addHotelRequest.NumberOfRooms
            };

            hotel = await hotelRepository.AddHotelAsync(hotel);
            return CreatedAtAction(nameof(GetHotel), new { id = hotel.Id }, hotel);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteHotelAsyn(Guid id)
        {
            var hotel = await hotelRepository.DeleteHotelAsync(id);
            if(hotel == null)
                return NotFound();
            return Ok(hotel);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateHotel([FromRoute] Guid id, [FromBody] UpdateHotelRequest updateHotelRequest)
        {
            var newHotel = new Hotel.API.Models.Domain.Hotel()
            {
                Name = updateHotelRequest.Name,
                NumberOfRooms = updateHotelRequest.NumberOfRooms,
                RoomRent = updateHotelRequest.RoomRent
            };
            var existingHotl = await hotelRepository.UpdateHotelAsync(id, newHotel);
            if (existingHotl == null)
                return NotFound();

            return Ok(newHotel);
        }

        #region Private methods
        private bool ValidateAddHotelAsync(AddHotelRequest addHotelRequest)
        {
            if (addHotelRequest == null)
            {
                ModelState.AddModelError(nameof(addHotelRequest),
                    $"Add hotel data is required.");
                return false;
            }
            if (string.IsNullOrEmpty(addHotelRequest.Name))
                ModelState.AddModelError(nameof(addHotelRequest.Name),
                    $"{nameof(addHotelRequest.Name)} can not be null or empty or white space.");
            if (addHotelRequest.NumberOfRooms <= 10)
                ModelState.AddModelError(nameof(addHotelRequest.NumberOfRooms),
                    $"{nameof(addHotelRequest.NumberOfRooms)} can not be negative or less than 10 rooms.");
            if (addHotelRequest.RoomRent <= 0)
                ModelState.AddModelError(nameof(addHotelRequest.RoomRent),
                    $"{nameof(addHotelRequest.RoomRent)} can not be negative value.");

            if(ModelState.ErrorCount > 0)
                return false;

            return true;
        }

        #endregion
    }
}
