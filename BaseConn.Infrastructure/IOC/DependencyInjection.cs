using BaseConn.Domain.models;
using BaseConn.Domain.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BaseConn.Infrastructure.Repositories;
using BaseConn.Infrastructure.Repository;

namespace BaseConn.Infrastructure.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {


            // Add DbContext with SQL Server
            services.AddDbContext<ApplicationContext>((sp, contextBuilder) =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                contextBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
            });





            // Add Identity services
            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
           .AddEntityFrameworkStores<ApplicationContext>()
           .AddDefaultTokenProviders();


            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProblemRepository, ProblemRepository>();
            services.AddScoped<ISolutionRepository, SolutionRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();












            return services;
        }
    }
}