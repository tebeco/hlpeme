using Microsoft.AspNetCore.Identity;
using BaseConn.Domain.models;
using BaseConn.Domain.Repository;


namespace BaseConn.Infrastructure.Repositories;

    public class UserRepository : IUserRepository
    {

        private readonly UserManager<ApplicationUser> _userManager;

         public UserRepository(UserManager<ApplicationUser> userManager)
          {
              _userManager = userManager;
          }
    public async Task<ApplicationUser> FindByUsernameAsync(string username)
    {
        return await _userManager.FindByNameAsync(username);
    }
         
          public async Task<ApplicationUser> FindByEmailAsync(string email)
       {
            return await _userManager.FindByEmailAsync(email);
         }


    public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role)
    {
       return  await _userManager.AddToRoleAsync(user, role);
    }

    public async Task<ApplicationUser> FindUserByIdAsync(string id)
    {
        return await _userManager.FindByIdAsync(id);
    }

  
    public async Task<IQueryable<ApplicationUser>> GetUsersAsync()
    {
        return _userManager.Users;
    }

    public async Task<List<string>> GetUserRolesAsync(ApplicationUser user)
    {
        return (await _userManager.GetRolesAsync(user)).ToList();
    }

}
