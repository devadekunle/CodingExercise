using Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T:class
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<T> FindAsync(Guid key)
        {
          
            return await _context.Set<T>().FindAsync(key);
        }

        public async Task InsertAsync(T entity)
        {
            _ = entity ?? throw new ArgumentNullException($"{nameof(entity)} camnot be null");
            await _context.Set<T>().AddAsync(entity);
             
        }

        public  Task UpdateAsync(T entity)
        {
            _ = entity ?? throw new ArgumentNullException($"{nameof(entity)} camnot be null");

            return Task.FromResult( _context.Update(entity));
            
            
        }
    }
}
