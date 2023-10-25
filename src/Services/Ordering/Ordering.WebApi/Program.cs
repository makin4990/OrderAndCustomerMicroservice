using MediatR;
using Ordering.Application;
using Ordering.Persistence;
using System.Reflection;
using CoreFramework.Mailing;
using Hangfire;
using Ordering.Hangfire;
using MassTransit;
using Ordering.WebApi.Extentions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddMailingServices();
builder.Services.AddHangfireServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.ConfigureConsul(builder.Configuration);
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins("http://localhost:7101", "https://localhost:7123").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
));
builder.Services.AddHttpClient("CustomerApi", client =>
{
    client.BaseAddress = new Uri("http://c_customer");
});

var serviceProvider = builder.Services.BuildServiceProvider();
IHostApplicationLifetime lifetime  = serviceProvider.GetRequiredService<IHostApplicationLifetime>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseHangfireServer();



app.MapControllers();
RunRecurringJobs.RunJobs();
app.RegisterWithConsul(lifetime,builder.Configuration);
app.Run();
