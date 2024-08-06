using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test.Domain.Entities.Test;
using Test.Queries.Infrastructure.Repositories.Test;

namespace Test.Queries.Infrastructure.Extensions
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITestQueryRepository, TestQueryRepository>();

            return new ServiceCollection();
        }
    }
}
