using Customers.WebApi;
using Customers.WebApi.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomerServiceRegistration(builder.Configuration);
builder.Services.ConfigureConsul(builder.Configuration);
var serviceProvider = builder.Services.BuildServiceProvider();
IHostApplicationLifetime lifetime = serviceProvider.GetRequiredService<IHostApplicationLifetime>();

var app = builder.Build();

// Configure the HTTP request pipeline.
 app.UseSwagger();
 app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.RegisterWithConsul(lifetime, builder.Configuration);

app.Run();
