using BaseConn.Domain.models;

namespace BaseConn.Application.Services
{
    public interface ITokenService
    {

        Task<string> GenerateTokenAsync(ApplicationUser user);

        
    }
}