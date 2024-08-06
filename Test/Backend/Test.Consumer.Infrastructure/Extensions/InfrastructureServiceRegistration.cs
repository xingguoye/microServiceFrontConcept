using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test.Consumer.Infrastructure.Data;
using Test.Consumer.Infrastructure.Repositories.Test;
using Test.Domain.Entities.Test;

namespace Test.Consumer.Infrastructure.Extensions
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EFDataContext>(
                option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddScoped<ITestCommandRepository, TestCommandRepository>();

            return new ServiceCollection();
        }
    }
}
