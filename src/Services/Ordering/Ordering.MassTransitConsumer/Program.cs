using MassTransit;
using MediatR;
using Ordering.Application;
using Ordering.Persistence;
using CoreFramework.Mailing;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddMailingServices();
builder.Services.AddHttpClient("CustomerApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7240/");
});

// Add services to the container.
builder.Services.AddMassTransit(x =>
{
    Assembly assembly = typeof(Program).Assembly;

    x.AddConsumers(assembly);
    x.AddActivities(assembly);
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri("amqps://pzgfgcrj:77QOhiJEDce-Wyb3T4G-qIdN-tfDr-Ay@hawk.rmq.cloudamqp.com/pzgfgcrj"), h =>
        {
            h.Username("<username>");
            h.Password("<password>");
        });
        cfg.ConfigureEndpoints(context);
    });

});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
