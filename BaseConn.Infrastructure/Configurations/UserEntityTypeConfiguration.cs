

using BaseConn.Domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseConn.Infrastructure.Configurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {


            // Relationship configuration
            builder.HasOne(u => u.service)
                .WithMany(s => s.Users)
                .HasForeignKey(u => u.ServiceId)
           .OnDelete(DeleteBehavior.NoAction);








        }
    }
}