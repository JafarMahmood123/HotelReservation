using Hotel.API.Models.Domain;

namespace HotelReservation.API.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();

        Task<Customer> GetCustomer(Guid id);

        Task<Customer> AddCustomerAsync(Customer hotel);

        Task<Customer> DeleteCustomerAsync(Guid id);

        Task<Customer> UpdateCustomerAsync(Guid id, Customer hotel);
    }
}
