using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test.Commands.Infrastructure.Data;
using Test.Commands.Infrastructure.MassTransit.Test;
using Test.Commands.Infrastructure.Repositories.Commands;
using Test.Domain.Entities.Test;

namespace Test.Commands.Infrastructure.Extensions
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration["rabbitMQ:HostName"], ushort.Parse(configuration["rabbitMQ:Port"]), configuration["rabbitMQ:VirtualHost"], h => {
                        h.Username(configuration["rabbitMQ:UserName"]);
                        h.Password(configuration["rabbitMQ:Password"]);
                    });
                });
            });

            services.AddDbContext<EFDataContext>(
                option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddScoped<ITestMassTransitPublisher, TestMassTransitPublisher>();

            services.AddScoped<ITestCommandRepository, TestCommandRepository>();

            return new ServiceCollection();  
        }
    }
}
