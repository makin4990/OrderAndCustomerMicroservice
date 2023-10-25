using CoreFramework.Persistence.Repositories;
using System.Runtime.InteropServices;

namespace Ordering.Domain.Entities;

public class Order :Entity
{
    public Order( Guid id,DateTime cretedAt, DateTime? updatedAt, Guid customerId, int quantity, double price, string status, Product product):base(id,cretedAt,updatedAt)
    {
        CustomerId = customerId;
        Quantity = quantity;
        Price = price;
        Status = status;
        Product = product;
    }
    public Order()
    {
    }
    public Guid CustomerId { get; private set; }
    public int  Quantity { get; private set; }
    public double Price { get; private set; }
    public string Status { get; private set; }
    public Product Product{ get; private set; }
    public Address Address { get; private set; }

    public void SetStatus(string status)
    {
        Status = status;
    }
    public void Update()
    {
       base.Update();
    }

}
