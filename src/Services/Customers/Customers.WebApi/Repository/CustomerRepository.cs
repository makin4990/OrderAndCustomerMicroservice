using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Customers.WebApi.Models;

namespace Customers.WebApi.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly IMongoCollection<Customer> _collection;
    private readonly DbConfiguration _settings;
    public CustomerRepository(IOptions<DbConfiguration> settings)
    {
        _settings = settings.Value;
        var client = new MongoClient(_settings.ConnectionString);
        var database = client.GetDatabase(_settings.DatabaseName);
        _collection = database.GetCollection<Customer>(_settings.CollectionName);
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        return await _collection.Find(c => true).ToListAsync();
    }
    public async Task<Customer> GetByIdAsync(Guid id)
    {
        return await _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
    }
    public async Task<Customer> CreateAsync(Customer customer)
    {
        await _collection.InsertOneAsync(customer).ConfigureAwait(false);
        return customer;
    }
    public async Task UpdateAsync(Guid id, Customer customer)
    {
        await _collection.ReplaceOneAsync(c => c.Id == id, customer);
    }
    public async Task DeleteAsync(Guid id)
    {
        await _collection.DeleteOneAsync(c => c.Id == id);
        
    }
}