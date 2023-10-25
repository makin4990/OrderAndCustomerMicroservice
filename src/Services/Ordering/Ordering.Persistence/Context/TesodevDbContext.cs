using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Persistence.Context;

public class TesodevDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderLog> OrderLogs { get; set; }
    protected IConfiguration Configuration { get; set; }

    public TesodevDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(a =>
        {
            a.ToTable("Orders").HasKey(k => k.Id);

            a.HasOne(p => p.Product);

            a.OwnsOne(p=> p.Address, builerder =>
            {
                builerder.Property(p => p.AddressLine).HasColumnName("Address_AddressLine");
                builerder.Property(p => p.City).HasColumnName("Address_City");
                builerder.Property(p => p.CityCode).HasColumnName("Address_CityCode");
                builerder.Property(p => p.Country).HasColumnName("Address_Country");
            });
        });

        modelBuilder.Entity<Order>().OwnsOne(i => i.Address);

        modelBuilder.Entity<Product>(a =>
        {
            a.ToTable("Products").HasKey(k => k.Id);
        });

        modelBuilder.Entity<OrderLog>(a =>
        {
            a.ToTable("OrderLogs").HasKey(k => k.Id);
        });
    }
}
