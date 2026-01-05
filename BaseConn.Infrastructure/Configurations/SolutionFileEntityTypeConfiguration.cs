

using BaseConn.Domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseConn.Infrastructure.Configurations
{
    public class SolutionFileEntityTypeConfiguration : IEntityTypeConfiguration<SolutionFile>
    {
        public void Configure(EntityTypeBuilder<SolutionFile> builder)
        {
            builder.HasKey(sf => sf.SolutionFileId);

            
            builder.Property(sf => sf.SolutionFileName)
                .IsRequired(false);



            builder.Property(sf => sf.SolutionFileType)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(sf => sf.SolutionFileSize)
                .IsRequired(false);

            

            // Relationship configuration
            builder.HasOne(sf => sf.solution)
                      .WithMany(s => s.SolutionFiles)
                      .HasForeignKey(sf => sf.SolutionId)
                      .OnDelete(DeleteBehavior.Cascade);

        }
    }
}