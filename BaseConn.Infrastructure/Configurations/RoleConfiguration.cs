using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseConn.Infrastructure.Configurations
{
  public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
  {
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
      builder
          .HasData(
            new IdentityRole
          {
            Id = "6696b339-9775-11ef-8f90-0a002700000c",
            Name = "admin",
            NormalizedName = "ADMIN"
          },
          new IdentityRole {
            
            Id = "6696ccee-9775-11ef-8f90-0a002700000c",
            Name = "user",
            NormalizedName = "USER"
          }); 
    }
  }
}


//   new ApplicationRole
// {
//   Id = new Guid("28ac8d6c-bfd6-4709-bb81-338856d5010d"),
//   Name = "Manager de Vente",
//   Description="",
//   NormalizedName = "MANAGER DE VENTE"
// },
// new ApplicationRole
// {
//   Id = new Guid("b7204ac2-b4d9-4d17-8551-28320cb2560d"),
//   Name = "Administrator",
//   Description="",
//   NormalizedName = "ADMINISTRATOR"
// },