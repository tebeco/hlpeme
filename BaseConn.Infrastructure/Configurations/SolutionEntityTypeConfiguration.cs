

using System.Xml.Serialization;
using BaseConn.Domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseConn.Infrastructure.Configurations
{
    public class SolutionEntityTypeConfiguration : IEntityTypeConfiguration<Solution>
    {

        public void Configure(EntityTypeBuilder<Solution> builder)
    {
            builder
                .HasKey(s => s.solution_id);
            builder.Property(s => s.solution_id)
            .ValueGeneratedNever(); 
            builder
                .Property(s => s.solution_file_path)
                .IsRequired(false);
                    builder
                .Property(s => s.solution_description)
                .IsRequired(false);
                 
    }
        
    }
}