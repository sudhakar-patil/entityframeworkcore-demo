using Microsoft.EntityFrameworkCore;
using efcoredemo.Database;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace efcoredemo.Database
{
   public class NoteEntityConfiguration
        : IEntityTypeConfiguration<Note>
    {

        public void Configure(EntityTypeBuilder<Note> noteConfiguration)
        {
            noteConfiguration.Property(b => b.Id)
            .UseIdentityColumn();

            noteConfiguration.Property(b => b.Title)
            .HasMaxLength(50)
            .IsRequired();

            noteConfiguration.Property(b => b.Details)
            .HasMaxLength(500)
            .IsRequired();
        }
    }
}
