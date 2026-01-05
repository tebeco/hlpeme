using BaseConn.Domain.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BaseConn.Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity;

namespace BaseConn.Infrastructure
{
    public class ApplicationContext (DbContextOptions options) : IdentityDbContext<ApplicationUser,IdentityRole<Guid>,Guid>(options) {



   
     public DbSet<Problem> problems { get; set; }
     public DbSet<Solution> solutions { get; set; }
     public DbSet<Note> notes { get; set; }
     public DbSet<ProblemFile> problemFiles {get;set;}

     public DbSet<NoteFile> noteFiles {get;set;}

    public DbSet<SolutionFile> solutionFiles {get;set;}

     public DbSet<Service> services {get;set;} 

      protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            new ProblemEntityTypeConfiguration().Configure(modelBuilder.Entity<Problem>());
            new SolutionEntityTypeConfiguration().Configure(modelBuilder.Entity<Solution>());
            new ProblemFileEntityTypeConfiguration().Configure(modelBuilder.Entity<ProblemFile>());
            new ServiceEntityTypeConfiguration().Configure(modelBuilder.Entity<Service>());
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<ApplicationUser>());
            new NoteFileEntityTypeConfiguration().Configure(modelBuilder.Entity<NoteFile>());
            new SolutionFileEntityTypeConfiguration().Configure(modelBuilder.Entity<SolutionFile>());
            // modelBuilder.ApplyConfiguration(new RoleConfiguration());
   
        }



    }
        
    
}