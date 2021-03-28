
using System;
using System.Threading.Tasks;
using efcoredemo.Interface;
namespace efcoredemo.Database
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class,IEntity
    {
        private readonly EfcoreDbContext context;

        public UnitOfWork(EfcoreDbContext context)
        {
            this.context = context;
            Repository = new Repository<T>(context);
        }

        public IRepository<T> Repository { get; }

        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}