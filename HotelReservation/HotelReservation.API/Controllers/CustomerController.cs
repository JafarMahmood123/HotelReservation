using Hotel.API.Models.Domain;
using HotelReservation.API.Models.DTO;
using HotelReservation.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await customerRepository.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetCustomer")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var res = await customerRepository.GetCustomer(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomerAsync(AddCustomerRequest addCustomerRequest)
        {
            var customer = new Customer()
            {
                Name = addCustomerRequest.Name,
            };

            customer = await customerRepository.AddCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCustomerAsyn(Guid id)
        {
            var customer = await customerRepository.DeleteCustomerAsync(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] Guid id, [FromBody] UpdateCustomerRequest updateCustomerRequest)
        {
            var newHotel = new Customer()
            {
                Name = updateCustomerRequest.Name,
            };
            var existingHotl = await customerRepository.UpdateCustomerAsync(id, newHotel);
            if (existingHotl == null)
                return NotFound();

            return Ok(newHotel);
        }

    }
}
