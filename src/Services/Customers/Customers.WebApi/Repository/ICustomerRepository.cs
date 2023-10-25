using Customers.WebApi.Models;

namespace Customers.WebApi.Repository;
public interface ICustomerRepository
{
    Task<List<Customer>> GetAllAsync();
    Task<Customer> GetByIdAsync(Guid id);
    Task<Customer> CreateAsync(Customer customer);
    Task UpdateAsync(Guid id, Customer customer);
    Task DeleteAsync(Guid id);
}