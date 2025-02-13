using Hotel.API.Models.Domain;
using HotelReservation.API.Models.DTO;
using HotelReservation.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : Controller
    {
        private readonly IReservationRepository reservationRepository;

        public ReservationController(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            var reservation = await reservationRepository.GetAllReservations();
            return Ok(reservation);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetReservation")]
        public async Task<IActionResult> GetReservation(Guid id)
        {
            var res = await reservationRepository.GetReservation(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddReservationAsync([FromBody]AddReservationRequest addReservationRequest)
        {
            var reservation = new Reservation()
            {
                RoomNumber = addReservationRequest.RoomNumber,
                CustomerId = addReservationRequest.CustomerId, 
                HotelId = addReservationRequest.HotelId
            };

            reservation = await reservationRepository.AddReservationAsync(reservation);
            return CreatedAtAction(nameof(GetReservation), new { id = reservation.Id }, reservation);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteReservationAsyn(Guid id)
        {
            var reservation = await reservationRepository.DeleteReservationAsync(id);
            if (reservation == null)
                return NotFound();
            return Ok(reservation);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateReservation([FromRoute] Guid id, [FromBody] UpdateReservationRequest updateReservationRequest)
        {
            var newReservation = new Reservation()
            {
                RoomNumber = updateReservationRequest.RoomNumber,
                CustomerId = updateReservationRequest.CustomerId,
                HotelId = updateReservationRequest.HotelId
            };
            var existingReservation = await reservationRepository.UpdateReservationAsync(id, newReservation);
            if (existingReservation == null)
                return NotFound();

            return Ok(newReservation);
        }

    }
}
