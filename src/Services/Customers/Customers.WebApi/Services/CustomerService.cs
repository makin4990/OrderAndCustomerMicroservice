using Customers.WebApi.BussinesRules;
using Customers.WebApi.Models;
using Customers.WebApi.Models.ResponseModels;
using Customers.WebApi.Repository;
using MongoDB.Bson;

namespace Customers.WebApi.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<DataResponse<List<Customer>>> GetAllAsync()
    {
        try
        {
            List<Customer> result = await _customerRepository.GetAllAsync();
            if (!result.Any())
                return new ErrorDataResponse<List<Customer>>("Customers not found");

            return new SuccessDataResponse<List<Customer>>(result);
        }
        catch (Exception)
        {
            return new ErrorDataResponse<List<Customer>>("Customers not found");
        }
    }

    public async Task<DataResponse<Customer>> GetByIdAsync(Guid id)
    {
        try
        {
            Customer result = await _customerRepository.GetByIdAsync(id);
            if (result is null)
                return new ErrorDataResponse<Customer>("Customers not found");

            return new SuccessDataResponse<Customer>(result);
        }
        catch (Exception)
        {
            return new ErrorDataResponse<Customer>("Customers not found");
        }
    }

    public async Task<DataResponse<Guid>> CreateAsync(Customer customer)
    {
        try
        {
            CreateCustomerBussinesRule rules = new();
            if(!rules.Run(customer))
                return new ErrorDataResponse<Guid>("Invalid model");

            customer.Id = Guid.NewGuid();
            customer.CreatedAt = DateTime.UtcNow;
            await _customerRepository.CreateAsync(customer);

            return new SuccessDataResponse<Guid>(customer.Id, "Customer created");
        }
        catch (Exception)
        {
            return new ErrorDataResponse<Guid>();
        }
    }

    public async Task<Response> UpdateAsync(Guid id, Customer customer)
    {
        try
        {
            customer.UpdatedAt = DateTime.UtcNow;
            await _customerRepository.UpdateAsync(id, customer);
            return new SuccessResponse();
        }
        catch (Exception)
        {
            return new ErrorResponse();
        }
    }

    public async Task<Response> DeleteAsync(Guid id)
    {
        try
        {
            Customer customer = await _customerRepository.GetByIdAsync(id);
            if (customer is null)
                return new ErrorResponse();

            await _customerRepository.DeleteAsync(id);
            return new SuccessResponse();

        }
        catch (Exception)
        {
            return new ErrorResponse();
        }
    }
    public async Task<Response> ValidateAsync(Guid id)
    {
        try
        {
            Customer customer = await _customerRepository.GetByIdAsync(id);
            if (customer is null)
                return new ErrorResponse();
            return new SuccessResponse();

        }
        catch (Exception)
        {
            return new ErrorResponse();
        }
    }
}