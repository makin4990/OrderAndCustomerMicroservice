using Customers.WebApi.Models;

namespace Customers.WebApi.BussinesRules;

public class CreateCustomerBussinesRule
{
    public bool Run(Customer customer)
    {
        return NameCannotBeNull(customer.Name) && EmailCannotBeNull(customer.Email)&& IdCannotBeAssigned(customer.Id);
    }

    private bool NameCannotBeNull(string name)=> !string.IsNullOrEmpty(name);
    private bool EmailCannotBeNull(string email) => !string.IsNullOrEmpty(email);
    private bool IdCannotBeAssigned(Guid id) => Guid.Empty == id;

}
