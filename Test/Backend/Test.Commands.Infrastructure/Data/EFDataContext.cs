using Microsoft.EntityFrameworkCore;
using Test.Domain.Entities.Test;

namespace Test.Commands.Infrastructure.Data
{
    public class EFDataContext : DbContext
    {
        public EFDataContext(DbContextOptions<EFDataContext> options) : base(options) { }

        public DbSet<TestEntity> TestEntity { get; set; }
    }
}
