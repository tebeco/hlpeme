using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BaseConn.Application.Services;

namespace BaseConn.Application.IOC {

    public static class DependencyInjection
    {


          public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) {


           // Add MediatR services and register services from the assembly.
           services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            services.AddScoped<ITokenService, TokenService>();


               // Configure AutoMapper and add it as a singleton.
    var mappingConfig = new MapperConfiguration(mapperConfiguration =>
    {
      mapperConfiguration.ShouldMapMethod = (m => false);
      mapperConfiguration.AddProfile(new MappingProfiles());
    });
    IMapper autoMapper = mappingConfig.CreateMapper();
    services.AddSingleton(autoMapper);


            return services;
       


          }


        
    }

}
