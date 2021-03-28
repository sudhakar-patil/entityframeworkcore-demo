
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using efcoredemo.Interface;
namespace efcoredemo.Database
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        DbSet<T> Table { get; set; }

        public Repository(EfcoreDbContext context)
        {
            Table = context.Set<T>();
        }

        public async Task Add(T entity) => await Table.AddAsync(entity);

        public async Task Add(IEnumerable<T> items) => await Table.AddRangeAsync(items);

        public async Task<IList<T>> All() => await Table.AsNoTracking().ToListAsync();

        public void Delete(T entity) => Table.Remove(entity);

        public void Delete(IEnumerable<T> entities) => Table.RemoveRange(entities);

        public async Task<T> GetById(int id) => await Table.SingleAsync(x => x.Id.Equals(id));

        public void Update(T entity) => Table.Update(entity);

        public void Update(IEnumerable<T> items) => Table.UpdateRange(items);

        public IQueryable<T> Where(Expression<Func<T, bool>> expression) => Table.Where(expression);
    }
}