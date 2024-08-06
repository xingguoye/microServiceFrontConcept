using Microsoft.EntityFrameworkCore;
using Test.Consumer.Infrastructure.Data;
using Test.Domain.IRepositories.ICommand;

namespace Test.Consumer.Infrastructure.Repositories.Test
{
    public abstract class CommandRepository<T> : ICommandRepository<T> where T : class
    {
        protected readonly EFDataContext _context;

        public CommandRepository(EFDataContext context)
        {
            _context = context;
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
