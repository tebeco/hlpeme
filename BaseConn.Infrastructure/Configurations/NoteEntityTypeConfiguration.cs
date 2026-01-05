
using BaseConn.Domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseConn.Infrastructure.Configurations
{
     public class NoteEntityTypeConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(n => n.NoteId);

            builder.Property(n => n.NoteTitle)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(n => n.NoteDescription)
                .HasMaxLength(2000);

            builder.Property(n => n.NoteCreationDate)
                .IsRequired();

            builder.Property(n => n.NoteCategory)
                .HasMaxLength(100);

            builder.Property(n => n.UserId)
                .IsRequired();

            // Relationship configuration
            builder.HasOne(n => n.User)
                .WithMany(u => u.Notes)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}