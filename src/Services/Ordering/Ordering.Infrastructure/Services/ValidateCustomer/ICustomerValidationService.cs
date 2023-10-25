using CoreFramework.Application.Responses;

namespace Ordering.Infrastructure.Services.ValidateCustomer;

public interface ICustomerValidationService
{
    Task<Response> ValidateCustomerById(Guid id);
}