using BaseConn.Api.Db.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BaseConn.Api.Db
{
    public class ApplicationContext (DbContextOptions options)
        : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>(options) 
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}