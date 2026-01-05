

using BaseConn.Domain.enums;
using BaseConn.Domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseConn.Infrastructure.Configurations
{
    public class ProblemEntityTypeConfiguration : IEntityTypeConfiguration<Problem>
    {

        public void Configure(EntityTypeBuilder<Problem> builder)
        {
            builder.HasKey(p => p.problem_id);


            builder.HasMany(p => p.solutions)
                    .WithOne()
                    .HasForeignKey(s => s.problem_id)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.ProblemStatus).HasConversion<int>();
            builder.Property(p => p.ProblemStatus).HasDefaultValue(ProblemStatus.UnResolved);


            // Relationship configuration
            builder.HasOne(p => p.User)
                .WithMany(p => p.Problems)
                .HasForeignKey(n => n.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
                

            builder.HasOne(p => p.FounderUser)
        .WithMany(p => p.FounderProblems)
        .HasForeignKey(n => n.FounderId)
             .IsRequired(false)
        .OnDelete(DeleteBehavior.NoAction);
        }


    }
}