using Hotel.API.Models.Domain;
using Hotel.API.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.API.Repositories
{
    public class SqlCustomerRepository : ICustomerRepository
    {
        private readonly HotelReservationDBContext hotelReservationDBContext;

        public SqlCustomerRepository(HotelReservationDBContext hotelReservationDBContext)
        {
            this.hotelReservationDBContext = hotelReservationDBContext;
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            customer.Id = new Guid();
            await hotelReservationDBContext.Customers.AddAsync(customer);
            await hotelReservationDBContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> DeleteCustomerAsync(Guid id)
        {
            var customer = await hotelReservationDBContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
                return null;
            hotelReservationDBContext.Remove(customer);
            await hotelReservationDBContext.SaveChangesAsync();
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await hotelReservationDBContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomer(Guid id)
        {
            var res = await hotelReservationDBContext.Customers.FirstOrDefaultAsync(h => h.Id == id);
            return res;
        }

        public async Task<Customer> UpdateCustomerAsync(Guid id, Customer hotel)
        {
            var existingHotel = await hotelReservationDBContext.Customers.FirstOrDefaultAsync(hotel => hotel.Id == id);
            if (existingHotel == null)
                return null;
            existingHotel.Name = hotel.Name;
            await hotelReservationDBContext.SaveChangesAsync();
            return existingHotel;
        }
    }
}
