using Microsoft.EntityFrameworkCore;
using SchoolOfDevs.Context;
using SchoolOfDevs.Entities.Base;
using SchoolOfDevs.Repositories.Contracts;

namespace SchoolOfDevs.Repositories.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _context.Set<T>()
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public virtual async Task<T> Get(int id)
        {
            var obj = await _context.Set<T>()
                                    .AsNoTracking()
                                    .Where(x => x.Id == id)
                                    .ToListAsync();

            return obj.FirstOrDefault();
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var obj = await Get(id);

            if (obj != null)
            {
                _context.Entry(obj).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }

        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
