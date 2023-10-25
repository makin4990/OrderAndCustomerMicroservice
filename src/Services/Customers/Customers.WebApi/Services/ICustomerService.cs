using Customers.WebApi.Models;
using Customers.WebApi.Models.ResponseModels;

namespace Customers.WebApi.Repository;

public interface ICustomerService
{
    Task<DataResponse<List<Customer>>> GetAllAsync();
    Task<DataResponse<Customer>> GetByIdAsync(Guid id);
    Task<DataResponse<Guid>> CreateAsync(Customer customer);
    Task<Response> UpdateAsync(Guid id, Customer customer);
    Task<Response> DeleteAsync(Guid id);
    Task<Response> ValidateAsync(Guid id);
}
