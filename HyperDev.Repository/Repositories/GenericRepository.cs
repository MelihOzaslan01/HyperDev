using HyperDev.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HyperDev.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _DbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _DbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _DbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _DbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _DbSet.AnyAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            return _DbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _DbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _DbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _DbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _DbSet.Where(expression);
        }
    }
}
