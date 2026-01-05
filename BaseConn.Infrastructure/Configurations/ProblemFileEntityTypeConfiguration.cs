

using BaseConn.Domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseConn.Infrastructure.Configurations
{
    public class ProblemFileEntityTypeConfiguration : IEntityTypeConfiguration<ProblemFile>
    {



        public void Configure(EntityTypeBuilder<ProblemFile> builder)
        {
            builder.HasKey(pf => pf.ProblemFileId);

            
            builder.Property(pf => pf.ProblemFileName)
                .IsRequired(false);



            builder.Property(pf => pf.ProblemFileType)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(pf => pf.ProblemFileSize)
                .IsRequired(false);

            

            // Relationship configuration
            builder.HasOne(pf => pf.problem)
                      .WithMany(p => p.ProblemFiles)
                      .HasForeignKey(pf => pf.ProblemId)
                      .OnDelete(DeleteBehavior.Cascade);




        }


    }
}