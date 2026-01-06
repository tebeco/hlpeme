using BaseConn.Api.Db.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BaseConn.Api.Db;

public static class ApplicationDbContextServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationContext>((sp, contextBuilder) =>
        {
            var configuration = sp.GetRequiredService<IConfiguration>();
            contextBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
        });

        // Add Identity services
        services.AddIdentity<ApplicationUser, IdentityRole<int>>()
           .AddEntityFrameworkStores<ApplicationContext>()
           .AddDefaultTokenProviders();
        
        return services;
    }
}
