using Hotel.API.Models.Domain;

namespace HotelReservation.API.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();

        Task<Customer> GetCustomer(Guid id);

        Task<Customer> AddHotelAsync(Customer hotel);

        Task<Customer> DeleteHotelAsync(Guid id);

        Task<Customer> UpdateHotelAsync(Guid id, Customer hotel);
    }
}
