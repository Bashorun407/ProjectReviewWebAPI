using Microsoft.EntityFrameworkCore;
using ProjectReviewWebAPI.Infrastructure.Persistence;
using ProjectReviewWebAPI.Infrastructure.RepositoryBase.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Infrastructure.RepositoryBase.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context.Set<T>();
        }

        public void Create(T entity)
        {
           _context.Add(entity);
        }

        public async Task CreateAsync(T entity)
        {
           await _context.AddAsync(entity);
        }

        public async Task CreateRangeAsync(IEnumerable<T> entities)
        {
             _context.AddRange(entities);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
             _context.RemoveRange(entities);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges ? _context.AsNoTracking() :
            _context;
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ? _context.Where(expression).AsNoTracking():
                _context.Where(expression);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _context.UpdateRange(entities);
        }
    }
}
