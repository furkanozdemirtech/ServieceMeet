using CreatedMeetRepository.RestGenericInterface;
using CreatedMeetRepository.SqlContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreatedMeetRepository.RestJob
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MeetDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(MeetDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _dbSet = context.Set<T>();
            if (_dbSet == null)
            {
                throw new ArgumentNullException(nameof(_dbSet), $"DbSet of type {typeof(T).Name} could not be found.");
            }
        }

        public async Task<T> AddAsync(T item)
        {
            _dbSet.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return false;
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity != null;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {

            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return null;

            return entity;
        }

        public async Task<(bool IsSuccess, T Item)> UpdateAsync(T item)
        {
            _dbSet.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            return (result > 0, item);
        }
    }
}
