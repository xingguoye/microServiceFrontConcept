using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Test.Consumer.Application.Extensions;
using Test.Consumer.Infrastructure.Extensions;

var builder = Host.CreateApplicationBuilder();

IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddMassTransit(x =>
{
    var entryAssembly = Assembly.GetExecutingAssembly();
    x.AddConsumers(entryAssembly);
    x.AddSagaStateMachines(entryAssembly);
    x.AddSagas(entryAssembly);
    x.AddActivities(entryAssembly);

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(config["rabbitMQ:HostName"], ushort.Parse(config["rabbitMQ:Port"]), config["rabbitMQ:VirtualHost"], h => {
            h.Username(config["rabbitMQ:UserName"]);
            h.Password(config["rabbitMQ:Password"]);
        });

        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddApplicationService();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.Run();