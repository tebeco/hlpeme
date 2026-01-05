

using BaseConn.Domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseConn.Infrastructure.Configurations
{
    public class NoteFileEntityTypeConfiguration : IEntityTypeConfiguration<NoteFile>
    {
        public void Configure(EntityTypeBuilder<NoteFile> builder)
        {
            builder.HasKey(nf => nf.NoteFileId);

            
            builder.Property(nf => nf.NoteFileName)
                .IsRequired(false);



            builder.Property(nf => nf.NoteFileType)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(nf => nf.NoteFileSize)
                .IsRequired(false);

            

            // Relationship configuration
            builder.HasOne(nf => nf.note)
                      .WithMany(n => n.NoteFiles)
                      .HasForeignKey(nf => nf.NoteId)
                      .OnDelete(DeleteBehavior.Cascade);

        }
    }
}