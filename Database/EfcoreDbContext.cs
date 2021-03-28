using Microsoft.EntityFrameworkCore;
using efcoredemo.Models;

namespace efcoredemo.Database
{
    public class EfcoreDbContext : DbContext
    {
                public EfcoreDbContext(DbContextOptions<EfcoreDbContext> options) : base(options)
        {

        }
        public DbSet<Note> Notes { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteEntityConfiguration());
        }
    }
}